using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KitakPolice.Domain;
using KitakPolice.Domain.InputPort;

namespace KitakPolice.Controller
{
    public partial class TweakTimeForm : Form
    {
        private readonly ITweakService TweakService;
        public TweakTimeForm(ITweakService tweakService)
        {
            TweakService = tweakService;
            InitializeComponent();
            var plan = TweakService.GetCurrentShutdownPlan();
            ShutdownTimePicker.Value = plan.ExecutionTime;
            ReminderCheckBox.Checked = plan.EnebleReminder;
            ReminderTextBox.Text = plan.ReminderBeforeMinutes.ToString();
            ShutdownTypeComboBox.SelectedIndex = GetDefaultShutdownType(plan.ExecutionKind);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var plan = TweakService.GetCurrentShutdownPlan();
            plan.ExecutionKind = GetShutdownType();
            plan.ExecutionTime = GetShutdownTime();
            plan.EnebleReminder = ReminderCheckBox.Checked;
            if (Regex.IsMatch(ReminderTextBox.Text, "^[0-9]+$"))
            {
                plan.ReminderBeforeMinutes = uint.Parse(ReminderTextBox.Text);
            }
            TweakService.TweakShutdownPlan(plan);
            MessageBox.Show("設定を保存しました。");
        }

        private DateTime GetShutdownTime()
        {
            return ShutdownTimePicker.Value;
        }

        private int GetDefaultShutdownType(ExecutionKind kind)
        {
            switch (kind)
            {
                case ExecutionKind.Shutdown: return 0;
                case ExecutionKind.Hibernate: return 1;
                case ExecutionKind.Logoff: return 2;
                default: return 0;
            }
        }

        private ExecutionKind GetShutdownType()
        {
            switch (ShutdownTypeComboBox.SelectedIndex)
            {
                case 0: return ExecutionKind.Shutdown;
                case 1: return ExecutionKind.Hibernate;
                case 2: return ExecutionKind.Logoff;
                default: return 0;
            }
        }

        private void ReminderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ReminderTextBox.Enabled = ReminderCheckBox.Checked;
        }

        private void IconLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com");
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ApplyButton_Click(sender, e);
            Close();
        }
    }
}
