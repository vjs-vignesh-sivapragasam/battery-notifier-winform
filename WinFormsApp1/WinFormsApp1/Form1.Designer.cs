namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            batteryCheckTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            lblDescription = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            waterReminderTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 27);
            label1.Name = "label1";
            label1.Size = new Size(223, 29);
            label1.TabIndex = 0;
            label1.Text = "BATTERY NOTIFIER";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(24, 80);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(50, 20);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 189);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 2;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 230);
            label3.Name = "label3";
            label3.Size = new Size(170, 20);
            label3.TabIndex = 3;
            label3.Text = "Developed by S Vignesh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 265);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 4;
            label4.Text = "Version: #1.0.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(422, 413);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblDescription);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            WindowState = FormWindowState.Minimized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer batteryCheckTimer;
        private Label label1;
        private Label lblDescription;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer waterReminderTimer;
    }
}
