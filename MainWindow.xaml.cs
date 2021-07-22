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
using Newtonsoft.Json;

namespace ResBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Menu Menu;
        public MainWindow()
        {
            InitializeComponent();
            if(File.Exists("Menu.json"))
                Menu = JsonConvert.DeserializeObject(File.ReadAllText("Menu.json")) as Menu;
            else
            {
                MessageBox.Show("Pls add 'Menu.json'");
                Close();
            }
        }


        void AddTable(string Table)
        {
            Border border = new Border()
            {
                Name = "_" + Table,
                Background = new BrushConverter().ConvertFromString("#FFE5E5E5") as Brush,
                Height = 300,
                Width = 260,
                Margin = new Thickness(10),
                CornerRadius = new CornerRadius(20)
            };
            Grid grid = new Grid()
            {
                Margin = new Thickness(10)
            };
            Label title = new Label()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Content = $"{Table}-Stol",
                FontWeight = FontWeights.Bold,
                FontSize = 20
            };
            ListBox listBox = new ListBox()
            {
                Margin = new Thickness(0, 50, 0, 30)
            };

            Button add = new Button()
            {
                Content = "Add",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(5, 5, 0, 5),
                Width = 100
            };
            Button close = new Button()
            {
                Content = "Close",
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 5, 5, 5),
                Width = 100
            };
            grid.Children.Add(title);
            grid.Children.Add(listBox);
            grid.Children.Add(close);
            grid.Children.Add(add);
            border.Child = grid;
            Tables.Children.Add(border);
        }
        void AddFood(Food food)
        {
            Border MainPanel = new Border()
            {
                Background = ColorConverter.ConvertFromString("#dddddd") as Brush,
                Height = 20,
                CornerRadius = new CornerRadius(5),
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5)
            };
            Grid grid = new Grid()
            { 
                Margin = new Thickness(5),
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            var del_btn = new Label
            {
                Content = "X",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            del_btn.MouseDown += Del_btn_MouseDown;
            Border del = new Border
            {
                Background = Brushes.Red,
                Width = 30,
                Height = 30,
                Cursor = Cursors.Hand,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                CornerRadius = new CornerRadius(100),
                Child = del_btn
            };
            grid.Children.Add(del);
            var id = new Label
            {

                Content = food.ID,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25
            };
            Grid.SetColumn(id, 0);
            grid.Children.Add(id);
            var name = new Label
            {

                Content = food.Name,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25
            };
            Grid.SetColumn(name, 1);
            grid.Children.Add(name);
            var coast = new Label
            {

                Content = food.Coast,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25
            };
            Grid.SetColumn(coast, 2);
            grid.Children.Add(coast);
            var rank = new Label
            {

                Content = food.Rank,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 25
            };
            Grid.SetColumn(rank, 3);
            grid.Children.Add(rank);
            

            MainPanel.Child = grid;
            MenuStack.Children.Add(MainPanel);
        }

        private void Del_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var MainPan = ((sender as Label).Parent as Grid).Parent as Border;
            var stack = MainPan.Parent as StackPanel;
            stack.Children.Remove(MainPan);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var grid = btn.Parent as Grid;
            var label = grid.Children[0] as Label;
            var listBox = grid.Children[1] as ListBox;
            label.Content = "1-stol";
            listBox.Items.Add(1);
            var border = grid.Parent as Border;
            var id = int.Parse(border.Name.Substring(1));
            AddWindow add = new AddWindow() 
            {
                Menu = Menu,
                label = label,
                listBox = listBox
            };

            add.ShowDialog();
            
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
