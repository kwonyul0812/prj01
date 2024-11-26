namespace prj01
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ScComboBox = new System.Windows.Forms.ComboBox();
            this.McComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtClearBtn = new System.Windows.Forms.Button();
            this.addCartBtn = new System.Windows.Forms.Button();
            this.priceTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.countTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.itemNameTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.scNameTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.itemNoTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buyBtn = new System.Windows.Forms.Button();
            this.clearCDBtn = new System.Windows.Forms.Button();
            this.deleteCDBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(730, 326);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchTextBox);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ScComboBox);
            this.groupBox1.Controls.Add(this.McComboBox);
            this.groupBox1.Location = new System.Drawing.Point(45, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(422, 50);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(187, 28);
            this.SearchTextBox.TabIndex = 7;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(626, 46);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(103, 33);
            this.SearchBtn.TabIndex = 6;
            this.SearchBtn.Text = "조회";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "상품명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "소분류";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "대분류";
            // 
            // ScComboBox
            // 
            this.ScComboBox.FormattingEnabled = true;
            this.ScComboBox.Location = new System.Drawing.Point(120, 67);
            this.ScComboBox.Name = "ScComboBox";
            this.ScComboBox.Size = new System.Drawing.Size(182, 26);
            this.ScComboBox.TabIndex = 1;
            // 
            // McComboBox
            // 
            this.McComboBox.FormattingEnabled = true;
            this.McComboBox.Location = new System.Drawing.Point(120, 27);
            this.McComboBox.Name = "McComboBox";
            this.McComboBox.Size = new System.Drawing.Size(182, 26);
            this.McComboBox.TabIndex = 0;
            this.McComboBox.SelectedIndexChanged += new System.EventHandler(this.McComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(45, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 378);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "메뉴";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtClearBtn);
            this.groupBox3.Controls.Add(this.addCartBtn);
            this.groupBox3.Controls.Add(this.priceTxtBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.countTxtBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.itemNameTxtBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.scNameTxtBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.itemNoTxtBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(842, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 464);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "상품정보";
            // 
            // txtClearBtn
            // 
            this.txtClearBtn.Location = new System.Drawing.Point(49, 365);
            this.txtClearBtn.Name = "txtClearBtn";
            this.txtClearBtn.Size = new System.Drawing.Size(145, 37);
            this.txtClearBtn.TabIndex = 11;
            this.txtClearBtn.Text = "초기화";
            this.txtClearBtn.UseVisualStyleBackColor = true;
            this.txtClearBtn.Click += new System.EventHandler(this.txtClearBtn_Click);
            // 
            // addCartBtn
            // 
            this.addCartBtn.Location = new System.Drawing.Point(206, 365);
            this.addCartBtn.Name = "addCartBtn";
            this.addCartBtn.Size = new System.Drawing.Size(145, 37);
            this.addCartBtn.TabIndex = 10;
            this.addCartBtn.Text = "장바구니 담기";
            this.addCartBtn.UseVisualStyleBackColor = true;
            this.addCartBtn.Click += new System.EventHandler(this.addCartBtn_Click);
            // 
            // priceTxtBox
            // 
            this.priceTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.priceTxtBox.Location = new System.Drawing.Point(147, 233);
            this.priceTxtBox.Name = "priceTxtBox";
            this.priceTxtBox.ReadOnly = true;
            this.priceTxtBox.Size = new System.Drawing.Size(185, 28);
            this.priceTxtBox.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "개당 가격";
            // 
            // countTxtBox
            // 
            this.countTxtBox.Location = new System.Drawing.Point(147, 280);
            this.countTxtBox.Name = "countTxtBox";
            this.countTxtBox.Size = new System.Drawing.Size(185, 28);
            this.countTxtBox.TabIndex = 7;
            this.countTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.countTxtBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "수량";
            // 
            // itemNameTxtBox
            // 
            this.itemNameTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemNameTxtBox.Location = new System.Drawing.Point(147, 184);
            this.itemNameTxtBox.Name = "itemNameTxtBox";
            this.itemNameTxtBox.ReadOnly = true;
            this.itemNameTxtBox.Size = new System.Drawing.Size(185, 28);
            this.itemNameTxtBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "상품명";
            // 
            // scNameTxtBox
            // 
            this.scNameTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.scNameTxtBox.Location = new System.Drawing.Point(147, 133);
            this.scNameTxtBox.Name = "scNameTxtBox";
            this.scNameTxtBox.ReadOnly = true;
            this.scNameTxtBox.Size = new System.Drawing.Size(185, 28);
            this.scNameTxtBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "소분류";
            // 
            // itemNoTxtBox
            // 
            this.itemNoTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemNoTxtBox.Location = new System.Drawing.Point(147, 79);
            this.itemNoTxtBox.Name = "itemNoTxtBox";
            this.itemNoTxtBox.ReadOnly = true;
            this.itemNoTxtBox.Size = new System.Drawing.Size(185, 28);
            this.itemNoTxtBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "상품번호";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buyBtn);
            this.groupBox4.Controls.Add(this.clearCDBtn);
            this.groupBox4.Controls.Add(this.deleteCDBtn);
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(189, 529);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(941, 363);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "장바구니";
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(816, 242);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(102, 37);
            this.buyBtn.TabIndex = 3;
            this.buyBtn.Text = "구매";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // clearCDBtn
            // 
            this.clearCDBtn.Location = new System.Drawing.Point(816, 96);
            this.clearCDBtn.Name = "clearCDBtn";
            this.clearCDBtn.Size = new System.Drawing.Size(102, 37);
            this.clearCDBtn.TabIndex = 2;
            this.clearCDBtn.Text = "초기화";
            this.clearCDBtn.UseVisualStyleBackColor = true;
            this.clearCDBtn.Click += new System.EventHandler(this.clearCDBtn_Click);
            // 
            // deleteCDBtn
            // 
            this.deleteCDBtn.Location = new System.Drawing.Point(816, 169);
            this.deleteCDBtn.Name = "deleteCDBtn";
            this.deleteCDBtn.Size = new System.Drawing.Size(102, 37);
            this.deleteCDBtn.TabIndex = 1;
            this.deleteCDBtn.Text = "삭제";
            this.deleteCDBtn.UseVisualStyleBackColor = true;
            this.deleteCDBtn.Click += new System.EventHandler(this.deleteCDBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(36, 38);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 30;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(754, 301);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 904);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox McComboBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ScComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox itemNoTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox scNameTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox countTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox itemNameTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox priceTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button txtClearBtn;
        private System.Windows.Forms.Button addCartBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button clearCDBtn;
        private System.Windows.Forms.Button deleteCDBtn;
        private System.Windows.Forms.Button buyBtn;
    }
}