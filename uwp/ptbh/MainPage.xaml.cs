using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ptbh
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void State_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            if (s == "")
            {
                return false;
            }
            else if (s.First() == '-' || s.First() == '+')
            {
                for (int i = 1; i < s.Length; i++)
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
            bool dda = false, ddb = false, ddc = false;
            if (!dda || !ddb || !ddc)
            {
                dda = Kiemtratinhdung(soastring);
                ddb = Kiemtratinhdung(sobstring);
                ddc = Kiemtratinhdung(socstring);

            }

            if (dda && ddb && ddc)
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
                        xoarong1();
                    }
                }
            }
            else
            {
                //xoarong1();
                kq.Text = "Giá trị không hợp lệ";
            }
        }

        
}
