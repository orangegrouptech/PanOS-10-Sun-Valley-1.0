
namespace PanOSMain
{
    partial class PanOSMain
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
            this.whatHappenedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // whatHappenedButton
            // 
            this.whatHappenedButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.whatHappenedButton.Location = new System.Drawing.Point(265, 464);
            this.whatHappenedButton.Name = "whatHappenedButton";
            this.whatHappenedButton.Size = new System.Drawing.Size(193, 33);
            this.whatHappenedButton.TabIndex = 0;
            this.whatHappenedButton.Text = "Uhhh... what happened...?";
            this.whatHappenedButton.UseVisualStyleBackColor = true;
            this.whatHappenedButton.Click += new System.EventHandler(this.whatHappenedButton_Click);
            // 
            // PanOSMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::PanOSMain.Properties.Resources.PanOS_no_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(470, 504);
            this.ControlBox = false;
            this.Controls.Add(this.whatHappenedButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PanOSMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanOSMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button whatHappenedButton;
    }
}

