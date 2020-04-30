namespace FinAndTime.Views.UserControls.Passbook
{
    partial class PassbookUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contentHeaderUserControl = new FinAndTime.Views.UserControls.ContentHeaderUserControl();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridHolderPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.dataGridHolderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonVisible = false;
            this.contentHeaderUserControl.BackButtonVisible = false;
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Passbook";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(600, 55);
            this.contentHeaderUserControl.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(10, 10);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(580, 547);
            this.dataGridView.TabIndex = 2;
            // 
            // dataGridHolderPanel
            // 
            this.dataGridHolderPanel.AutoScroll = true;
            this.dataGridHolderPanel.Controls.Add(this.dataGridView);
            this.dataGridHolderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridHolderPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridHolderPanel.Location = new System.Drawing.Point(0, 55);
            this.dataGridHolderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridHolderPanel.Name = "dataGridHolderPanel";
            this.dataGridHolderPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.dataGridHolderPanel.Size = new System.Drawing.Size(600, 557);
            this.dataGridHolderPanel.TabIndex = 3;
            // 
            // PassbookUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridHolderPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Name = "PassbookUserControl";
            this.Size = new System.Drawing.Size(600, 612);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.dataGridHolderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel dataGridHolderPanel;
    }
}
