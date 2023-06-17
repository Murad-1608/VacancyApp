using BotWpf.Commands;
using BotWpf.ViewModels;
using Business.Abstract;
using WebBot.Commands;

namespace WebBot.ViewModels
{
    public class HomeWindowViewModel : BaseViewModel
    {
        public IJobService JobService;
        public ICityService CityService;
        public ICategoryService CategoryService;
        public ISubCategoryService SubCategoryService;
        public IEducationService EducationService;
        public IExperienceService ExperienceService;
        public HomeWindowViewModel(IJobService jobService, ICityService cityService, ICategoryService categoryService, ISubCategoryService subCategoryService, IEducationService educationService, IExperienceService experienceService)
        {
            JobService = jobService;
            CityService = cityService;
            CategoryService = categoryService;
            SubCategoryService = subCategoryService;
            EducationService = educationService;
            ExperienceService = experienceService;
        }



        public GetDataCommand GetDataCommand => new GetDataCommand(this);
        public DeleteAllValuesCommand DeleteAllValuesCommand => new DeleteAllValuesCommand(this);

        private int getValueCount = 0;
        public int GetValueCount
        {
            get
            {
                return getValueCount;
            }
            set
            {
                getValueCount= value;
                OnPropertyChanged(nameof(GetValueCount));
            }
        }
    }
}
