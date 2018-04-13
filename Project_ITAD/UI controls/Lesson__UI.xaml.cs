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

namespace Project_ITAD.UI_controls
{ 


    /// <summary>
    /// Логика взаимодействия для Lesson__UI.xaml
    /// </summary>
    public partial class Lesson__UI : UserControl
    {
        MainWindow wind;
        public int page=0;
        public int X = 0;
        public int Y = 0;

        public Lesson__UI(MainWindow window)
        {
            wind = window;
            InitializeComponent();
        }

        private void Lesson_Name_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LessonParameters leson_param = new LessonParameters(this);
            leson_param.Show();

        }
         
    }
}
