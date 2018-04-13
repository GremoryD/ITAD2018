using Project_ITAD.UI_controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для LessonParameters.xaml
    /// </summary>
    public partial class LessonParameters : Window
    {
        public List<Brush> ColorsList { get; set; } 
        public Brush SelectedColor1 { get; set; }
        public Brush SelectedColor2 { get; set; }


        public List<VerticalAlignment> TextAligmentListVertical { get; set; }
        public VerticalAlignment SelectedTextAligmentVertical { get; set; }

        public List<HorizontalAlignment> TextAligmentListHorizontal { get; set; }
        public HorizontalAlignment SelectedTextAligmentHorizontal { get; set; }

        Lesson__UI lesson_;
        public LessonParameters(Lesson__UI lesson)
        {
            InitializeComponent();
            lesson_ = lesson;

            Element_name.Text = lesson_.Lesson_Name.Content.ToString();

            ColorsList = new List<Brush>()
                      { 
                    Brushes.Black,
                    Brushes.White, 
                    Brushes.Red, 
                    Brushes.Pink, 
                    Brushes.Green, 
                    Brushes.Blue, 
                    Brushes.Gold,
                    Brushes.DarkBlue,
                    Brushes.Aqua,
                    Brushes.Chocolate,
                    Brushes.Orange,
                    Brushes.Plum,
                    Brushes.HotPink,
                    Brushes.DeepSkyBlue,
                    Brushes.DarkGreen,
                    Brushes.DarkGray,
                    Brushes.Navy,
                    Brushes.Violet,
                    Brushes.WhiteSmoke  
             };

            SelectedColor1 = Brushes.White;
            SelectedColor2 = Brushes.Black;

            TextAligmentListVertical = new List<VerticalAlignment>()
                      {
                VerticalAlignment.Center,
                VerticalAlignment.Bottom,
                VerticalAlignment.Top,
                VerticalAlignment.Stretch
             };


            TextAligmentListHorizontal = new List<HorizontalAlignment>()
            {
                HorizontalAlignment.Center,
                HorizontalAlignment.Right,
                HorizontalAlignment.Left, 
                HorizontalAlignment.Stretch
            };

            DataContext = this;
             

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lesson_.Lesson_Name.VerticalAlignment = SelectedTextAligmentVertical;
                lesson_.Lesson_Name.HorizontalAlignment = SelectedTextAligmentHorizontal;
                lesson_.Lesson_Name.Background = SelectedColor1;
                lesson_.Lesson_Name.Foreground = SelectedColor2;
                lesson_.Lesson_Name.Content = Element_name.Text;

            this.Close();

        }
    } 




}
