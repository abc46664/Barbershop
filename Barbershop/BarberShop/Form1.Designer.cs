namespace BarberShop
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.outbound = new System.Windows.Forms.TabPage();
            this.buttonOutboundDel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMemo = new System.Windows.Forms.TextBox();
            this.buttonOutAdd = new System.Windows.Forms.Button();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.textBoxOutNumber = new System.Windows.Forms.TextBox();
            this.comboBoxOutUser = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOutGoods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewOutbound = new System.Windows.Forms.ListView();
            this.chOutUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOutGoods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOutNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOutDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inbound = new System.Windows.Forms.TabPage();
            this.buttonInboundDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxInboundMemo = new System.Windows.Forms.TextBox();
            this.buttonInSave = new System.Windows.Forms.Button();
            this.dateTimePickerInbound = new System.Windows.Forms.DateTimePicker();
            this.textBoxInNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxInGoods = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewInbound = new System.Windows.Forms.ListView();
            this.chInboundGoods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInboundNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInboundDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInboundMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maintain = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listViewUser = new System.Windows.Forms.ListView();
            this.chUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserTel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUserMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonUserDel = new System.Windows.Forms.Button();
            this.buttonUserAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewGoods = new System.Windows.Forms.ListView();
            this.chGoodsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGoodsPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chGoodsMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonGoodsDel = new System.Windows.Forms.Button();
            this.buttonGoodsAdd = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TabPage();
            this.chGoodsTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelDatetime = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.outbound.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.inbound.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.maintain.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.outbound);
            this.tabControlMain.Controls.Add(this.inbound);
            this.tabControlMain.Controls.Add(this.maintain);
            this.tabControlMain.Controls.Add(this.search);
            this.tabControlMain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlMain.Location = new System.Drawing.Point(13, 13);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(988, 572);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // outbound
            // 
            this.outbound.Controls.Add(this.label11);
            this.outbound.Controls.Add(this.buttonOutboundDel);
            this.outbound.Controls.Add(this.groupBox1);
            this.outbound.Controls.Add(this.listViewOutbound);
            this.outbound.Location = new System.Drawing.Point(4, 26);
            this.outbound.Name = "outbound";
            this.outbound.Padding = new System.Windows.Forms.Padding(3);
            this.outbound.Size = new System.Drawing.Size(980, 542);
            this.outbound.TabIndex = 0;
            this.outbound.Text = "出库";
            this.outbound.UseVisualStyleBackColor = true;
            // 
            // buttonOutboundDel
            // 
            this.buttonOutboundDel.Location = new System.Drawing.Point(227, 498);
            this.buttonOutboundDel.Name = "buttonOutboundDel";
            this.buttonOutboundDel.Size = new System.Drawing.Size(91, 33);
            this.buttonOutboundDel.TabIndex = 5;
            this.buttonOutboundDel.Text = "删除";
            this.buttonOutboundDel.UseVisualStyleBackColor = true;
            this.buttonOutboundDel.Click += new System.EventHandler(this.buttonOutboundDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMemo);
            this.groupBox1.Controls.Add(this.buttonOutAdd);
            this.groupBox1.Controls.Add(this.dateTimePickerOut);
            this.groupBox1.Controls.Add(this.textBoxOutNumber);
            this.groupBox1.Controls.Add(this.comboBoxOutUser);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxOutGoods);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(653, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 394);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增出库";
            // 
            // textBoxMemo
            // 
            this.textBoxMemo.Location = new System.Drawing.Point(110, 253);
            this.textBoxMemo.Multiline = true;
            this.textBoxMemo.Name = "textBoxMemo";
            this.textBoxMemo.Size = new System.Drawing.Size(157, 77);
            this.textBoxMemo.TabIndex = 6;
            // 
            // buttonOutAdd
            // 
            this.buttonOutAdd.Location = new System.Drawing.Point(110, 349);
            this.buttonOutAdd.Name = "buttonOutAdd";
            this.buttonOutAdd.Size = new System.Drawing.Size(80, 28);
            this.buttonOutAdd.TabIndex = 5;
            this.buttonOutAdd.Tag = "";
            this.buttonOutAdd.Text = "确定";
            this.buttonOutAdd.UseVisualStyleBackColor = true;
            this.buttonOutAdd.Click += new System.EventHandler(this.buttonOutAdd_Click);
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.Location = new System.Drawing.Point(110, 197);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.Size = new System.Drawing.Size(157, 26);
            this.dateTimePickerOut.TabIndex = 4;
            // 
            // textBoxOutNumber
            // 
            this.textBoxOutNumber.Location = new System.Drawing.Point(110, 144);
            this.textBoxOutNumber.Name = "textBoxOutNumber";
            this.textBoxOutNumber.Size = new System.Drawing.Size(157, 26);
            this.textBoxOutNumber.TabIndex = 3;
            this.textBoxOutNumber.Text = "1";
            // 
            // comboBoxOutUser
            // 
            this.comboBoxOutUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutUser.FormattingEnabled = true;
            this.comboBoxOutUser.Location = new System.Drawing.Point(110, 86);
            this.comboBoxOutUser.Name = "comboBoxOutUser";
            this.comboBoxOutUser.Size = new System.Drawing.Size(157, 24);
            this.comboBoxOutUser.Sorted = true;
            this.comboBoxOutUser.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 1;
            this.label7.Tag = "";
            this.label7.Text = "备注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 1;
            this.label4.Tag = "";
            this.label4.Text = "日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "使用人";
            // 
            // comboBoxOutGoods
            // 
            this.comboBoxOutGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutGoods.FormattingEnabled = true;
            this.comboBoxOutGoods.ItemHeight = 16;
            this.comboBoxOutGoods.Location = new System.Drawing.Point(110, 33);
            this.comboBoxOutGoods.Name = "comboBoxOutGoods";
            this.comboBoxOutGoods.Size = new System.Drawing.Size(157, 24);
            this.comboBoxOutGoods.Sorted = true;
            this.comboBoxOutGoods.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "货品";
            // 
            // listViewOutbound
            // 
            this.listViewOutbound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOutUser,
            this.chOutGoods,
            this.chOutNumber,
            this.chOutDate,
            this.chMemo});
            this.listViewOutbound.FullRowSelect = true;
            this.listViewOutbound.GridLines = true;
            this.listViewOutbound.Location = new System.Drawing.Point(20, 46);
            this.listViewOutbound.Name = "listViewOutbound";
            this.listViewOutbound.Size = new System.Drawing.Size(600, 445);
            this.listViewOutbound.TabIndex = 0;
            this.listViewOutbound.UseCompatibleStateImageBehavior = false;
            this.listViewOutbound.View = System.Windows.Forms.View.Details;
            // 
            // chOutUser
            // 
            this.chOutUser.Text = "使用人";
            this.chOutUser.Width = 100;
            // 
            // chOutGoods
            // 
            this.chOutGoods.Text = "货品";
            this.chOutGoods.Width = 150;
            // 
            // chOutNumber
            // 
            this.chOutNumber.Text = "数量";
            this.chOutNumber.Width = 80;
            // 
            // chOutDate
            // 
            this.chOutDate.Text = "日期";
            this.chOutDate.Width = 130;
            // 
            // chMemo
            // 
            this.chMemo.Text = "备注";
            this.chMemo.Width = 130;
            // 
            // inbound
            // 
            this.inbound.Controls.Add(this.buttonInboundDel);
            this.inbound.Controls.Add(this.groupBox2);
            this.inbound.Controls.Add(this.listViewInbound);
            this.inbound.Controls.Add(this.label10);
            this.inbound.Location = new System.Drawing.Point(4, 26);
            this.inbound.Name = "inbound";
            this.inbound.Padding = new System.Windows.Forms.Padding(3);
            this.inbound.Size = new System.Drawing.Size(980, 542);
            this.inbound.TabIndex = 1;
            this.inbound.Text = "入库";
            this.inbound.UseVisualStyleBackColor = true;
            // 
            // buttonInboundDel
            // 
            this.buttonInboundDel.Location = new System.Drawing.Point(227, 498);
            this.buttonInboundDel.Name = "buttonInboundDel";
            this.buttonInboundDel.Size = new System.Drawing.Size(119, 39);
            this.buttonInboundDel.TabIndex = 6;
            this.buttonInboundDel.Text = "删除";
            this.buttonInboundDel.UseVisualStyleBackColor = true;
            this.buttonInboundDel.Click += new System.EventHandler(this.buttonInboundDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxInboundMemo);
            this.groupBox2.Controls.Add(this.buttonInSave);
            this.groupBox2.Controls.Add(this.dateTimePickerInbound);
            this.groupBox2.Controls.Add(this.textBoxInNumber);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBoxInGoods);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(653, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 445);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "新增入库";
            // 
            // textBoxInboundMemo
            // 
            this.textBoxInboundMemo.Location = new System.Drawing.Point(109, 206);
            this.textBoxInboundMemo.Multiline = true;
            this.textBoxInboundMemo.Name = "textBoxInboundMemo";
            this.textBoxInboundMemo.Size = new System.Drawing.Size(157, 153);
            this.textBoxInboundMemo.TabIndex = 6;
            // 
            // buttonInSave
            // 
            this.buttonInSave.Location = new System.Drawing.Point(110, 390);
            this.buttonInSave.Name = "buttonInSave";
            this.buttonInSave.Size = new System.Drawing.Size(80, 28);
            this.buttonInSave.TabIndex = 5;
            this.buttonInSave.Tag = "";
            this.buttonInSave.Text = "确定";
            this.buttonInSave.UseVisualStyleBackColor = true;
            this.buttonInSave.Click += new System.EventHandler(this.buttonInSave_Click);
            // 
            // dateTimePickerInbound
            // 
            this.dateTimePickerInbound.Location = new System.Drawing.Point(110, 144);
            this.dateTimePickerInbound.Name = "dateTimePickerInbound";
            this.dateTimePickerInbound.Size = new System.Drawing.Size(157, 26);
            this.dateTimePickerInbound.TabIndex = 4;
            // 
            // textBoxInNumber
            // 
            this.textBoxInNumber.Location = new System.Drawing.Point(110, 91);
            this.textBoxInNumber.Name = "textBoxInNumber";
            this.textBoxInNumber.Size = new System.Drawing.Size(157, 26);
            this.textBoxInNumber.TabIndex = 3;
            this.textBoxInNumber.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 1;
            this.label9.Tag = "";
            this.label9.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 1;
            this.label5.Tag = "";
            this.label5.Text = "日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "数量";
            // 
            // comboBoxInGoods
            // 
            this.comboBoxInGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInGoods.FormattingEnabled = true;
            this.comboBoxInGoods.Location = new System.Drawing.Point(110, 33);
            this.comboBoxInGoods.Name = "comboBoxInGoods";
            this.comboBoxInGoods.Size = new System.Drawing.Size(157, 24);
            this.comboBoxInGoods.Sorted = true;
            this.comboBoxInGoods.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "货品";
            // 
            // listViewInbound
            // 
            this.listViewInbound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chInboundGoods,
            this.chInboundNumber,
            this.chInboundDate,
            this.chInboundMemo});
            this.listViewInbound.FullRowSelect = true;
            this.listViewInbound.GridLines = true;
            this.listViewInbound.Location = new System.Drawing.Point(20, 46);
            this.listViewInbound.Name = "listViewInbound";
            this.listViewInbound.Size = new System.Drawing.Size(600, 445);
            this.listViewInbound.TabIndex = 0;
            this.listViewInbound.UseCompatibleStateImageBehavior = false;
            this.listViewInbound.View = System.Windows.Forms.View.Details;
            // 
            // chInboundGoods
            // 
            this.chInboundGoods.Text = "货品";
            this.chInboundGoods.Width = 150;
            // 
            // chInboundNumber
            // 
            this.chInboundNumber.Text = "数量";
            this.chInboundNumber.Width = 70;
            // 
            // chInboundDate
            // 
            this.chInboundDate.Text = "日期";
            this.chInboundDate.Width = 120;
            // 
            // chInboundMemo
            // 
            this.chInboundMemo.Text = "备注";
            this.chInboundMemo.Width = 200;
            // 
            // maintain
            // 
            this.maintain.Controls.Add(this.groupBox4);
            this.maintain.Controls.Add(this.groupBox3);
            this.maintain.Location = new System.Drawing.Point(4, 26);
            this.maintain.Name = "maintain";
            this.maintain.Size = new System.Drawing.Size(980, 542);
            this.maintain.TabIndex = 2;
            this.maintain.Text = "维护";
            this.maintain.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewUser);
            this.groupBox4.Controls.Add(this.buttonUserDel);
            this.groupBox4.Controls.Add(this.buttonUserAdd);
            this.groupBox4.Location = new System.Drawing.Point(490, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(470, 508);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "使用人信息";
            // 
            // listViewUser
            // 
            this.listViewUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chUserName,
            this.chUserTel,
            this.chUserMemo});
            this.listViewUser.FullRowSelect = true;
            this.listViewUser.GridLines = true;
            this.listViewUser.HideSelection = false;
            this.listViewUser.Location = new System.Drawing.Point(34, 32);
            this.listViewUser.Name = "listViewUser";
            this.listViewUser.Size = new System.Drawing.Size(409, 397);
            this.listViewUser.TabIndex = 2;
            this.listViewUser.UseCompatibleStateImageBehavior = false;
            this.listViewUser.View = System.Windows.Forms.View.Details;
            // 
            // chUserName
            // 
            this.chUserName.Text = "姓名";
            this.chUserName.Width = 100;
            // 
            // chUserTel
            // 
            this.chUserTel.Text = "电话";
            this.chUserTel.Width = 150;
            // 
            // chUserMemo
            // 
            this.chUserMemo.Text = "备注";
            this.chUserMemo.Width = 150;
            // 
            // buttonUserDel
            // 
            this.buttonUserDel.Location = new System.Drawing.Point(295, 449);
            this.buttonUserDel.Name = "buttonUserDel";
            this.buttonUserDel.Size = new System.Drawing.Size(73, 35);
            this.buttonUserDel.TabIndex = 1;
            this.buttonUserDel.Text = "删除";
            this.buttonUserDel.UseVisualStyleBackColor = true;
            this.buttonUserDel.Click += new System.EventHandler(this.buttonUserDel_Click);
            // 
            // buttonUserAdd
            // 
            this.buttonUserAdd.Location = new System.Drawing.Point(129, 449);
            this.buttonUserAdd.Name = "buttonUserAdd";
            this.buttonUserAdd.Size = new System.Drawing.Size(73, 35);
            this.buttonUserAdd.TabIndex = 1;
            this.buttonUserAdd.Text = "增加";
            this.buttonUserAdd.UseVisualStyleBackColor = true;
            this.buttonUserAdd.Click += new System.EventHandler(this.buttonUserAdd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewGoods);
            this.groupBox3.Controls.Add(this.buttonGoodsDel);
            this.groupBox3.Controls.Add(this.buttonGoodsAdd);
            this.groupBox3.Location = new System.Drawing.Point(9, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 509);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "货品信息";
            // 
            // listViewGoods
            // 
            this.listViewGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGoodsName,
            this.chGoodsTotal,
            this.chGoodsPrice,
            this.chGoodsMemo});
            this.listViewGoods.FullRowSelect = true;
            this.listViewGoods.GridLines = true;
            this.listViewGoods.HideSelection = false;
            this.listViewGoods.Location = new System.Drawing.Point(23, 35);
            this.listViewGoods.Name = "listViewGoods";
            this.listViewGoods.Size = new System.Drawing.Size(409, 397);
            this.listViewGoods.TabIndex = 2;
            this.listViewGoods.UseCompatibleStateImageBehavior = false;
            this.listViewGoods.View = System.Windows.Forms.View.Details;
            // 
            // chGoodsName
            // 
            this.chGoodsName.Text = "名称";
            this.chGoodsName.Width = 150;
            // 
            // chGoodsPrice
            // 
            this.chGoodsPrice.Text = "价格";
            this.chGoodsPrice.Width = 70;
            // 
            // chGoodsMemo
            // 
            this.chGoodsMemo.Text = "备注";
            this.chGoodsMemo.Width = 120;
            // 
            // buttonGoodsDel
            // 
            this.buttonGoodsDel.Location = new System.Drawing.Point(271, 458);
            this.buttonGoodsDel.Name = "buttonGoodsDel";
            this.buttonGoodsDel.Size = new System.Drawing.Size(73, 35);
            this.buttonGoodsDel.TabIndex = 1;
            this.buttonGoodsDel.Text = "删除";
            this.buttonGoodsDel.UseVisualStyleBackColor = true;
            this.buttonGoodsDel.Click += new System.EventHandler(this.buttonGoodsDel_Click);
            // 
            // buttonGoodsAdd
            // 
            this.buttonGoodsAdd.Location = new System.Drawing.Point(117, 458);
            this.buttonGoodsAdd.Name = "buttonGoodsAdd";
            this.buttonGoodsAdd.Size = new System.Drawing.Size(73, 35);
            this.buttonGoodsAdd.TabIndex = 1;
            this.buttonGoodsAdd.Text = "增加";
            this.buttonGoodsAdd.UseVisualStyleBackColor = true;
            this.buttonGoodsAdd.Click += new System.EventHandler(this.buttonGoodsAdd_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(4, 26);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(980, 542);
            this.search.TabIndex = 3;
            this.search.Text = "查询";
            this.search.UseVisualStyleBackColor = true;
            // 
            // chGoodsTotal
            // 
            this.chGoodsTotal.Text = "库存";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "最近七天明细：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "最近七天明细：";
            // 
            // labelDatetime
            // 
            this.labelDatetime.AutoSize = true;
            this.labelDatetime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDatetime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelDatetime.Location = new System.Drawing.Point(809, 13);
            this.labelDatetime.Name = "labelDatetime";
            this.labelDatetime.Size = new System.Drawing.Size(188, 16);
            this.labelDatetime.TabIndex = 1;
            this.labelDatetime.Text = "2019-03-10  20:36:48";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 597);
            this.Controls.Add(this.labelDatetime);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易出入库管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.outbound.ResumeLayout(false);
            this.outbound.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.inbound.ResumeLayout(false);
            this.inbound.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.maintain.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage outbound;
        private System.Windows.Forms.TabPage inbound;
        private System.Windows.Forms.ListView listViewInbound;
        private System.Windows.Forms.TabPage maintain;
        private System.Windows.Forms.ListView listViewOutbound;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOutAdd;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.TextBox textBoxOutNumber;
        private System.Windows.Forms.ComboBox comboBoxOutUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOutGoods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonInSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerInbound;
        private System.Windows.Forms.TextBox textBoxInNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxInGoods;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage search;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonUserDel;
        private System.Windows.Forms.Button buttonUserAdd;
        private System.Windows.Forms.Button buttonGoodsDel;
        private System.Windows.Forms.Button buttonGoodsAdd;
        private System.Windows.Forms.ListView listViewUser;
        private System.Windows.Forms.ListView listViewGoods;
        private System.Windows.Forms.ColumnHeader chGoodsName;
        private System.Windows.Forms.ColumnHeader chGoodsMemo;
        private System.Windows.Forms.ColumnHeader chUserName;
        private System.Windows.Forms.ColumnHeader chUserTel;
        private System.Windows.Forms.ColumnHeader chOutUser;
        private System.Windows.Forms.ColumnHeader chOutGoods;
        private System.Windows.Forms.ColumnHeader chOutNumber;
        private System.Windows.Forms.ColumnHeader chOutDate;
        private System.Windows.Forms.ColumnHeader chMemo;
        private System.Windows.Forms.TextBox textBoxMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader chGoodsPrice;
        private System.Windows.Forms.ColumnHeader chUserMemo;
        private System.Windows.Forms.Button buttonOutboundDel;
        private System.Windows.Forms.ColumnHeader chInboundGoods;
        private System.Windows.Forms.ColumnHeader chInboundNumber;
        private System.Windows.Forms.ColumnHeader chInboundDate;
        private System.Windows.Forms.ColumnHeader chInboundMemo;
        private System.Windows.Forms.TextBox textBoxInboundMemo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonInboundDel;
        private System.Windows.Forms.ColumnHeader chGoodsTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelDatetime;
    }
}

