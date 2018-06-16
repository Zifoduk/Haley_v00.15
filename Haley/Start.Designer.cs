namespace Haley
{
    partial class Start
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
            this.Btn_launch = new System.Windows.Forms.Button();
            this.MusicLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.Btn_CML = new System.Windows.Forms.Button();
            this.Dis_MusicLocation = new System.Windows.Forms.Label();
            this.CBox_VSct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_launch
            // 
            this.Btn_launch.Location = new System.Drawing.Point(61, 46);
            this.Btn_launch.Name = "Btn_launch";
            this.Btn_launch.Size = new System.Drawing.Size(75, 23);
            this.Btn_launch.TabIndex = 1;
            this.Btn_launch.Text = "Launch";
            this.Btn_launch.UseVisualStyleBackColor = true;
            this.Btn_launch.Click += new System.EventHandler(this.Btn_launch_Click);
            // 
            // Btn_CML
            // 
            this.Btn_CML.Location = new System.Drawing.Point(61, 89);
            this.Btn_CML.Name = "Btn_CML";
            this.Btn_CML.Size = new System.Drawing.Size(169, 23);
            this.Btn_CML.TabIndex = 2;
            this.Btn_CML.Text = "Choose Music Location";
            this.Btn_CML.UseVisualStyleBackColor = true;
            this.Btn_CML.Click += new System.EventHandler(this.Btn_CML_Click);
            // 
            // Dis_MusicLocation
            // 
            this.Dis_MusicLocation.AutoSize = true;
            this.Dis_MusicLocation.Location = new System.Drawing.Point(236, 94);
            this.Dis_MusicLocation.Name = "Dis_MusicLocation";
            this.Dis_MusicLocation.Size = new System.Drawing.Size(66, 13);
            this.Dis_MusicLocation.TabIndex = 4;
            this.Dis_MusicLocation.Text = "Select folder";
            // 
            // CBox_VSct
            // 
            this.CBox_VSct.AllowDrop = true;
            this.CBox_VSct.FormattingEnabled = true;
            this.CBox_VSct.Location = new System.Drawing.Point(61, 132);
            this.CBox_VSct.Name = "CBox_VSct";
            this.CBox_VSct.Size = new System.Drawing.Size(241, 21);
            this.CBox_VSct.TabIndex = 5;
            this.CBox_VSct.SelectedIndexChanged += new System.EventHandler(this.CBox_VSct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Voice";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBox_VSct);
            this.Controls.Add(this.Dis_MusicLocation);
            this.Controls.Add(this.Btn_CML);
            this.Controls.Add(this.Btn_launch);
            this.Name = "Start";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_launch;
        private System.Windows.Forms.FolderBrowserDialog MusicLocation;
        private System.Windows.Forms.Button Btn_CML;
        private System.Windows.Forms.Label Dis_MusicLocation;
        private System.Windows.Forms.ComboBox CBox_VSct;
        private System.Windows.Forms.Label label1;
    }
}