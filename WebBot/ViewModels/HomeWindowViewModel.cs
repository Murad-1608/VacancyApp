using WebBot.Commands;

namespace WebBot.ViewModels
{
    public class HomeWindowViewModel
    {
        public GetDataCommand GetDataCommand => new GetDataCommand(this);
    }
}
