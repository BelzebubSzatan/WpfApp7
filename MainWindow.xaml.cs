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
        Player mousePlayer, keyboardPlayer;
        public MainWindow() {
            InitializeComponent();
            DispatcherTimer timer = new();
            mousePlayer = new(MainCanvas, 10, 100, new SolidColorBrush(Color.FromRgb(255, 255, 255)), false);
            keyboardPlayer = new(MainCanvas, 10, 100, new SolidColorBrush(Color.FromRgb(255, 255, 255)), true);
            timer.Interval=TimeSpan.FromMilliseconds(16);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            if (Mouse.GetPosition(this).Y + mousePlayer.Height >= MainCanvas.Height)
                return;
            mousePlayer.Y = Mouse.GetPosition(this).Y;
            mousePlayer.Draw();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {

        }
    }
}