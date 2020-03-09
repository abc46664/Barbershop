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
    public partial class GoodsEdit : Form
    {
        bool _bEdit = false;
        string _name = "";
        string _memo = "";
        public GoodsEdit()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            if (name.Length < 1)
            {
                MessageBox.Show("请输入商品名");
                textBoxName.Focus();
                return;
            }
            SQLiteHelper sh = new SQLiteHelper();
            if (_bEdit)
            {
               
            }
            else
            {
                string sql = string.Format("select ID from goods where Name like '{0}' and Deleted =='F'", name);
                DataTable dt = sh.ExecuteQuery(sql);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("该货品已存在");
                    textBoxName.Focus();
                    return;
                }
                sql = string.Format("insert into goods (Name,Memo,Price) values('{0}','{1}',{2})", name, textBoxMemo.Text.ToString(),textBoxprice.Text.ToString());
                try
                {
                    sh.ExecuteNonQuery(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增货品失败。");
                    return;
                }
                MessageBox.Show("保存成功。");
            }
            //DialogResult = System.Windows.Forms.DialogResult.OK;
            //Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void GoodsEdit_Load(object sender, EventArgs e)
        {
            textBoxName.Focus();
            if (_bEdit)
            {
                textBoxName.Text = _name;
                textBoxMemo.Text = _memo;
            }
        }
    }
}
