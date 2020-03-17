using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using System.IO;

namespace BarberShop
{
    public partial class Form1 : Form
    {
        string _db = "";
        Timer _timer = new Timer();
        DataTable _exportUse = null;
        DataTable _exportRemaining = null;
        public Form1()
        {
            InitializeComponent();
            _db = AppDomain.CurrentDomain.BaseDirectory + "barbershop.db";
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            labelDatetime.Text =  DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        bool InitGoods()
        {
            try
            {
                DB.AllGoods.Clear();
                SQLiteHelper sh = new SQLiteHelper();
                DataTable dt = sh.ExecuteQuery("select * from goods where Deleted =='F'");
                foreach (DataRow item in dt.Rows)
                {
                    Goods g = new Goods();
                    g.name = item["Name"].ToString();                   
                    g.id = int.Parse(item["ID"].ToString());                   
                    g.memo = item["Memo"].ToString();
                    DB.AllGoods.Add(g);
                }
            }
            catch (Exception ex)
            {
                DB.AllGoods.Clear();
                return false;
            }
            return true;
        }
        bool InitUser()
        {
            try
            {
                DB.AllUser.Clear();
                SQLiteHelper sh = new SQLiteHelper();
                DataTable dt = sh.ExecuteQuery("select * from user where Deleted =='F'");
                foreach (DataRow item in dt.Rows)
                {
                    User us = new User();
                    us.id = int.Parse(item["ID"].ToString());
                    us.memo = item["Memo"].ToString();
                    us.name = item["Name"].ToString();
                    us.tel = item["Tel"].ToString();
                    us.add = item["Address"].ToString();
                    DB.AllUser.Add(us);
                }
            }
            catch (Exception ex)
            {
                DB.AllUser.Clear();
                return false;
            }

            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            InitDB();
            SQLiteHelper.SetConnectionString(_db, Properties.Settings.Default.password);
            InitGoods();
            InitUser();
            OnSelOutbound();
           // comboBoxOutGoods.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxOutGoods.ItemHeight = 20;
        }
        void InitDB()
        {
            if (!File.Exists(_db))
            {
                FileStream  fs =  File.Create(_db);
                fs.Close();
                SQLiteHelper.SetConnectionString(_db, "");
                SQLiteHelper sh = new SQLiteHelper();
                string sqlgoods = "CREATE TABLE goods (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name NVARCHAR (50), Memo NVARCHAR (200), CrtDate timestamp DEFAULT (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime')), Deleted CHAR DEFAULT F)";
                sh.ExecuteNonQuery(sqlgoods);
                string sqlinbound = "CREATE TABLE inbound (ID INTEGER PRIMARY KEY AUTOINCREMENT, GoodsName nvarchar (100), GoodsID INTEGER, Number INTEGER, CrtDate timestamp DEFAULT (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime')), InDate DATETIME, Deleted CHAR DEFAULT F, UnitPrice INT DEFAULT (0), Memo nvarchar (200), Remaining INT DEFAULT (0))";
                sh.ExecuteNonQuery(sqlinbound);
                string sqloutbount = "CREATE TABLE outbound (ID INTEGER PRIMARY KEY AUTOINCREMENT, User nvarchar (10), UserID INTEGER, GoodsID INTEGER, GoodsName nvarchar (200), Number INTEGER, OutDate DATE, CrtDate timestamp DEFAULT (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime')), UnitPrice INT, Memo nvarchar (200), Deleted CHAR DEFAULT F, InBoundID INTEGER DEFAULT (0))";
                sh.ExecuteNonQuery(sqloutbount);
                string sqluser = "CREATE TABLE user (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name NVARCHAR (10), Age INT, Gender nvarchar (2), Tel nvarchar (12), Address nvarchar (50), Memo nvarchar (200), Deleted CHAR DEFAULT F, CrtData timestamp DEFAULT (strftime('%Y-%m-%d %H:%M:%f', 'now', 'localtime')))";
                sh.ExecuteNonQuery(sqluser);
                string sqlver= "CREATE TABLE Version (Version INT)";
                sh.ExecuteNonQuery(sqlver);
                string sql = "insert into Version(Version ) values(1)";
                sh.ExecuteNonQuery(sql);
                sh.ChangePassword(Properties.Settings.Default.password);
            }



        }
        void UpdateMemUser()
        {
            InitUser();
        }
        private void buttonOutAdd_Click(object sender, EventArgs e)
        {
            String goods = comboBoxOutGoods.Text;
            int needNumber = int.Parse(textBoxOutNumber.Text.ToString());
            String user = comboBoxOutUser.Text;
            int userid = DB.GetUserID(user);
            int goodsid = DB.GetGoodsID(goods);
            string outdate = dateTimePickerOut.Value.ToString("yyyy-MM-dd");
            string memo = textBoxMemo.Text;
            SQLiteHelper sh = new SQLiteHelper();
            string sql = string.Format("select ID,Remaining,UnitPrice,InDate from inbound where GoodsID= {0} and Remaining>0 and Deleted = 'F' order by InDate  ", goodsid);
            DataTable dt = sh.ExecuteQuery(sql);
            int total = 0;

            List<string> allsql = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                int tmp = int.Parse(dr["Remaining"].ToString());
                int unitPrice = int.Parse(dr["UnitPrice"].ToString());
                int id = int.Parse(dr["ID"].ToString());
                total += tmp;
                int decrease = 0;
                if (tmp >= needNumber)
                {
                    decrease = needNumber;
                    needNumber -= needNumber;


                }
                else
                {
                    needNumber -= tmp;
                    decrease = tmp;

                }
                string updateSql = string.Format("update inbound set Remaining = Remaining - {0} where ID = {1}", decrease, dr["ID"].ToString());
                string insertSql = string.Format("insert into outbound (User,UserID,GoodsID,GoodsName,Number,OutDate,Memo,UnitPrice,InBoundID) values ('{0}','{1}',{2},'{3}','{4}','{5}','{6}',{7},{8})",
            user, userid, goodsid, goods, decrease, outdate, memo, unitPrice, id);
                allsql.Add(updateSql);
                allsql.Add(insertSql);
                if (needNumber == 0)
                    break;
            }

            if (needNumber > 0)
            {
                MessageBox.Show(string.Format("库存不足（现有数量:{0})！", total));
                return;
            }

            try
            {
                sh.ExecuteNonQueryBatch(allsql);
            }
            catch (Exception)
            {

                MessageBox.Show("保存失败");
                return;
            }
            updateOutboundGrid();
            MessageBox.Show("保存成功");
           //dateTimePickerOut
           
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;
            int selIndex =  tc.SelectedIndex;
            switch (selIndex)
            {
                case 0:
                    OnSelOutbound();
                    break;
                case 1:
                    OnSelInBound();
                    break;
                case 2:
                    OnSelMaintain();
                    break;
                case 3:
                    OnSelQuery();
                    break;
            }
        }
        void OnSelOutbound()
        {
            comboBoxOutGoods.Items.Clear();
            foreach(Goods g in DB.AllGoods)
            {
               int index =  comboBoxOutGoods.Items.Add(g.name);               
            }
            if (comboBoxOutGoods.Items.Count > 0)
            {
                comboBoxOutGoods.SelectedIndex = 0;
            }
            comboBoxOutUser.Items.Clear();
            foreach (User u in DB.AllUser)
            {
                comboBoxOutUser.Items.Add(u.name);
            }
            if (comboBoxOutUser.Items.Count > 0)
            {
                comboBoxOutUser.SelectedIndex = 0;
            }

            updateOutboundGrid();


        }
        void updateOutboundGrid()
        {
            String date = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            string sql = string.Format("select * from outbound where OutDate >= '{0}' and Deleted = 'F' order by OutDate desc", date);
            SQLiteHelper sh = new SQLiteHelper();
            try
            {
                listViewOutbound.Items.Clear();
                DataTable dt = sh.ExecuteQuery(sql);
               
                string coldate = "";
                int colorIndex = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dr["User"].ToString();
                    lvi.SubItems.Add(dr["GoodsName"].ToString());
                    lvi.SubItems.Add(dr["UnitPrice"].ToString());
                    lvi.SubItems.Add(dr["Number"].ToString());
                    string[] s = dr["OutDate"].ToString().Split(' ');
                    lvi.SubItems.Add(s[0]);
                    lvi.SubItems.Add(dr["Memo"].ToString());
                  ListViewItem newItem=  listViewOutbound.Items.Add(lvi);
                  newItem.Tag = dr["ID"].ToString()+"/"+dr["InBoundID"].ToString();
                    if (coldate.Length == 0)
                        coldate = s[0];
                    if (coldate != s[0] && coldate.Length > 0)
                    {
                        colorIndex *= -1;
                        coldate = s[0];
                    }
                    if (colorIndex == -1)
                    {
                        newItem.BackColor = Color.FromArgb(225, 255, 255);
                    }
                    else
                    {
                        newItem.BackColor = Color.FromArgb(255, 255, 255);
                    }
                   
                }

            }
            catch (Exception)
            {


            }
        }
        void OnSelInBound()
        {
            comboBoxInGoods.Items.Clear();
            foreach (Goods g in DB.AllGoods)
            {
                int index = comboBoxInGoods.Items.Add(g.name);
            }
            if (comboBoxInGoods.Items.Count > 0)
            {
                comboBoxInGoods.SelectedIndex = 0;
            }
            updateInboundGrid();
        }
        void updateInboundGrid()
        {
            listViewInbound.Items.Clear();
            String date = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            string sql = string.Format("select * from inbound where InDate >= '{0}' and Deleted = 'F' order by InDate desc", date);
            SQLiteHelper sh = new SQLiteHelper();
            DataTable dt = sh.ExecuteQuery(sql);
            string coldate = "";
            int colorIndex = 1;
            foreach(DataRow dr in dt.Rows)
            {
                ListViewItem lvi = new ListViewItem ();
                string goodsName = dr["GoodsName"].ToString(); ;
                string id = dr["ID"].ToString();
                string number = dr["Number"].ToString();
                string unitprice = dr["UnitPrice"].ToString();
                string[] t =  dr["InDate"].ToString().Split(' ');
                string indate =t[0];
                string memo = dr["Memo"].ToString();
                lvi.Text = goodsName;
                lvi.SubItems.Add(unitprice);
                lvi.SubItems.Add( number);
                lvi.SubItems.Add( indate);
                lvi.SubItems.Add( memo);
               ListViewItem rlvi =  listViewInbound.Items.Add(lvi);
               rlvi.Tag = id;
               if (coldate.Length == 0)
                   coldate = indate;
               if (coldate != indate && coldate.Length > 0)
               {
                   colorIndex *= -1;
                   coldate = indate;
               }
               if (colorIndex == -1)
               {
                   rlvi.BackColor = Color.FromArgb(225, 255, 255);
               }
               else
               {
                   rlvi.BackColor = Color.FromArgb(255, 255, 255);
               }                   
            }
        }
        void OnSelMaintain()
        {
            UpdateMemGoods();
            UpdateMemUser();

            UpdateGoodsGrid();
            UpdateUserGrid();          
        }
        void UpdateGoodsGrid()
        {
            listViewGoods.Items.Clear();
            int i = 0;
            foreach (Goods gs in DB.AllGoods)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = gs.name;                                        
                lvi.SubItems.Add(gs.memo);
                ListViewItem lr = listViewGoods.Items.Insert(i, lvi);
                lr.Tag = gs.id;
                ++i;
            }
        }
        void UpdateUserGrid()
        {
            int i = 0;
            listViewUser.Items.Clear();           
            foreach (User us in DB.AllUser)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = us.name;
                lvi.SubItems.Add(us.tel);
                ListViewItem lr = listViewUser.Items.Insert(i, lvi);
                lr.Tag = us.id;
                ++i;
            }
        }
        void OnSelQuery()
        {
            dateTimePickerStart.Value =  dateTimePickerStop.Value.AddMonths(-1);
        }

        private void buttonInSave_Click(object sender, EventArgs e)
        {
            string newgoods = comboBoxInGoods.Text;
            int gid = DB.GetGoodsID(newgoods);
            string number = textBoxInNumber.Text.Trim();
            int nnumber = 0;
            try
            {
                nnumber = int.Parse(number);
                if (nnumber < 1)
                    throw new Exception() ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确的数量");
                textBoxInNumber.Focus();
                textBoxInNumber.Select(0, 20);
                return;
            }
            string memo = textBoxInboundMemo.Text;
            string unitPrice = textBoxInUnitPrice.Text.Trim();
            int nunitPrice = 0;           
            try
            {
                nunitPrice = int.Parse(unitPrice);
                if (nunitPrice < 1)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确的价格");
                textBoxInUnitPrice.Focus();
                textBoxInUnitPrice.Select(0, 20);
                return;
            }

            string date = dateTimePickerInbound.Value.ToString("yyyy-MM-dd");            
            string sql1 = string.Format("insert into inbound (GoodsName,GoodsID,InDate,Number,Memo,UnitPrice,Remaining) values('{0}',{1},'{2}',{3},'{4}',{5},{6})",
                newgoods, gid, date, number, memo, nunitPrice, number);
            SQLiteHelper sh = new SQLiteHelper();
            try
            {
                List<string> ls = new List<string>();
               
                ls.Add(sql1);
                sh.ExecuteNonQueryBatch(ls);
            }
            catch (Exception ex)
            {
                MessageBox.Show("入库失败");
                return;
            }
            textBoxInboundMemo.Text = "";
            updateInboundGrid();
           // sh.ExecuteQuery("insert into goods (Name,Memo) values('{0}','{1}')",
        }

        private void buttonGoodsAdd_Click(object sender, EventArgs e)
        {
            GoodsEdit ge = new GoodsEdit();
            if (ge.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            UpdateMemGoods();
            OnSelMaintain();
        }
        void UpdateMemGoods()
        {
            InitGoods();
        }

        private void buttonOutboundDel_Click(object sender, EventArgs e)
        {
            //   listViewOutbound.ind
            ListView.SelectedIndexCollection c = listViewOutbound.SelectedIndices;
            if (c.Count == 0)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            ListViewItem lvi = listViewOutbound.Items[c[0]];
            string user = lvi.Text, goods = lvi.SubItems[1].Text.ToString(),
                number = lvi.SubItems[2].Text.ToString(), date = lvi.SubItems[3].Text.ToString();
            int goodsid =  DB.GetGoodsID(goods);
            string text = string.Format("您确定要取消   {0},{1},{2}?", user, date, goods);
            if (MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            string [] outinid  = listViewOutbound.Items[c[0]].Tag.ToString().Split('/');
            string sql1 = string.Format("update outbound set Deleted = 'T' where ID={0}", outinid[0]);
            string sql2 = string.Format("update inbound set Remaining=Remaining+{0} where ID={1}", number, outinid[1]);
            SQLiteHelper sh = new SQLiteHelper();
            List<string> ls = new List<string> ();
            ls.Add(sql1);
            ls.Add(sql2);
            try
            {
                sh.ExecuteNonQueryBatch(ls);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
                return;
            }
            listViewOutbound.Items.Remove(lvi);
        }

        private void buttonInboundDel_Click(object sender, EventArgs e)
        {

            ListView.SelectedIndexCollection c = listViewInbound.SelectedIndices;
            if (c.Count == 0)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            ListViewItem lvi = listViewInbound.Items[c[0]];
            string goods = lvi.Text, number = lvi.SubItems[1].Text.ToString(),
                date = lvi.SubItems[2].Text.ToString();
            int goodsid = DB.GetGoodsID(goods);
            string text = string.Format("您确定要取消此条入库信息({0},{1})", goods,date);
            if (MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            SQLiteHelper sh = new SQLiteHelper();
            string inboundID = listViewInbound.Items[c[0]].Tag.ToString();

            string sql = string.Format("select ID from outbound where InBoundID = {0}", inboundID);

            DataTable dt =  sh.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(string.Format("此条入库记录已被出库，禁止删除"));
                return;
            }

            string sql1 = string.Format("update inbound set Deleted = 'T' where ID={0}", inboundID);
           
           
            List<string> ls = new List<string>();
            ls.Add(sql1);
           
            try
            {
                sh.ExecuteNonQueryBatch(ls);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
                return;
            }
            listViewInbound.Items.Remove(lvi);
        }

        private void buttonGoodsDel_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection c = listViewGoods.SelectedIndices;
            if (c.Count == 0)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            ListViewItem lvi = listViewGoods.Items[c[0]];
            
            int id = (int)lvi.Tag;
            if (MessageBox.Show(string.Format("确定要删除'{0}'?", lvi.Text), "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                return;
            string sql = string.Format("update goods set Deleted = 'T' where id = {0}", id);
            SQLiteHelper sh = new SQLiteHelper();
            sh.ExecuteNonQuery(sql);
            UpdateMemGoods();
            listViewGoods.Items.Remove(lvi);
        }

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            UserEdit ue = new UserEdit();
            ue.ShowDialog();
            UpdateMemUser();
            OnSelMaintain();
        }

        private void buttonUserDel_Click(object sender, EventArgs e)
        {

            ListView.SelectedIndexCollection c = listViewUser.SelectedIndices;
            if (c.Count == 0)
            {
                MessageBox.Show("请选择一行");
                return;
            }
            ListViewItem lvi = listViewUser.Items[c[0]];
            int id = (int)lvi.Tag;
            if (MessageBox.Show(string.Format("确定要删除'{0}'?", lvi.Text), "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                return;
            string sql = string.Format("update user set Deleted = 'T' where id = {0}", id);
            SQLiteHelper sh = new SQLiteHelper();
            sh.ExecuteNonQuery(sql);
            UpdateMemUser();
            listViewUser.Items.Remove(lvi);
        }

        private void label13_Click(object sender, EventArgs e)
        {
             
        }

        private void buttonStaticStart_Click(object sender, EventArgs e)
        {
            _exportUse = null;
            listViewStatic.Items.Clear();
            SQLiteHelper sh = new SQLiteHelper ();
            string date1 = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
            string date2 = dateTimePickerStop.Value.ToString("yyyy-MM-dd");
            _exportUse = sh.ExecuteQuery(string.Format("select * from outbound where date(OutDate)>='{0}' and date(OutDate)<='{1}' order by User desc,OutDate ", date1, date2));
            string user = "";
            int number = 0;
            int price = 0;
            foreach (DataRow dr in _exportUse.Rows)
            {
                string tmpuser =  dr["User"].ToString();
                if (user == "")
                    user = tmpuser;
                if (user != tmpuser)
                {
                    ListViewItem tlvi = new ListViewItem();
                    tlvi.Text = ""; tlvi.SubItems.Add(""); tlvi.SubItems.Add(string.Format("{0}", number));
                    tlvi.SubItems.Add(string.Format("{0}", price));
                  ListViewItem rlvi =  listViewStatic.Items.Add(tlvi);
                  rlvi.BackColor = Color.FromArgb(187, 255, 255);
                    number = 0;
                    price = 0;
                    user = tmpuser;
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = dr["User"].ToString();
                lvi.SubItems.Add(dr["GoodsName"].ToString());
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["UnitPrice"].ToString());
                string[] d1= dr["OutDate"].ToString().Split(' ');
                lvi.SubItems.Add(d1[0]);
                listViewStatic.Items.Add(lvi);
                int tmpNumber = int.Parse(dr["Number"].ToString());
                int tmpPrice = int.Parse(dr["UnitPrice"].ToString());
                number += tmpNumber;
                price += tmpPrice * tmpNumber;
            }
            ListViewItem tlvi1 = new ListViewItem();
            tlvi1 = new ListViewItem();
            tlvi1.Text = ""; tlvi1.SubItems.Add(""); tlvi1.SubItems.Add(string.Format("{0}", number));
            tlvi1.SubItems.Add(string.Format("{0}", price));
            ListViewItem rlvi1 = listViewStatic.Items.Add(tlvi1);
            rlvi1.BackColor = Color.FromArgb(187,255, 255);

            listViewRemain.Items.Clear();
            string sql = string.Format("select GoodsName ,sum(Remaining) as Remain from inbound  where Deleted = 'F' and Remaining >0 and date(CrtDate)>='{0}' and date(CrtDate)<='{1}' group by GoodsName", date1, date2);
           _exportRemaining =  sh.ExecuteQuery(sql);
           foreach(DataRow dr in _exportRemaining.Rows)
           {
               ListViewItem vi = new ListViewItem();
               vi.Text = dr["GoodsName"].ToString();
               vi.SubItems.Add(dr["Remain"].ToString());
               listViewRemain.Items.Add(vi);
           }
            
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (_exportRemaining == null || _exportUse == null)
            {
                MessageBox.Show("请先统计，然后再导出");
                return;
            }
            NOPIHelper helper = new NOPIHelper();
            helper.Create();
            string user = "";
            int number = 0;
            int price = 0; 
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            IFont font = null;
            ICellStyle csTitle = null;
            ICellStyle csText = null;
            foreach (DataRow dr in _exportUse.Rows)
            {
                string tmpuser = dr["User"].ToString();
               
                if (user == "" || user != tmpuser)
                {
                    if (user.Length>0 && user != tmpuser)
                    {
                        row = helper.CreateRow(sheet);
                        cell = helper.CreateCell(row);
                        cell = helper.CreateCell(row);
                        cell = helper.CreateCell(row);
                        cell.SetCellValue(number);

                        cell = helper.CreateCell(row);
                        cell.SetCellValue(price);
                    }
                    number = 0;
                    price = 0;
                    user = tmpuser;
                    sheet = helper.CreateSheet(tmpuser);
                    row =  helper.CreateRow(sheet);
                    cell =  helper.CreateCell(row);
                     font = helper.WorkBook.CreateFont();
                    font.IsBold = true;
                    font.FontHeightInPoints = 12;
                     csTitle =  helper.WorkBook.CreateCellStyle();
                    csTitle.SetFont(font);
                    csTitle.VerticalAlignment = VerticalAlignment.Center;
                    cell.CellStyle = csTitle;
                    cell.SetCellValue("使用人");
                    cell = helper.CreateCell(row);
                    cell.CellStyle = csTitle;
                    cell.SetCellValue("货品");
                    cell = helper.CreateCell(row);
                    cell.CellStyle = csTitle;
                    cell.SetCellValue("数量");
                    cell = helper.CreateCell(row);
                    cell.CellStyle = csTitle;
                    cell.SetCellValue("单价");
                    cell = helper.CreateCell(row);
                    cell.CellStyle = csTitle;
                    cell.SetCellValue("出库日期");
                  
                }
                font = helper.WorkBook.CreateFont();
                font.IsBold = false;
                font.FontHeightInPoints = 11;
                csText = helper.WorkBook.CreateCellStyle();
                csText.SetFont(font);
                 row = helper.CreateRow(sheet);
                 cell = helper.CreateCell(row);

                 cell.CellStyle = csText;
                 cell.SetCellValue(dr["User"].ToString());
                 cell = helper.CreateCell(row);
                 cell.CellStyle = csText;
                 cell.SetCellValue(dr["GoodsName"].ToString());
                 cell = helper.CreateCell(row);
                 cell.CellStyle = csText;
                 cell.SetCellValue(dr["Number"].ToString());

                 cell = helper.CreateCell(row);
                 cell.CellStyle = csText;
                 cell.SetCellValue(dr["UnitPrice"].ToString());
                 cell = helper.CreateCell(row);
                 cell.CellStyle = csText;
                 cell.SetCellValue(dr["OutDate"].ToString().Split(' ')[0]);

                 int tmpNumber = int.Parse(dr["Number"].ToString());
                 int tmpPrice = int.Parse(dr["UnitPrice"].ToString());

                 number += tmpNumber;
                 price += tmpNumber * tmpPrice;
            }
            row = helper.CreateRow(sheet);
            cell = helper.CreateCell(row);
            cell = helper.CreateCell(row);
            cell = helper.CreateCell(row);
            cell.SetCellValue(number);
            
            cell = helper.CreateCell(row);
            cell.SetCellValue(price);

            sheet =  helper.CreateSheet("库存统计");
            row=  helper.CreateRow(sheet);
            cell = helper.CreateCell(row);
            cell.CellStyle = csTitle;
            cell.SetCellValue("货品");
            cell = helper.CreateCell(row);
            cell.CellStyle = csTitle;
            cell.SetCellValue("库存结余");
            foreach (DataRow dr in _exportRemaining.Rows)
            {
                row = helper.CreateRow(sheet);
                cell = helper.CreateCell(row);
                cell.CellStyle = csText;
                cell.SetCellValue(dr["GoodsName"].ToString());
                cell = helper.CreateCell(row);
                cell.CellStyle = csText;
                cell.SetCellValue(dr["Remain"].ToString());
            }

            string path = AppDomain.CurrentDomain.BaseDirectory + "导出";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string date1 = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
            string date2 = dateTimePickerStop.Value.ToString("yyyy-MM-dd");
            string date = date1 +"~"+ date2;
            helper.Save(path+"\\出库统计"+date+".xls");
            MessageBox.Show("导出成功");
        }

     

     

      
      
    }
}
