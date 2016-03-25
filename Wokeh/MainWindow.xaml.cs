using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Wokeh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool pinS;
        int switchF = 0;
        Functions fun = new Functions();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TitleWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnPin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (pinS == true)
            {
                this.Topmost = false;
                pinS = false;
                btnPin.Foreground = Brushes.Black;
            }
            else
            {
                this.Topmost = true;
                pinS = true;
                btnPin.Foreground = Brushes.Red;
            }
            
        }

        private void htmlEncode_Click(object sender, RoutedEventArgs e)
        {
            switchF = 0;
            this.Title = "Wokeh HTML Encoder";
            TitleWindow.Content = "Wokeh HTML Encoder";
            action.Content = "Encode";
        }

        private void htmlDecode_Click(object sender, RoutedEventArgs e)
        {
            switchF = 1;
            this.Title = "Wokeh HTML Decoder";
            TitleWindow.Content = "Wokeh HTML Decoder";
            action.Content = "Decode";
        }

        private void imgEncode_Click(object sender, RoutedEventArgs e)
        {
            switchF = 2;
            this.Title = "Wokeh Image Encoder";
            TitleWindow.Content = "Wokeh Image Encoder";
            action.Content = "Open File";
        }
        
        private void action_Click(object sender, RoutedEventArgs e)
        {
            if (switchF == 0)
            {
                preview.Text = fun.encodeHTML();
            }
            else if (switchF == 1)
            {
                preview.Text = fun.decodeHTML();
            }
            else if (switchF == 2)
            {
                preview.Text = fun.toBase64();
            }
            else
            {
                preview.Text = "Opps!";
            }
        }

        private void preview_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            preview.Text = "Wokeh\n"+
                "A Simple Offline Blogger Tool\n\n"+
                "Tunggu dulu, kamu bener - bener pake alat ini?\n"+
                "Ahh, Aku cuma ga nyangka aplikasi ini berguna.\n\n"+
                "Jika kamu anggap aplikasi ini benar - benar berguna, Beri bintang atau ikut berkontribusi disini:\n"+
                "https://github.com/rmsubekti/wokeh\n\n" +
                "Atau bantu Laporkan Error / kesalahan :\n"+
                "https://github.com/rmsubekti/wokeh/issues";
        }
    }
}
