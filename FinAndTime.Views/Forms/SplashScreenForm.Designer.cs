using FinAndTime.Views.UserControls;

namespace FinAndTime.Views.Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userRegistrationPanel = new System.Windows.Forms.Panel();
            this.userRegistrationErrorLabel = new System.Windows.Forms.Label();
            this.userStartingBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userLastNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userDetailsSaveButton = new System.Windows.Forms.Button();
            this.userRegistrationContentHeaderUserControl = new FinAndTime.Views.UserControls.ContentHeaderUserControl();
            this.finTimLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.userRegistrationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finTimLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblProgressStatus.Location = new System.Drawing.Point(12, 507);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(351, 24);
            this.lblProgressStatus.TabIndex = 0;
            this.lblProgressStatus.Text = "Please wait...";
            this.lblProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbarProgressBar
            // 
            this.pbarProgressBar.Location = new System.Drawing.Point(12, 479);
            this.pbarProgressBar.MarqueeAnimationSpeed = 10;
            this.pbarProgressBar.Name = "pbarProgressBar";
            this.pbarProgressBar.Size = new System.Drawing.Size(351, 25);
            this.pbarProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbarProgressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(-1, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 52);
            this.label1.TabIndex = 2;
            this.label1.Text = "Financial and Time Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 98);
            this.label2.TabIndex = 3;
            this.label2.Text = "FinTim Manager";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(12, 566);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "CSB Unlimited";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userRegistrationPanel
            // 
            this.userRegistrationPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.userRegistrationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userRegistrationPanel.Controls.Add(this.userRegistrationErrorLabel);
            this.userRegistrationPanel.Controls.Add(this.userStartingBalanceTextBox);
            this.userRegistrationPanel.Controls.Add(this.label6);
            this.userRegistrationPanel.Controls.Add(this.userLastNameTextBox);
            this.userRegistrationPanel.Controls.Add(this.label5);
            this.userRegistrationPanel.Controls.Add(this.userFirstNameTextBox);
            this.userRegistrationPanel.Controls.Add(this.label4);
            this.userRegistrationPanel.Controls.Add(this.userDetailsSaveButton);
            this.userRegistrationPanel.Controls.Add(this.userRegistrationContentHeaderUserControl);
            this.userRegistrationPanel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistrationPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userRegistrationPanel.Location = new System.Drawing.Point(12, 159);
            this.userRegistrationPanel.Name = "userRegistrationPanel";
            this.userRegistrationPanel.Size = new System.Drawing.Size(351, 294);
            this.userRegistrationPanel.TabIndex = 5;
            // 
            // userRegistrationErrorLabel
            // 
            this.userRegistrationErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistrationErrorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.userRegistrationErrorLabel.Location = new System.Drawing.Point(9, 229);
            this.userRegistrationErrorLabel.Name = "userRegistrationErrorLabel";
            this.userRegistrationErrorLabel.Size = new System.Drawing.Size(266, 50);
            this.userRegistrationErrorLabel.TabIndex = 8;
            this.userRegistrationErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userStartingBalanceTextBox
            // 
            this.userStartingBalanceTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStartingBalanceTextBox.Location = new System.Drawing.Point(112, 181);
            this.userStartingBalanceTextBox.MaxLength = 10;
            this.userStartingBalanceTextBox.Name = "userStartingBalanceTextBox";
            this.userStartingBalanceTextBox.Size = new System.Drawing.Size(223, 29);
            this.userStartingBalanceTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Start Balance";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userLastNameTextBox
            // 
            this.userLastNameTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLastNameTextBox.Location = new System.Drawing.Point(113, 129);
            this.userLastNameTextBox.MaxLength = 100;
            this.userLastNameTextBox.Name = "userLastNameTextBox";
            this.userLastNameTextBox.Size = new System.Drawing.Size(223, 29);
            this.userLastNameTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Last Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userFirstNameTextBox
            // 
            this.userFirstNameTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFirstNameTextBox.Location = new System.Drawing.Point(113, 76);
            this.userFirstNameTextBox.MaxLength = 100;
            this.userFirstNameTextBox.Name = "userFirstNameTextBox";
            this.userFirstNameTextBox.Size = new System.Drawing.Size(223, 29);
            this.userFirstNameTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "First Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userDetailsSaveButton
            // 
            this.userDetailsSaveButton.BackgroundImage = global::FinAndTime.Views.Properties.Resources.Save_icon;
            this.userDetailsSaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userDetailsSaveButton.FlatAppearance.BorderSize = 0;
            this.userDetailsSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userDetailsSaveButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userDetailsSaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userDetailsSaveButton.Location = new System.Drawing.Point(286, 229);
            this.userDetailsSaveButton.Name = "userDetailsSaveButton";
            this.userDetailsSaveButton.Size = new System.Drawing.Size(50, 50);
            this.userDetailsSaveButton.TabIndex = 1;
            this.userDetailsSaveButton.UseVisualStyleBackColor = true;
            this.userDetailsSaveButton.Click += new System.EventHandler(this.userDetailsSaveButton_Click);
            // 
            // userRegistrationContentHeaderUserControl
            // 
            this.userRegistrationContentHeaderUserControl.AddButtonVisible = false;
            this.userRegistrationContentHeaderUserControl.BackButtonToolTip = "Cancel user registration";
            this.userRegistrationContentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userRegistrationContentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.userRegistrationContentHeaderUserControl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistrationContentHeaderUserControl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userRegistrationContentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.userRegistrationContentHeaderUserControl.MainTitle = "User Registration";
            this.userRegistrationContentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.userRegistrationContentHeaderUserControl.Name = "userRegistrationContentHeaderUserControl";
            this.userRegistrationContentHeaderUserControl.Size = new System.Drawing.Size(349, 55);
            this.userRegistrationContentHeaderUserControl.TabIndex = 0;
            this.userRegistrationContentHeaderUserControl.BackButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_BackButtonOnClick);
            // 
            // finTimLogoPictureBox
            // 
            this.finTimLogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.finTimLogoPictureBox.BackgroundImage = global::FinAndTime.Views.Properties.Resources.FinTim_icon;
            this.finTimLogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.finTimLogoPictureBox.Location = new System.Drawing.Point(12, 159);
            this.finTimLogoPictureBox.Name = "finTimLogoPictureBox";
            this.finTimLogoPictureBox.Size = new System.Drawing.Size(351, 294);
            this.finTimLogoPictureBox.TabIndex = 6;
            this.finTimLogoPictureBox.TabStop = false;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(375, 600);
            this.ControlBox = false;
            this.Controls.Add(this.userRegistrationPanel);
            this.Controls.Add(this.finTimLogoPictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.SplashScreenForm_Load);
            this.Shown += new System.EventHandler(this.SplashScreenForm_Shown);
            this.userRegistrationPanel.ResumeLayout(false);
            this.userRegistrationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finTimLogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbarProgressBar;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel userRegistrationPanel;
        private ContentHeaderUserControl userRegistrationContentHeaderUserControl;
        private System.Windows.Forms.Button userDetailsSaveButton;
        private System.Windows.Forms.TextBox userLastNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userFirstNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userStartingBalanceTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox finTimLogoPictureBox;
        private System.Windows.Forms.Label userRegistrationErrorLabel;
    }
}