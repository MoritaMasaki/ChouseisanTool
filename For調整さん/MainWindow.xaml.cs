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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace For調整さん
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] weeks = { "日", "月", "火", "水", "木", "金", "土" };

        public MainWindow()
        {
            InitializeComponent();
            calender.DisplayDateStart = DateTime.Today;
        }

        
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Txt_Output.Text = "";
        }

        private void Btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            string text = Txt_Output.Text;
            if(text!="") Clipboard.SetData(DataFormats.Text, text);
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Txt_Output.Text += MakeText();
        }

        private void Btn_Make_Click(object sender, RoutedEventArgs e)
        {
            Txt_Output.Text = MakeText();
        }

        private string MakeText()
        {
            string text = "";
            var dateTimeArray = new DateTime[0];
            SelectedDatesCollection selDates = calender.SelectedDates;
            dateTimeArray = selDates.ToArray<DateTime>();
            Array.Sort(dateTimeArray);

            int num = selDates.Count;

            foreach(DateTime date in dateTimeArray)
            {
                string dline = "";
                if (Chk_NoDay.IsChecked == true)
                {
                    dline = date.ToString("dddd");
                }
                else
                {
                    dline=date.ToString("M月dd日(ddd)") ;
                }

                if (chk_1st.IsChecked == true)
                {
                    text += dline+" ";
                    if (txt_1st_start.Text != "")
                    {
                        text += txt_1st_start.Text+"-";
                    }
                    if (txt_1st_end.Text != "")
                    {
                        text += txt_1st_end.Text;
                    }
                    text += "\n";
                }

                if (chk_2nd.IsChecked == true)
                {
                    text += dline + " ";
                    if (txt_2nd_start.Text != "")
                    {
                        text += txt_2nd_start.Text + "-";
                    }
                    if (txt_2nd_end.Text != "")
                    {
                        text += txt_2nd_end.Text;
                    }
                    text += "\n";
                }

                if (chk_3rd.IsChecked == true)
                {
                    text += dline + " ";
                    if (txt_3rd_start.Text != "")
                    {
                        text += txt_3rd_start.Text + "-";
                    }
                    if (txt_3rd_end.Text != "")
                    {
                        text += txt_3rd_end.Text;
                    }
                    text += "\n";
                }

                if (chk_4th.IsChecked == true)
                {
                    text += dline + " ";
                    if (txt_4th_start.Text != "")
                    {
                        text += txt_4th_start.Text + "-";
                    }
                    if (txt_4th_end.Text != "")
                    {
                        text += txt_4th_end.Text;
                    }
                    text += "\n";
                }

                if (chk_5th.IsChecked == true)
                {
                    text += dline + " ";
                    if (txt_5th_start.Text != "")
                    {
                        text += txt_5th_start.Text + "-";
                    }
                    if (txt_5th_end.Text != "")
                    {
                        text += txt_5th_end.Text;
                    }
                    text += "\n";
                }

                if (chk_6th.IsChecked == true)
                {
                    text += dline + " ";
                    if (txt_6th_start.Text != "")
                    {
                        text += txt_6th_start.Text + "-";
                    }
                    if (txt_6th_end.Text != "")
                    {
                        text += txt_6th_end.Text;
                    }
                    text += "\n";
                }
            }

            return text;
        }

        /// <summary>
        /// 終了時時間項目だけを保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.start1 = txt_1st_start.Text ;
            Properties.Settings.Default.start2 = txt_2nd_start.Text ;
            Properties.Settings.Default.start3 = txt_3rd_start.Text ;
            Properties.Settings.Default.start4 = txt_4th_start.Text ;
            Properties.Settings.Default.start5 = txt_5th_start.Text ;
            Properties.Settings.Default.start6 = txt_6th_start.Text ;

            Properties.Settings.Default.end1 = txt_1st_end.Text ;
            Properties.Settings.Default.end2 = txt_2nd_end.Text ;
            Properties.Settings.Default.end3 = txt_3rd_end.Text ;
            Properties.Settings.Default.end4 = txt_4th_end.Text ;
            Properties.Settings.Default.end5 = txt_5th_end.Text ;
            Properties.Settings.Default.end6 = txt_6th_end.Text ;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 開始時に時間項目だけを反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_1st_start.Text = Properties.Settings.Default.start1;
            txt_2nd_start.Text = Properties.Settings.Default.start2;
            txt_3rd_start.Text = Properties.Settings.Default.start3;
            txt_4th_start.Text = Properties.Settings.Default.start4;
            txt_5th_start.Text = Properties.Settings.Default.start5;
            txt_6th_start.Text = Properties.Settings.Default.start6;

            txt_1st_end.Text = Properties.Settings.Default.end1;
            txt_2nd_end.Text = Properties.Settings.Default.end2;
            txt_3rd_end.Text = Properties.Settings.Default.end3;
            txt_4th_end.Text = Properties.Settings.Default.end4;
            txt_5th_end.Text = Properties.Settings.Default.end5;
            txt_6th_end.Text = Properties.Settings.Default.end6;
        }
        /// <summary>
        /// 調整さんの起動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Run_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = "https://chouseisan.com/",
                UseShellExecute = true,
            };

            Process.Start(pi);
        }

        /// <summary>
        /// Calendar コントロールがフォーカスを握ったままになる問題の対策
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if ((Mouse.Captured is Calendar) || (Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem))
            {
                Mouse.Capture(null);
            }
        }

    }
}
