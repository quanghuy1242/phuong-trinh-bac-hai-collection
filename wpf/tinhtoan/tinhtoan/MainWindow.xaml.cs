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
using System.Text.RegularExpressions;

namespace tinhtoan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void xoarong(object sender, RoutedEventArgs e)
        {
            a.Text = "";
            b.Text = "";
            c.Text = "";
            kq.Text = "";
        }
        private void xoarong1()
        {
            a.Text = "";
            b.Text = "";
            c.Text = "";
        }
        private static bool Kiemtratinhdung(string s)
        {
            //bool a = false;
            //foreach (char c in s)
            //{
            //    IsDigitsOnly(c);
            //}
            //return a;
            if(s == "")
            {
                return false;
            }
            else if (s.First() == '-' || s.First() == '+')
            {
                for(int i = 1; i < s.Length; i++)
                {
                    if (s[i] < '0' || s[i] > '9')
                    {
                        return false;
                    }
                    else return true;
                }
            }
            return s.All(char.IsDigit);
        }
        private void giai(object sender, RoutedEventArgs e)
        {
            string soastring = a.Text, sobstring = b.Text, socstring = c.Text;
            bool dda=false, ddb = false, ddc = false;
            if (!dda || !ddb || !ddc)
            {
                dda = Kiemtratinhdung(soastring);
                ddb = Kiemtratinhdung(sobstring);
                ddc = Kiemtratinhdung(socstring);

            }
            
            if(dda && ddb && ddc)
            {
                //  PreviewKeyDown="khongspace" PreviewTextInput="kiemtragiatri"
                double soa = double.Parse(a.Text);
                double sob = double.Parse(b.Text);
                double soc = double.Parse(c.Text);
                double delta = sob * sob - 4 * soa * soc;
                double nghiem1, nghiem2;
                if (soa == 0)
                {
                    if (sob == 0)
                    {
                        kq.Text = "Phương Trình vô nghiệm";
                    }
                    if (soc == 0)
                    {
                        kq.Text = "Phương Trình vô số nghiệm";
                    }
                    else
                    {
                        nghiem1 = (-soc) / sob;
                        kq.Text = "x=" + nghiem1.ToString();
                    }
                }
                else
                {
                    if (delta > 0)
                    {
                        nghiem1 = ((-sob) - Math.Sqrt(delta)) / (2 * soa);
                        nghiem2 = ((-sob) + Math.Sqrt(delta)) / (2 * soa);
                        kq.Text = "x1=" + nghiem1.ToString() + " , x2=" + nghiem2.ToString();
                    }
                    else if (delta == 0)
                    {
                        nghiem1 = (-sob) / (2 * soa);
                        kq.Text = "x=" + nghiem1.ToString();
                    }
                    else
                    {
                        kq.Text = "Phương Trình Vô Nghiệm";
                    }
                }
            }
            else
            {
                //xoarong1();
                kq.Text = "Giá trị không hợp lệ";
            }
        }


        

        private void kiemtragiatri(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+[-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void khongspace(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }

        private void Aboutt(object sender, RoutedEventArgs e)
        {
            Window1 abouttt = new Window1();
            abouttt.Tag = "abcd";
            abouttt.ShowDialog();
        }

        private void thoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
