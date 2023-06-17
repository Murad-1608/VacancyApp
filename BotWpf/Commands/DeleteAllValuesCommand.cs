using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebBot.Commands;
using WebBot.ViewModels;

namespace BotWpf.Commands
{
    public class DeleteAllValuesCommand : BaseCommand
    {
        HomeWindowViewModel viewModel;
        public DeleteAllValuesCommand(HomeWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.JobService.DeleteAll();

            MessageBox.Show("Uğurla yekunlaşdı");
        }
    }
}
