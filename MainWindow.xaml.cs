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
using System.Windows.Threading;

namespace WpfApp3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        int xSebesseg = 10;
        int ySebesseg = 10;
        public MainWindow() {
            InitializeComponent();
            var gen = new Random();
            Canvas.SetLeft(labda, gen.Next(1000) - labda.Width / 2); //labda x-e
            Canvas.SetTop(labda, 200.0); //labda y-ja
            Canvas.SetLeft(uto, 500.0 - uto.Width / 2); //uto x-e
            Canvas.SetTop(uto, 500.0); //uto y-ja
            //debug.Content = uto.Width / 2;
            var idozito = new DispatcherTimer();
            idozito.Interval = TimeSpan.FromMilliseconds(1);
            idozito.Tick += idoLepes;
            idozito.Start();
        }

        private void idoLepes(object sender, EventArgs e) {
            Canvas.SetLeft(uto, Mouse.GetPosition(jatekter).X - uto.Width / 2); //uto x-e
            if (Canvas.GetLeft(labda) < 0 || Canvas.GetLeft(labda) > 950) xSebesseg *= -1;
            if (Canvas.GetTop(labda) < 0 || Canvas.GetTop(labda) > 550) ySebesseg *= -1;
            Canvas.SetLeft(labda, Canvas.GetLeft(labda) + xSebesseg);
            Canvas.SetTop(labda, Canvas.GetTop(labda) + ySebesseg);

            Point pozicio = Mouse.GetPosition(jatekter);
            int Xpozicio = (int)pozicio.X;
            if(Xpozicio < 0) Xpozicio = 0;
            if(Xpozicio > 885) Xpozicio = 885;

            Canvas.SetLeft(uto, Xpozicio - uto.Width / 2);

            var utoX = Canvas.GetLeft(uto);
            var utoY = Canvas.GetRight(uto);
            var utoXMeret = uto.Width;
            var utoYMeret = uto.Height;
            var labdaX = Canvas.GetLeft(labda);
            var labdaY = Canvas.GetRight(labda);
            var labdaMeret = labda.Width;
            var db = 0;

            if(labdaX+labdaMeret > utoX && labdaX < utoX + utoXMeret && labdaY + labdaMeret > utoY && labdaY < utoY+ utoYMeret)
            {
                ySebesseg *= -1;
                db++;
                
            }
            //debug.Content = db;
            else
            {
                debug.Content
            }

        }
    }
}
