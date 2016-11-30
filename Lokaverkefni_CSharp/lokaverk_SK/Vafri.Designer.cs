namespace lokaverk_SK
{
    partial class Vafri
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
            this.wbVafri = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbVafri
            // 
            this.wbVafri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbVafri.Location = new System.Drawing.Point(0, 0);
            this.wbVafri.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbVafri.Name = "wbVafri";
            this.wbVafri.Size = new System.Drawing.Size(1125, 695);
            this.wbVafri.TabIndex = 0;
            // 
            // Vafri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 695);
            this.Controls.Add(this.wbVafri);
            this.Name = "Vafri";
            this.Text = "Vafri";
            this.Load += new System.EventHandler(this.Vafri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbVafri;
    }
}