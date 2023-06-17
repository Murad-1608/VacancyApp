using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WebBot.ViewModels;
using WebBot.Views;

namespace BotWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            HomeWindow homeWindow = new HomeWindow();

            HomeWindowViewModel viewModel = new HomeWindowViewModel(new JobManager(new JobDal()), new CityManager(new CityDal()), new CategoryManager(new CategoryDal())
                                                                   , new SubCategoryManager(new SubCategoryDal()),
                                                                      new EducationManager(new EducationDal()),
                                                                      new ExperienceManager(new ExperienceDal()));

            homeWindow.DataContext = viewModel;

            homeWindow.Show();
        }
    }
}
