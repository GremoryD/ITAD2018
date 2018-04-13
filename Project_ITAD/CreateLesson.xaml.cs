using Project_ITAD.UI_controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CreateLesson.xaml
    /// </summary>
    public partial class CreateLesson : Window
    {
        MainWindow wind;

        public CreateLesson(MainWindow window)
        {
            wind = window;
            InitializeComponent();
            for(int i=0;i<window.eve.Day_panel.Items.Count;i++)
            TabSelect.Items.Add((window.eve.Day_panel.Items[i] as TabItem).Header.ToString());
            

        }

        private void MouseLeftButtonDown_Grid(object sender, MouseButtonEventArgs e)
        {
            if (CaptureText.Text == "") return;

            Grid temp = sender as Grid;
            temp.Background = Brushes.Yellow; 
            string[] numbers = Regex.Split((temp.Children[0] as Label).Content.ToString(), @"[^\d]");
             

            Lesson__UI lestemp = new Lesson__UI(wind);
            lestemp.X = int.Parse(numbers[0]);
            lestemp.Y = int.Parse(numbers[1]);
            lestemp.page = TabSelect.SelectedIndex;
            lestemp.Lesson_Name.Content = CaptureText.Text;
            lestemp.HorizontalAlignment = HorizontalAlignment.Stretch;
            lestemp.VerticalAlignment = VerticalAlignment.Stretch;
            wind.eve.LabelList.Add(lestemp);
            wind.eve.Add_Lesson(lestemp);
            ((wind.eve.Day_panel.Items[TabSelect.SelectedIndex] as TabItem).Content as Grid).Children.Add(lestemp);


            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
         

        private void TabSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Draw();
        }


        void Draw()
        {

            PlaceChosse.ColumnDefinitions.Clear();
            PlaceChosse.RowDefinitions.Clear();

            for (int i = 0; i < ((wind.eve.Day_panel.Items[TabSelect.SelectedIndex] as TabItem).Content as Grid).RowDefinitions.Count; i++)
            {
                RowDefinition gridRow1 = new RowDefinition();
                PlaceChosse.RowDefinitions.Add(gridRow1);
            }

            for (int j = 0; j < ((wind.eve.Day_panel.Items[TabSelect.SelectedIndex] as TabItem).Content as Grid).ColumnDefinitions.Count; j++)
            {
                ColumnDefinition gridCol1 = new ColumnDefinition();
                PlaceChosse.ColumnDefinitions.Add(gridCol1);
            }



            for (int i = 0; i < ((wind.eve.Day_panel.Items[TabSelect.SelectedIndex] as TabItem).Content as Grid).RowDefinitions.Count; i++)
            {

                for (int j = 0; j < ((wind.eve.Day_panel.Items[TabSelect.SelectedIndex] as TabItem).Content as Grid).ColumnDefinitions.Count; j++)
                {

                    Grid grd = new Grid();
                    grd.Background = Brushes.Green;
                    grd.Children.Add(new Label()
                    {
                        Name = "Coordinate",
                        Content = i + ":" + j,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    grd.MouseLeftButtonDown += MouseLeftButtonDown_Grid;
                    PlaceChosse.Children.Add(grd);
                    Grid.SetRow(grd, j);
                    Grid.SetColumn(grd, i);


                    for (int y = 0; y < wind.eve.LabelList.Count; y++)
                    {

                        if (wind.eve.LabelList[y].X == i && wind.eve.LabelList[y].X == j && wind.eve.LabelList[y].page == TabSelect.SelectedIndex)
                        {
                            grd = new Grid();
                            grd.Background = Brushes.Red;
                            Grid.SetRow(grd, j);
                            Grid.SetColumn(grd, i);
                            PlaceChosse.Children.Add(grd);
                        }

                    }

                }

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Draw();
        }
    }
}
