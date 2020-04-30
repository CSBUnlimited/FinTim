namespace FinAndTime.Views.UserControls.Transaction
{
    partial class TransactionUserControl
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.reportButton = new System.Windows.Forms.Button();
            this.contentHeaderUserControl = new FinAndTime.Views.UserControls.ContentHeaderUserControl();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.dataGridView);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentPanel.Location = new System.Drawing.Point(0, 55);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.contentPanel.Size = new System.Drawing.Size(658, 482);
            this.contentPanel.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(10, 10);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(638, 472);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // reportButton
            // 
            this.reportButton.BackgroundImage = global::FinAndTime.Views.Properties.Resources.report_icon;
            this.reportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reportButton.FlatAppearance.BorderSize = 0;
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Location = new System.Drawing.Point(2, 1);
            this.reportButton.Margin = new System.Windows.Forms.Padding(0);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(53, 53);
            this.reportButton.TabIndex = 1;
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonToolTip = "Add Transaction";
            this.contentHeaderUserControl.BackButtonVisible = false;
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Transactions";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(658, 55);
            this.contentHeaderUserControl.TabIndex = 0;
            this.contentHeaderUserControl.AddButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_AddButtonOnClick);
            // 
            // TransactionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Name = "TransactionUserControl";
            this.Size = new System.Drawing.Size(658, 537);
            this.Load += new System.EventHandler(this.TransactionUserControl_Load);
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button reportButton;
    }
}
