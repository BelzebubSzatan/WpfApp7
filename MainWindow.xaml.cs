using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp7 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DispatcherTimer timer = new();
            timer.Interval=TimeSpan.FromMilliseconds(16);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {

        }
    }
}