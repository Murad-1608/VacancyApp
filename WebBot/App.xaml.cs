using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WebBot.ViewModels;
using WebBot.Views;

namespace WebBot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            HomeWindow homeWindow = new HomeWindow();

            HomeWindowViewModel viewModel = new HomeWindowViewModel();

            homeWindow.DataContext = viewModel;

            homeWindow.Show();
        }

    }
}
