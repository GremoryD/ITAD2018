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
    /// Логика взаимодействия для Event_control.xaml
    /// </summary>
    /// 
    [Serializable]
    public partial class Event_control : UserControl
    {
        public List<TabItem> TabItems;
        public  List<Lesson__UI> LabelList;
         



        public Event_control()
        {
            InitializeComponent();
            TabItems = new List<TabItem>();
            LabelList = new List<Lesson__UI>();
            AddTab_day();
        }


        public void AddTab_day()
        {
            TabItem tbitem = new TabItem() { Header = "Day " + (TabItems.Count+1) };
            Grid grd = new Grid();
            grd.ShowGridLines = true;
             

            Add_Column( grd);
            Add_Column( grd);
            Add_Column( grd); 
            Add_Row(grd);
            Add_Row(grd);
            Add_Row(grd); 
            tbitem.Content = grd;
            TabItems.Add(tbitem);
            Day_panel.Items.Add(tbitem); 
        } 


        public void AddTab_day(TabItem tbitem)
        {
             

            TabItems.Add(tbitem);
            Day_panel.Items.Add(tbitem);
        } 


        public void DeleteTab_day()
        {
             

            TabItems.RemoveAt(TabItems.Count - 1);
            Day_panel.Items.RemoveAt(TabItems.Count - 1);
        }

        public void Add_Column(Grid grd)
        {  
            ColumnDefinition gridCol1 = new ColumnDefinition();
            grd.ColumnDefinitions.Add(gridCol1);
        }


        public void Add_Row(Grid grd)
        {  
            RowDefinition gridRow1 = new RowDefinition();
            grd.RowDefinitions.Add(gridRow1);
        }


        public void Add_Lesson(Lesson__UI label)
        {  
            Grid.SetRow(label, label.Y);
            Grid.SetColumn(label, label.X); 

        }

        


    }
}
