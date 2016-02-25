using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestReminder
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ReminderWindow : Window
    {
        public ReminderWindow(TimeSpan reminderDuration) : base()
        {
            this.ReminderDuration = reminderDuration;
            InitializeComponent();
        }

        private TimeSpan ReminderDuration
        {
            get; set;
        }

        public event EventHandler ReminderDone;

        private void Reminder_Activated(object sender, EventArgs e)
        {
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.Top = SystemParameters.WorkArea.Height - this.Height;
            var storyboard = (Storyboard)Resources["storyboard"];
            storyboard.Duration = new Duration(ReminderDuration);
            storyboard.Children[0].Duration = new Duration(ReminderDuration);
            storyboard.CurrentTimeInvalidated += Storyboard_CurrentTimeInvalidated;
            storyboard.Completed += Storyboard_Completed;
            storyboard.Begin(this);
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            ReminderDone?.Invoke(this, EventArgs.Empty);
        }

        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            var currentTime = ReminderDuration - ((ClockGroup)sender).CurrentTime.Value;
            timeDisplay.Text = currentTime.ToString(@"mm\:ss");
        }
    }
}