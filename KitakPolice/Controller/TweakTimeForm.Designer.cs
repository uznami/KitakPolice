
namespace KitakPolice.Controller
{
    partial class TweakTimeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweakTimeForm));
            this.ApplyButton = new System.Windows.Forms.Button();
            this.ShutdownTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ShutdownTimeLabel = new System.Windows.Forms.Label();
            this.ShutdownTypeLabel = new System.Windows.Forms.Label();
            this.ShutdownTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ReminderLabel = new System.Windows.Forms.Label();
            this.ReminderCheckBox = new System.Windows.Forms.CheckBox();
            this.ReminderTextBox = new System.Windows.Forms.TextBox();
            this.IconLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(113, 117);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(68, 21);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "適用";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // ShutdownTypeComboBox
            // 
            this.ShutdownTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShutdownTypeComboBox.FormattingEnabled = true;
            this.ShutdownTypeComboBox.Items.AddRange(new object[] {
            "シャットダウン",
            "休止状態",
            "ログオフ"});
            this.ShutdownTypeComboBox.Location = new System.Drawing.Point(96, 43);
            this.ShutdownTypeComboBox.Name = "ShutdownTypeComboBox";
            this.ShutdownTypeComboBox.Size = new System.Drawing.Size(102, 20);
            this.ShutdownTypeComboBox.TabIndex = 2;
            // 
            // ShutdownTimeLabel
            // 
            this.ShutdownTimeLabel.AutoSize = true;
            this.ShutdownTimeLabel.Location = new System.Drawing.Point(37, 16);
            this.ShutdownTimeLabel.Name = "ShutdownTimeLabel";
            this.ShutdownTimeLabel.Size = new System.Drawing.Size(53, 12);
            this.ShutdownTimeLabel.TabIndex = 3;
            this.ShutdownTimeLabel.Text = "執行時刻";
            this.ShutdownTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShutdownTypeLabel
            // 
            this.ShutdownTypeLabel.AutoSize = true;
            this.ShutdownTypeLabel.Location = new System.Drawing.Point(37, 46);
            this.ShutdownTypeLabel.Name = "ShutdownTypeLabel";
            this.ShutdownTypeLabel.Size = new System.Drawing.Size(53, 12);
            this.ShutdownTypeLabel.TabIndex = 4;
            this.ShutdownTypeLabel.Text = "終了方法";
            this.ShutdownTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ShutdownTimePicker
            // 
            this.ShutdownTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ShutdownTimePicker.Location = new System.Drawing.Point(96, 13);
            this.ShutdownTimePicker.Name = "ShutdownTimePicker";
            this.ShutdownTimePicker.ShowUpDown = true;
            this.ShutdownTimePicker.Size = new System.Drawing.Size(67, 19);
            this.ShutdownTimePicker.TabIndex = 5;
            // 
            // ReminderLabel
            // 
            this.ReminderLabel.AutoSize = true;
            this.ReminderLabel.Location = new System.Drawing.Point(32, 76);
            this.ReminderLabel.Name = "ReminderLabel";
            this.ReminderLabel.Size = new System.Drawing.Size(58, 12);
            this.ReminderLabel.TabIndex = 6;
            this.ReminderLabel.Text = "リマインダー";
            this.ReminderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReminderCheckBox
            // 
            this.ReminderCheckBox.AutoSize = true;
            this.ReminderCheckBox.Checked = true;
            this.ReminderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ReminderCheckBox.Location = new System.Drawing.Point(96, 74);
            this.ReminderCheckBox.Name = "ReminderCheckBox";
            this.ReminderCheckBox.Size = new System.Drawing.Size(140, 16);
            this.ReminderCheckBox.TabIndex = 7;
            this.ReminderCheckBox.Text = "　　　　  分前に通知する";
            this.ReminderCheckBox.UseVisualStyleBackColor = true;
            this.ReminderCheckBox.CheckedChanged += new System.EventHandler(this.ReminderCheckBox_CheckedChanged);
            // 
            // ReminderTextBox
            // 
            this.ReminderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReminderTextBox.Location = new System.Drawing.Point(113, 73);
            this.ReminderTextBox.Name = "ReminderTextBox";
            this.ReminderTextBox.Size = new System.Drawing.Size(37, 19);
            this.ReminderTextBox.TabIndex = 8;
            this.ReminderTextBox.Text = "10";
            this.ReminderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IconLinkLabel
            // 
            this.IconLinkLabel.AutoSize = true;
            this.IconLinkLabel.Location = new System.Drawing.Point(12, 118);
            this.IconLinkLabel.Name = "IconLinkLabel";
            this.IconLinkLabel.Size = new System.Drawing.Size(86, 12);
            this.IconLinkLabel.TabIndex = 9;
            this.IconLinkLabel.TabStop = true;
            this.IconLinkLabel.Text = "icon by ICONS8";
            this.IconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IconLinkLabel_LinkClicked);
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(187, 117);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(68, 21);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TweakTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 150);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.IconLinkLabel);
            this.Controls.Add(this.ReminderTextBox);
            this.Controls.Add(this.ReminderCheckBox);
            this.Controls.Add(this.ReminderLabel);
            this.Controls.Add(this.ShutdownTimePicker);
            this.Controls.Add(this.ShutdownTypeLabel);
            this.Controls.Add(this.ShutdownTimeLabel);
            this.Controls.Add(this.ShutdownTypeComboBox);
            this.Controls.Add(this.ApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TweakTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帰宅警察";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ComboBox ShutdownTypeComboBox;
        private System.Windows.Forms.Label ShutdownTimeLabel;
        private System.Windows.Forms.Label ShutdownTypeLabel;
        private System.Windows.Forms.DateTimePicker ShutdownTimePicker;
        private System.Windows.Forms.Label ReminderLabel;
        private System.Windows.Forms.CheckBox ReminderCheckBox;
        private System.Windows.Forms.TextBox ReminderTextBox;
        private System.Windows.Forms.LinkLabel IconLinkLabel;
        private System.Windows.Forms.Button OkButton;
    }
}