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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace Project_ITAD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Event_control eve; 

        public MainWindow()
        {
            InitializeComponent();
        }

        //Menu new event buttonClic
        public void NewEvent_Click(object sender, RoutedEventArgs e)
        {
            eve = new Event_control();
            eve.Background = Brushes.DarkSlateGray;
            eve.Margin = new Thickness(0, 10, 0, 0); 
            MainGrid.Children.Add(eve);
            ElementComponents.IsEnabled = true;
        }

        private void Add_Day_Click(object sender, RoutedEventArgs e)
        {
            eve.AddTab_day();
        }

        private void DeleteDayButton_Click(object sender, RoutedEventArgs e)
        {
            eve.DeleteTab_day();
        }

        private void Add_TimeLine_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Column_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                eve.Add_Column((eve.Day_panel.SelectedItem as TabItem).Content as Grid);
            }catch(Exception ex)
            { 
            }
        }

        private void Add_Row_Click(object sender, RoutedEventArgs e)
        {
            eve.Add_Row((eve.Day_panel.SelectedItem as TabItem).Content as Grid);
        }

        private void Add_Lesson_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateLesson createLesson = new CreateLesson(this);
            createLesson.Show();

        }

        private void Content_Box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ITAD file (*.itad)|*.itad";
            if (saveFileDialog.ShowDialog() == true)
            { 
                 
                SerializeObject<Event_control>(eve, saveFileDialog.FileName);
 
            } 

        }

        private void Genareta_Click(object sender, RoutedEventArgs e)
        {
            GenareteVindow window = new GenareteVindow(eve);
            window.Show();
        }

         


        private void Open_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog(); 

            theDialog.CheckFileExists = true;
            theDialog.CheckPathExists = true;
            theDialog.Multiselect = false;
            theDialog.FileName = string.Empty;
 

        }



         
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }

         
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

            return objectOut;
        }
    }
}
