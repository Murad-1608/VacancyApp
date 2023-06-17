using System;
using System.Collections.Generic;
using System.Windows.Input;
using WebBot.GetValuesBot;
using WebBot.ViewModels;

namespace WebBot.Commands
{
    public class GetDataCommand : BaseCommand
    {
        private readonly HomeWindowViewModel viewModel;

        public GetDataCommand(HomeWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            List<Job>

            Bot.GetValues();
        }
    }
}
