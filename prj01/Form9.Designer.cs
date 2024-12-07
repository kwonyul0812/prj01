namespace prj01
{
    partial class Form9
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DeleteItemBtn = new System.Windows.Forms.Button();
            this.UpdateItemBtn = new System.Windows.Forms.Button();
            this.AddItemBtn = new System.Windows.Forms.Button();
            this.adminNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.DeleteItemBtn);
            this.groupBox1.Controls.Add(this.UpdateItemBtn);
            this.groupBox1.Controls.Add(this.AddItemBtn);
            this.groupBox1.Location = new System.Drawing.Point(49, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 517);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상품관리";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(782, 348);
            this.dataGridView1.TabIndex = 3;
            // 
            // DeleteItemBtn
            // 
            this.DeleteItemBtn.Location = new System.Drawing.Point(550, 39);
            this.DeleteItemBtn.Name = "DeleteItemBtn";
            this.DeleteItemBtn.Size = new System.Drawing.Size(120, 42);
            this.DeleteItemBtn.TabIndex = 2;
            this.DeleteItemBtn.Text = "상품 삭제";
            this.DeleteItemBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateItemBtn
            // 
            this.UpdateItemBtn.Location = new System.Drawing.Point(379, 39);
            this.UpdateItemBtn.Name = "UpdateItemBtn";
            this.UpdateItemBtn.Size = new System.Drawing.Size(120, 42);
            this.UpdateItemBtn.TabIndex = 1;
            this.UpdateItemBtn.Text = "상품 수정";
            this.UpdateItemBtn.UseVisualStyleBackColor = true;
            this.UpdateItemBtn.Click += new System.EventHandler(this.UpdateItemBtn_Click);
            // 
            // AddItemBtn
            // 
            this.AddItemBtn.Location = new System.Drawing.Point(206, 39);
            this.AddItemBtn.Name = "AddItemBtn";
            this.AddItemBtn.Size = new System.Drawing.Size(120, 42);
            this.AddItemBtn.TabIndex = 0;
            this.AddItemBtn.Text = "상품 추가";
            this.AddItemBtn.UseVisualStyleBackColor = true;
            this.AddItemBtn.Click += new System.EventHandler(this.AddItemBtn_Click);
            // 
            // adminNameLabel
            // 
            this.adminNameLabel.AutoSize = true;
            this.adminNameLabel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.adminNameLabel.Location = new System.Drawing.Point(685, 36);
            this.adminNameLabel.Name = "adminNameLabel";
            this.adminNameLabel.Size = new System.Drawing.Size(253, 24);
            this.adminNameLabel.TabIndex = 5;
            this.adminNameLabel.Text = "관리자 님 환영합니다";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 639);
            this.Controls.Add(this.adminNameLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form9";
            this.Text = "관리자";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteItemBtn;
        private System.Windows.Forms.Button UpdateItemBtn;
        private System.Windows.Forms.Button AddItemBtn;
        private System.Windows.Forms.Label adminNameLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}