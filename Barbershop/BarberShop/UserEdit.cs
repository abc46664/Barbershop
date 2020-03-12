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
    public partial class UserEdit : Form
    {
        public UserEdit()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.ToString().Trim();
            if (name.Length < 1)
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            SQLiteHelper sh = new SQLiteHelper();
            string check = string.Format("select ID from user where Name = '{0}'", name);
            DataTable dt = sh.ExecuteQuery(check);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("用户已存在");
                return;
            }
            string tel = textBoxTel.Text.ToString();
            string memo = textBoxMemo.Text.ToString();
            string sql = string.Format("insert into user(Name,Tel,Memo) values('{0}','{1}','{2}')",name,tel,memo);
           
            sh.ExecuteNonQuery(sql);
            MessageBox.Show("增加成功");
        }

      
    }
}
