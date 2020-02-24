namespace MoreLayoutsWinforms
{
    partial class TestConstraintLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.constraintLayoutPanel1 = new MoreLayoutsWinforms.ConstraintLayout.ConstraintLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.constraintLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 104);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // constraintLayoutPanel1
            // 
            this.constraintLayoutPanel1.Controls.Add(this.button1);
            this.constraintLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.constraintLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.constraintLayoutPanel1.Name = "constraintLayoutPanel1";
            this.constraintLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.constraintLayoutPanel1.Size = new System.Drawing.Size(777, 414);
            this.constraintLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TestConstraintLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.constraintLayoutPanel1);
            this.Name = "TestConstraintLayout";
            this.Size = new System.Drawing.Size(777, 414);
            this.constraintLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ConstraintLayout.ConstraintLayoutPanel constraintLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
