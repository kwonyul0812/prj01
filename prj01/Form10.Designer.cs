namespace prj01
{
    partial class Form10
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
            this.label1 = new System.Windows.Forms.Label();
            this.priceTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stockTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.itemNameTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ScComboBox = new System.Windows.Forms.ComboBox();
            this.McComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(184, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "상품 추가";
            // 
            // priceTxtBox
            // 
            this.priceTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.priceTxtBox.Location = new System.Drawing.Point(190, 288);
            this.priceTxtBox.Name = "priceTxtBox";
            this.priceTxtBox.Size = new System.Drawing.Size(185, 28);
            this.priceTxtBox.TabIndex = 19;
            this.priceTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTxtBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(98, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "개당 가격";
            // 
            // stockTxtBox
            // 
            this.stockTxtBox.Location = new System.Drawing.Point(190, 335);
            this.stockTxtBox.Name = "stockTxtBox";
            this.stockTxtBox.Size = new System.Drawing.Size(185, 28);
            this.stockTxtBox.TabIndex = 17;
            this.stockTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stockTxtBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "재고";
            // 
            // itemNameTxtBox
            // 
            this.itemNameTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.itemNameTxtBox.Location = new System.Drawing.Point(190, 239);
            this.itemNameTxtBox.Name = "itemNameTxtBox";
            this.itemNameTxtBox.Size = new System.Drawing.Size(185, 28);
            this.itemNameTxtBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "상품명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "소분류";
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(287, 408);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(124, 39);
            this.OkBtn.TabIndex = 20;
            this.OkBtn.Text = "추가";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(131, 408);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(124, 39);
            this.CancelBtn.TabIndex = 21;
            this.CancelBtn.Text = "취소";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "대분류";
            // 
            // ScComboBox
            // 
            this.ScComboBox.FormattingEnabled = true;
            this.ScComboBox.Location = new System.Drawing.Point(190, 188);
            this.ScComboBox.Name = "ScComboBox";
            this.ScComboBox.Size = new System.Drawing.Size(182, 26);
            this.ScComboBox.TabIndex = 24;
            // 
            // McComboBox
            // 
            this.McComboBox.FormattingEnabled = true;
            this.McComboBox.Location = new System.Drawing.Point(190, 145);
            this.McComboBox.Name = "McComboBox";
            this.McComboBox.Size = new System.Drawing.Size(182, 26);
            this.McComboBox.TabIndex = 23;
            this.McComboBox.SelectedIndexChanged += new System.EventHandler(this.McComboBox_SelectedIndexChanged);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 495);
            this.Controls.Add(this.ScComboBox);
            this.Controls.Add(this.McComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.priceTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.stockTxtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.itemNameTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Form10";
            this.Text = "Form10";
            this.Load += new System.EventHandler(this.Form10_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox priceTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox stockTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox itemNameTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ScComboBox;
        private System.Windows.Forms.ComboBox McComboBox;
    }
}