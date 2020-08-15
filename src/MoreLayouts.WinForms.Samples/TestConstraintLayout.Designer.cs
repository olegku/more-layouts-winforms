namespace MoreLayouts.WinForms.Samples
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
            this.constraintLayoutPanel1 = new MoreLayouts.WinForms.ConstraintLayout.ConstraintLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.constraintLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // constraintLayoutPanel1
            // 
            this.constraintLayoutPanel1.Controls.Add(this.button4);
            this.constraintLayoutPanel1.Controls.Add(this.button3);
            this.constraintLayoutPanel1.Controls.Add(this.button1);
            this.constraintLayoutPanel1.Controls.Add(this.button2);
            this.constraintLayoutPanel1.Location = new System.Drawing.Point(33, 15);
            this.constraintLayoutPanel1.Name = "constraintLayoutPanel1";
            this.constraintLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.constraintLayoutPanel1.Size = new System.Drawing.Size(674, 356);
            this.constraintLayoutPanel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(387, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 81);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.constraintLayoutPanel1.SetTop(this.button4, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(0));
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.constraintLayoutPanel1.SetCenter(this.button3, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(this.button1, MoreLayouts.WinForms.ConstraintLayout.ConstraintProperty.Center, 0));
            this.button3.Location = new System.Drawing.Point(73, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.constraintLayoutPanel1.SetTop(this.button3, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(this.button2, MoreLayouts.WinForms.ConstraintLayout.ConstraintProperty.Bottom, 10));
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.constraintLayoutPanel1.SetLeft(this.button1, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(10));
            this.button1.Location = new System.Drawing.Point(10, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.constraintLayoutPanel1.SetTop(this.button1, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(10));
            this.button1.UseVisualStyleBackColor = true;
            this.constraintLayoutPanel1.SetWidth(this.button1, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(250));
            // 
            // button2
            // 
            this.constraintLayoutPanel1.SetLeft(this.button2, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(this.button1, MoreLayouts.WinForms.ConstraintLayout.ConstraintProperty.Left, 10));
            this.button2.Location = new System.Drawing.Point(20, 70);
            this.button2.Name = "button2";
            this.constraintLayoutPanel1.SetRight(this.button2, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(this.button1, MoreLayouts.WinForms.ConstraintLayout.ConstraintProperty.Right, -10));
            this.button2.Size = new System.Drawing.Size(230, 150);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.constraintLayoutPanel1.SetTop(this.button2, new MoreLayouts.WinForms.ConstraintLayout.SimpleConstraint(this.button1, MoreLayouts.WinForms.ConstraintLayout.ConstraintProperty.Bottom, 10));
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TestConstraintLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.constraintLayoutPanel1);
            this.Name = "TestConstraintLayout";
            this.Size = new System.Drawing.Size(777, 414);
            this.constraintLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MoreLayouts.WinForms.ConstraintLayout.ConstraintLayoutPanel constraintLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}
