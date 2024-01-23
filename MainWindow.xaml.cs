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
        Ball ball;
        Player mousePlayer, keyboardPlayer;

        public MainWindow() {
            InitializeComponent();
            ball = new(10, 10, MainCanvas);
            DispatcherTimer timer = new();
            mousePlayer = new(MainCanvas, 10, 100, new SolidColorBrush(Color.FromRgb(255, 255, 255)), false);
            keyboardPlayer = new(MainCanvas, 10, 100, new SolidColorBrush(Color.FromRgb(255, 255, 255)), true);
            timer.Interval=TimeSpan.FromMilliseconds(16);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e) {
            if (ball.X <= 0) {

            }
            if(ball.X>=MainCanvas.Width) {

            }
            if (ball.Y >= mousePlayer.Y && ball.Y <= mousePlayer.Y + mousePlayer.Height && ball.X >= mousePlayer.X - ball.Width && ball.X <= mousePlayer.X + mousePlayer.Width) {
                ball.DirectionX *= -1;
                ball.Speed += 0.5f;
            }
            if (ball.Y >= keyboardPlayer.Y && ball.Y <= keyboardPlayer.Y + keyboardPlayer.Height && ball.X <= keyboardPlayer.X + ball.Width && ball.X >= keyboardPlayer.X) {
                ball.DirectionX *= -1;
                ball.Speed += 0.5f;
            }
            ball.Move();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            switch(e.Key)
            {
                case Key.Escape:
                    this.Close();
                    break;
                case Key.W:
                    if (keyboardPlayer.Y <= 0)
                        return;
                    keyboardPlayer.Y -= 10;
                    keyboardPlayer.Draw();
                    break;
                case Key.S:
                    if (keyboardPlayer.Y + keyboardPlayer.Height >= MainCanvas.Height)
                        return;
                    keyboardPlayer.Y += 10;
                    keyboardPlayer.Draw();
                    break;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e) {
            if (Mouse.GetPosition(this).Y + mousePlayer.Height >= MainCanvas.Height)
                return;
            mousePlayer.Y = Mouse.GetPosition(this).Y;
            mousePlayer.Draw();      
        }
    }
}