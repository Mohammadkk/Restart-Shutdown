using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRestartShutdown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRestart_Click_1(object sender, RoutedEventArgs e)
        {
            // Reboot
            System.Diagnostics.Process.Start("ShutDown", "/r /t 0");
            Application.Current.Shutdown();
        }

        private void btnShutdown_Click_1(object sender, RoutedEventArgs e)
        {
            // Shutdown
            System.Diagnostics.Process.Start("ShutDown", "/s /t 0");
            Application.Current.Shutdown();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            // Exit
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            dispatcherTimer.Start();
        }

        private void grdWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                grdWindow.Cursor = Cursors.SizeAll;
                this.DragMove();
            }
            if (e.ButtonState == MouseButtonState.Released)
            {
                grdWindow.Cursor = Cursors.Arrow;
            }
        }
    }
}
