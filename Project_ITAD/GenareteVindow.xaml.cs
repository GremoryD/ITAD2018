using Microsoft.Win32;
using Project_ITAD.UI_controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes; 

namespace Project_ITAD
{
    /// <summary>
    /// Логика взаимодействия для GenareteVindow.xaml
    /// </summary>
    public partial class GenareteVindow : Window
    {
        Event_control event_control;

       
        public GenareteVindow(Event_control control)
        {
            InitializeComponent();
            event_control = control;
            foreach(TabItem tb in event_control.Day_panel.Items)
            {

                RenderTargetBitmap rtb = new RenderTargetBitmap((int)(tb.Content as Grid).ActualWidth, (int)(tb.Content as Grid).ActualHeight, 96, 96, PixelFormats.Pbgra32);
                rtb.Render(control);  
                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(rtb));
                MemoryStream stream = new MemoryStream();
                png.Save(stream);


                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.Source = BitmapFrame.Create(stream,BitmapCreateOptions.None,  BitmapCacheOption.OnLoad);
                ImageCreator.Children.Add(image);
                 
            }

            Button btn = new Button();
            btn.Content = "Save";
            btn.Click += Save;

            ImageCreator.Children.Add(btn);


        }

        private void Save(object sender, RoutedEventArgs e)
        {

            RenderTargetBitmap rtb1 = new RenderTargetBitmap((int)ImageCreator.ActualWidth, (int)ImageCreator.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb1.Render(ImageCreator);
            PngBitmapEncoder png1 = new PngBitmapEncoder();
            png1.Frames.Add(BitmapFrame.Create(rtb1));
            MemoryStream stream1 = new MemoryStream();
            png1.Save(stream1);


            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (dlg.ShowDialog() == true)
            {
                var encoder = new JpegBitmapEncoder(); // Or PngBitmapEncoder, or whichever encoder you want
                encoder.Frames.Add(BitmapFrame.Create(stream1, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
                using (var stream = dlg.OpenFile())
                {
                    encoder.Save(stream);
                }
            }
        }
    }
}
