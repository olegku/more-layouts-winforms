namespace MoreLayoutsWinforms
{
    partial class TestStackLayout
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
            this.stackLayoutPanel1 = new MoreLayouts.WinForms.StackLayout.StackLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stackLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackLayoutPanel1
            // 
            this.stackLayoutPanel1.AutoScroll = true;
            this.stackLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stackLayoutPanel1.Controls.Add(this.button4);
            this.stackLayoutPanel1.Controls.Add(this.button3);
            this.stackLayoutPanel1.Controls.Add(this.button2);
            this.stackLayoutPanel1.Controls.Add(this.button1);
            this.stackLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.stackLayoutPanel1.Name = "stackLayoutPanel1";
            this.stackLayoutPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.stackLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.stackLayoutPanel1.Size = new System.Drawing.Size(596, 427);
            this.stackLayoutPanel1.Spacing = 5;
            this.stackLayoutPanel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(111, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 43);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(262, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 82);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(370, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(368, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TestStackLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackLayoutPanel1);
            this.Name = "TestStackLayout";
            this.Size = new System.Drawing.Size(596, 427);
            this.stackLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MoreLayouts.WinForms.StackLayout.StackLayoutPanel stackLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}
