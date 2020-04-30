namespace FinAndTime.Forms
{
    partial class SplashScreenForm
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
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.pbarProgressBar = new System.Windows.Forms.ProgressBar();
            this.bwInitialWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProgressStatus.Location = new System.Drawing.Point(12, 540);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(351, 24);
            this.lblProgressStatus.TabIndex = 0;
            this.lblProgressStatus.Text = "Please wait...";
            this.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbarProgressBar
            // 
            this.pbarProgressBar.Location = new System.Drawing.Point(12, 512);
            this.pbarProgressBar.MarqueeAnimationSpeed = 10;
            this.pbarProgressBar.Name = "pbarProgressBar";
            this.pbarProgressBar.Size = new System.Drawing.Size(351, 25);
            this.pbarProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarProgressBar.TabIndex = 1;
            // 
            // bwInitialWorker
            // 
            this.bwInitialWorker.WorkerReportsProgress = true;
            this.bwInitialWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwInitialWorker_DoWork);
            this.bwInitialWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwInitialWorker_ProgressChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 115);
            this.label1.TabIndex = 2;
            this.label1.Text = "Financial and Time\r\nManagement System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(375, 600);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbarProgressBar);
            this.Controls.Add(this.lblProgressStatus);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbarProgressBar;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.ComponentModel.BackgroundWorker bwInitialWorker;
        private System.Windows.Forms.Label label1;
    }
}