using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents
{
    public class Filter : ViewComponent
    {
        private readonly ITypeService typeService;
        public Filter(ITypeService typeService)
        {
            this.typeService = typeService;
        }

        public IViewComponentResult Invoke()
        {
            FilterDto filterDto = new FilterDto();

            filterDto.Types = typeService.GetAll().Data;

            return View(filterDto);
        }
    }
}
