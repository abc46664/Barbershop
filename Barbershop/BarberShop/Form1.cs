using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BarberShop
{
    public partial class Form1 : Form
    {
        string _db = "";
        public Form1()
        {
            InitializeComponent();
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
                    g.number = int.Parse(item["Number"].ToString());
                    g.id = int.Parse(item["ID"].ToString());
                    g.price = int.Parse(item["Price"].ToString());
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
            _db = AppDomain.CurrentDomain.BaseDirectory+"barbershop.db";
            SQLiteHelper.SetConnectionString(_db, "test");
            InitGoods();
            InitUser();
            OnSelOutbound();
           // comboBoxOutGoods.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxOutGoods.ItemHeight = 20;
        }

        private void buttonOutAdd_Click(object sender, EventArgs e)
        {
           String goods =  comboBoxOutGoods.Text;
           int number = int.Parse(textBoxOutNumber.Text.ToString());
           String user = comboBoxOutUser.Text;
            int userid = DB.GetUserID(user);
            int goodsid = DB.GetGoodsID(goods);
            string outdate = dateTimePickerOut.Value.ToString("yyyy-MM-dd");
           string memo = textBoxMemo.Text;
            string sql = string.Format("insert into outbound (User,UserID,GoodsID,GoodsName,Number,OutDate,Memo) values ('{0}','{1}',{2},'{3}','{4}','{5}','{6}')",
                user,userid,goodsid,goods,number,outdate,memo);
            SQLiteHelper sh = new SQLiteHelper();
            try
            {
                sh.ExecuteNonQuery(sql);
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
                    break;
                case 2:
                    OnSelMaintain();
                    break;
                case 3:
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
            string sql = string.Format("select * from outbound where OutDate >= '{0}' order by OutDate desc", date);
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
                    lvi.SubItems.Add(dr["Number"].ToString());
                    string[] s = dr["OutDate"].ToString().Split(' ');
                    lvi.SubItems.Add(s[0]);
                    lvi.SubItems.Add(dr["Memo"].ToString());
                  ListViewItem newItem=  listViewOutbound.Items.Add(lvi);
                  newItem.Tag = dr["ID"];
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
        }
        void OnSelMaintain()
        {
            listViewGoods.Items.Clear();
            int i = 0;
            foreach (Goods gs in DB.AllGoods)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = gs.name;
                lvi.SubItems.Add(string.Format("{0}", gs.price));
                lvi.SubItems.Add(gs.memo);
                ListViewItem lr = listViewGoods.Items.Insert(i, lvi);
                lr.Tag = gs.id;
                ++i;
            }

            listViewUser.Items.Clear();
            i = 0;
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
        }

        private void buttonInSave_Click(object sender, EventArgs e)
        {
            string newgoods = comboBoxInGoods.Text;
           
           // sh.ExecuteQuery("insert into goods (Name,Memo) values('{0}','{1}')",
        }

        private void buttonGoodsAdd_Click(object sender, EventArgs e)
        {
            GoodsEdit ge = new GoodsEdit();
            if (ge.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            UpdateGoods();
            OnSelMaintain();
        }
        void UpdateGoods()
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
                  string user = listViewOutbound.Items[c[0]].Text,
                      goods = listViewOutbound.Items[c[0]].SubItems[1].Text.ToString(),
            number = listViewOutbound.Items[c[0]].SubItems[2].Text.ToString(),
            date = listViewOutbound.Items[c[0]].SubItems[3].Text.ToString();
            string text = string.Format("您确定要删除   {0}在{1}出库的{2}?",user,date,goods);
            MessageBox.Show(text);
                  string mediaRtspUrl = listViewOutbound.Items[c[0]].Tag.ToString();
        }

      
    }
}
