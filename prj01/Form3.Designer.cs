namespace prj01
{
    partial class Form3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.상품구매ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.결제내역ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.스탬프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회원정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상품구매ToolStripMenuItem,
            this.결제내역ToolStripMenuItem,
            this.스탬프ToolStripMenuItem,
            this.회원정보ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1314, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 상품구매ToolStripMenuItem
            // 
            this.상품구매ToolStripMenuItem.Name = "상품구매ToolStripMenuItem";
            this.상품구매ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.상품구매ToolStripMenuItem.Text = "상품구매";
            this.상품구매ToolStripMenuItem.Click += new System.EventHandler(this.상품구매ToolStripMenuItem_Click);
            // 
            // 결제내역ToolStripMenuItem
            // 
            this.결제내역ToolStripMenuItem.Name = "결제내역ToolStripMenuItem";
            this.결제내역ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.결제내역ToolStripMenuItem.Text = "구매내역";
            this.결제내역ToolStripMenuItem.Click += new System.EventHandler(this.결제내역ToolStripMenuItem_Click);
            // 
            // 스탬프ToolStripMenuItem
            // 
            this.스탬프ToolStripMenuItem.Name = "스탬프ToolStripMenuItem";
            this.스탬프ToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.스탬프ToolStripMenuItem.Text = "스탬프";
            // 
            // 회원정보ToolStripMenuItem
            // 
            this.회원정보ToolStripMenuItem.Name = "회원정보ToolStripMenuItem";
            this.회원정보ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.회원정보ToolStripMenuItem.Text = "회원정보";
            this.회원정보ToolStripMenuItem.Click += new System.EventHandler(this.회원정보ToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 852);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 상품구매ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 결제내역ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 스탬프ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원정보ToolStripMenuItem;
    }
}