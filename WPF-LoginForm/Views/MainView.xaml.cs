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
using System.Windows.Shapes;
using WPF_LoginForm.Models;
using WPF_LoginForm.ViewModels;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();

            string currentTheme = ThemeManager.GetCurrentThemeName();

            if (currentTheme == "dakr")
            {
                switchTheme.IsChecked = true;
                ThemeManager.ToggleTheme();
                ThemeManager.ApplyTheme(bg, bgs);
            }
            else
            {
                switchTheme.IsChecked = false;
            }

            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void userDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ThemeName = "Dark";
            Properties.Settings.Default.Save();
            ThemeManager.ApplyTheme(bg, bgs);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            //Properties.Settings.Default.ThemeName = "Light";
            //Properties.Settings.Default.Save();
            //ThemeManager.ApplyTheme(bg, bgs);
        }

       
    }
}
