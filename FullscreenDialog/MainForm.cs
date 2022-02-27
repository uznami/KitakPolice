using System;
using System.Windows.Forms;

namespace FullscreenDialog
{
    public partial class MainForm : Form
    {
        private readonly Timer timer = new Timer();
        public MainForm(string message, int? timeoutSeconds)
        {
            InitializeComponent();
            MessageLabel.Text = message;
            if (timeoutSeconds != null)
            {
                timer.Tick += delegate
                {
                    Close();
                };
                timer.Interval = (int)TimeSpan.FromSeconds((double)timeoutSeconds).TotalMilliseconds;
                timer.Start();
            }
        }

        private void MessageLabel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }
    }
}
