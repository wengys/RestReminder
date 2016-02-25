using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestReminder
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var time = e.Args[0];

            ReminderWindow rw = new ReminderWindow(TimeSpan.Parse(e.Args[0]));
            rw.ReminderDone += (s, ea) =>
            {
                this.Shutdown();
            };
            rw.Show();
        }
    }
}