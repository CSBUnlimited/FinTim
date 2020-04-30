namespace FinAndTime.Views.UserControls.Transaction
{
    partial class ManageTransactionUserControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.referenceNumberPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.referenceNumberTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.incomeCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.transactionPartyComboBox = new System.Windows.Forms.ComboBox();
            this.transactionPartErrorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.remarksErrorLabel = new System.Windows.Forms.Label();
            this.remarksTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amountErrorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actionsUserControl = new FinAndTime.Views.UserControls.ActionsUserControl();
            this.contentHeaderUserControl = new FinAndTime.Views.UserControls.ContentHeaderUserControl();
            this.contentPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.referenceNumberPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.tableLayoutPanel);
            this.contentPanel.Controls.Add(this.actionsUserControl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 55);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.MaximumSize = new System.Drawing.Size(750, 3000);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.contentPanel.Size = new System.Drawing.Size(555, 596);
            this.contentPanel.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.referenceNumberPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel2, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panel4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(535, 363);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // referenceNumberPanel
            // 
            this.tableLayoutPanel.SetColumnSpan(this.referenceNumberPanel, 3);
            this.referenceNumberPanel.Controls.Add(this.label2);
            this.referenceNumberPanel.Controls.Add(this.referenceNumberTextBox);
            this.referenceNumberPanel.Controls.Add(this.label6);
            this.referenceNumberPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.referenceNumberPanel.Location = new System.Drawing.Point(0, 0);
            this.referenceNumberPanel.Margin = new System.Windows.Forms.Padding(0);
            this.referenceNumberPanel.Name = "referenceNumberPanel";
            this.referenceNumberPanel.Padding = new System.Windows.Forms.Padding(10);
            this.referenceNumberPanel.Size = new System.Drawing.Size(535, 84);
            this.referenceNumberPanel.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Error";
            this.label2.Visible = false;
            // 
            // referenceNumberTextBox
            // 
            this.referenceNumberTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.referenceNumberTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceNumberTextBox.Location = new System.Drawing.Point(10, 28);
            this.referenceNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.referenceNumberTextBox.MaxLength = 100;
            this.referenceNumberTextBox.Name = "referenceNumberTextBox";
            this.referenceNumberTextBox.ReadOnly = true;
            this.referenceNumberTextBox.Size = new System.Drawing.Size(515, 29);
            this.referenceNumberTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Remarks";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.incomeCheckBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(356, 173);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(179, 84);
            this.panel2.TabIndex = 10;
            // 
            // incomeCheckBox
            // 
            this.incomeCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.incomeCheckBox.AutoSize = true;
            this.incomeCheckBox.Checked = true;
            this.incomeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.incomeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.incomeCheckBox.Location = new System.Drawing.Point(37, 29);
            this.incomeCheckBox.Name = "incomeCheckBox";
            this.incomeCheckBox.Size = new System.Drawing.Size(98, 23);
            this.incomeCheckBox.TabIndex = 0;
            this.incomeCheckBox.Text = "Is Income";
            this.incomeCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.tableLayoutPanel.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.transactionPartyComboBox);
            this.panel1.Controls.Add(this.transactionPartErrorLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(535, 89);
            this.panel1.TabIndex = 9;
            // 
            // transactionPartyComboBox
            // 
            this.transactionPartyComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.transactionPartyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transactionPartyComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionPartyComboBox.FormattingEnabled = true;
            this.transactionPartyComboBox.ItemHeight = 18;
            this.transactionPartyComboBox.Location = new System.Drawing.Point(10, 28);
            this.transactionPartyComboBox.Name = "transactionPartyComboBox";
            this.transactionPartyComboBox.Size = new System.Drawing.Size(515, 26);
            this.transactionPartyComboBox.TabIndex = 3;
            // 
            // transactionPartErrorLabel
            // 
            this.transactionPartErrorLabel.AutoSize = true;
            this.transactionPartErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionPartErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.transactionPartErrorLabel.Location = new System.Drawing.Point(13, 57);
            this.transactionPartErrorLabel.Name = "transactionPartErrorLabel";
            this.transactionPartErrorLabel.Size = new System.Drawing.Size(35, 16);
            this.transactionPartErrorLabel.TabIndex = 2;
            this.transactionPartErrorLabel.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transaction Party";
            // 
            // panel4
            // 
            this.tableLayoutPanel.SetColumnSpan(this.panel4, 3);
            this.panel4.Controls.Add(this.remarksErrorLabel);
            this.panel4.Controls.Add(this.remarksTextBox);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 257);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(535, 84);
            this.panel4.TabIndex = 8;
            // 
            // remarksErrorLabel
            // 
            this.remarksErrorLabel.AutoSize = true;
            this.remarksErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarksErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.remarksErrorLabel.Location = new System.Drawing.Point(13, 61);
            this.remarksErrorLabel.Name = "remarksErrorLabel";
            this.remarksErrorLabel.Size = new System.Drawing.Size(39, 16);
            this.remarksErrorLabel.TabIndex = 2;
            this.remarksErrorLabel.Text = "Error";
            // 
            // remarksTextBox
            // 
            this.remarksTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.remarksTextBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarksTextBox.Location = new System.Drawing.Point(10, 28);
            this.remarksTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.remarksTextBox.MaxLength = 100;
            this.remarksTextBox.Name = "remarksTextBox";
            this.remarksTextBox.Size = new System.Drawing.Size(515, 29);
            this.remarksTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Remarks";
            // 
            // panel3
            // 
            this.tableLayoutPanel.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.amountNumericUpDown);
            this.panel3.Controls.Add(this.amountErrorLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 173);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(356, 84);
            this.panel3.TabIndex = 7;
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.DecimalPlaces = 2;
            this.amountNumericUpDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.amountNumericUpDown.Location = new System.Drawing.Point(10, 28);
            this.amountNumericUpDown.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            131072});
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(336, 26);
            this.amountNumericUpDown.TabIndex = 3;
            // 
            // amountErrorLabel
            // 
            this.amountErrorLabel.AutoSize = true;
            this.amountErrorLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.amountErrorLabel.Location = new System.Drawing.Point(13, 57);
            this.amountErrorLabel.Name = "amountErrorLabel";
            this.amountErrorLabel.Size = new System.Drawing.Size(39, 16);
            this.amountErrorLabel.TabIndex = 2;
            this.amountErrorLabel.Text = "Error";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // actionsUserControl
            // 
            this.actionsUserControl.DeleteButtonToolTip = "Delete transaction";
            this.actionsUserControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionsUserControl.ErrorMessageText = "";
            this.actionsUserControl.Location = new System.Drawing.Point(10, 541);
            this.actionsUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.actionsUserControl.Name = "actionsUserControl";
            this.actionsUserControl.ResetButtonToolTip = "Reset";
            this.actionsUserControl.SaveButtonToolTip = "Save transaction";
            this.actionsUserControl.Size = new System.Drawing.Size(535, 55);
            this.actionsUserControl.TabIndex = 5;
            this.actionsUserControl.SaveButtonOnClick += new System.EventHandler(this.actionsUserControl_SaveButtonOnClick);
            this.actionsUserControl.DeleteButtonOnClick += new System.EventHandler(this.actionsUserControl_DeleteButtonOnClick);
            this.actionsUserControl.ResetButtonOnClick += new System.EventHandler(this.actionsUserControl_ResetButtonOnClick);
            // 
            // contentHeaderUserControl
            // 
            this.contentHeaderUserControl.AddButtonVisible = false;
            this.contentHeaderUserControl.BackButtonToolTip = "Back to transactions";
            this.contentHeaderUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentHeaderUserControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentHeaderUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentHeaderUserControl.MainTitle = "Manage Transaction";
            this.contentHeaderUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.contentHeaderUserControl.Name = "contentHeaderUserControl";
            this.contentHeaderUserControl.Size = new System.Drawing.Size(555, 55);
            this.contentHeaderUserControl.TabIndex = 0;
            this.contentHeaderUserControl.BackButtonOnClick += new System.EventHandler(this.contentHeaderUserControl_BackButtonOnClick);
            // 
            // ManageTransactionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.contentHeaderUserControl);
            this.Name = "ManageTransactionUserControl";
            this.Size = new System.Drawing.Size(555, 651);
            this.Load += new System.EventHandler(this.ManageTransactionUserControl_Load);
            this.contentPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.referenceNumberPanel.ResumeLayout(false);
            this.referenceNumberPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ContentHeaderUserControl contentHeaderUserControl;
        private System.Windows.Forms.Panel contentPanel;
        private ActionsUserControl actionsUserControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label remarksErrorLabel;
        private System.Windows.Forms.TextBox remarksTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label amountErrorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox transactionPartyComboBox;
        private System.Windows.Forms.Label transactionPartErrorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox incomeCheckBox;
        private System.Windows.Forms.NumericUpDown amountNumericUpDown;
        private System.Windows.Forms.Panel referenceNumberPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox referenceNumberTextBox;
        private System.Windows.Forms.Label label6;
    }
}
