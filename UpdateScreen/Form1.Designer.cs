
namespace UpdateScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkingDeviceCompatibility = new System.Windows.Forms.Panel();
            this.alreadyUpdated = new System.Windows.Forms.Panel();
            this.installingUpdate = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.percentComplete = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkingDeviceCompatibility.SuspendLayout();
            this.alreadyUpdated.SuspendLayout();
            this.installingUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 24.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(41, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update to the latest version of PanOS 10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 11.5F);
            this.label2.Location = new System.Drawing.Point(45, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(884, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "One of the best features of PanOS 10 is that it keeps getting better with every u" +
    "pdate. This PC is currently not running the latest and";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 11.5F);
            this.label3.Location = new System.Drawing.Point(45, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "most secure version of PanOS 10. The latest version is Sun Valley (21H2).";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 11.5F);
            this.label4.Location = new System.Drawing.Point(45, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(780, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "We can help you get the latest security enhancements and feature improvements. Cl" +
    "ick \'Update Now\' to get started.";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(660, 520);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(35, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Do not update now";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkingDeviceCompatibility
            // 
            this.checkingDeviceCompatibility.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.checkingDeviceCompatibility.Controls.Add(this.alreadyUpdated);
            this.checkingDeviceCompatibility.Controls.Add(this.pictureBox3);
            this.checkingDeviceCompatibility.Controls.Add(this.pictureBox2);
            this.checkingDeviceCompatibility.Controls.Add(this.label5);
            this.checkingDeviceCompatibility.Font = new System.Drawing.Font("Segoe UI Semilight", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkingDeviceCompatibility.Location = new System.Drawing.Point(0, 0);
            this.checkingDeviceCompatibility.Name = "checkingDeviceCompatibility";
            this.checkingDeviceCompatibility.Size = new System.Drawing.Size(960, 642);
            this.checkingDeviceCompatibility.TabIndex = 7;
            // 
            // alreadyUpdated
            // 
            this.alreadyUpdated.Controls.Add(this.installingUpdate);
            this.alreadyUpdated.Controls.Add(this.Exit);
            this.alreadyUpdated.Controls.Add(this.pictureBox4);
            this.alreadyUpdated.Controls.Add(this.label6);
            this.alreadyUpdated.Location = new System.Drawing.Point(0, 0);
            this.alreadyUpdated.Name = "alreadyUpdated";
            this.alreadyUpdated.Size = new System.Drawing.Size(960, 642);
            this.alreadyUpdated.TabIndex = 3;
            // 
            // installingUpdate
            // 
            this.installingUpdate.Controls.Add(this.pictureBox5);
            this.installingUpdate.Controls.Add(this.percentComplete);
            this.installingUpdate.Controls.Add(this.label9);
            this.installingUpdate.Controls.Add(this.label8);
            this.installingUpdate.Controls.Add(this.label7);
            this.installingUpdate.Location = new System.Drawing.Point(0, 0);
            this.installingUpdate.Name = "installingUpdate";
            this.installingUpdate.Size = new System.Drawing.Size(960, 642);
            this.installingUpdate.TabIndex = 3;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::UpdateScreen.Properties.Resources.microsoft_logo_final;
            this.pictureBox5.Location = new System.Drawing.Point(21, 604);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 24);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // percentComplete
            // 
            this.percentComplete.AutoSize = true;
            this.percentComplete.Font = new System.Drawing.Font("Segoe UI Light", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentComplete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.percentComplete.Location = new System.Drawing.Point(42, 175);
            this.percentComplete.Name = "percentComplete";
            this.percentComplete.Size = new System.Drawing.Size(53, 38);
            this.percentComplete.TabIndex = 3;
            this.percentComplete.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 11.75F);
            this.label9.Location = new System.Drawing.Point(46, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Percent Complete:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semilight", 11.75F);
            this.label8.Location = new System.Drawing.Point(46, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(314, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Installing your PanOS 10 update. Please wait.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(41, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(385, 45);
            this.label7.TabIndex = 0;
            this.label7.Text = "Getting your update ready";
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(660, 520);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(251, 42);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::UpdateScreen.Properties.Resources.microsoft_logo_final;
            this.pictureBox4.Location = new System.Drawing.Point(21, 604);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 24);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(41, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(802, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "Thank you for updating to the latest version of PanOS 10";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::UpdateScreen.Properties.Resources._301__1_;
            this.pictureBox3.Location = new System.Drawing.Point(448, 290);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 74);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::UpdateScreen.Properties.Resources.microsoft_logo_final;
            this.pictureBox2.Location = new System.Drawing.Point(21, 604);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 24);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(41, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(431, 45);
            this.label5.TabIndex = 0;
            this.label5.Text = "Checking device compatibility";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Image = global::UpdateScreen.Properties.Resources.microsoft_logo_final;
            this.pictureBox1.Location = new System.Drawing.Point(21, 603);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 22);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(960, 641);
            this.Controls.Add(this.checkingDeviceCompatibility);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PanOS 10 Update Assistant";
            this.checkingDeviceCompatibility.ResumeLayout(false);
            this.checkingDeviceCompatibility.PerformLayout();
            this.alreadyUpdated.ResumeLayout(false);
            this.alreadyUpdated.PerformLayout();
            this.installingUpdate.ResumeLayout(false);
            this.installingUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel checkingDeviceCompatibility;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel alreadyUpdated;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel installingUpdate;
        private System.Windows.Forms.Label percentComplete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

