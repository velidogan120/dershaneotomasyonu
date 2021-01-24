using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dershane.business.Abstract;

namespace dershane.webui.ViewComponents
{
    public class BolumlerViewComponent:ViewComponent
    {
        private IBolumService _bolumService;
        public BolumlerViewComponent(IBolumService bolumService){
            this._bolumService=bolumService;
        }

        public IViewComponentResult Invoke(){
            if(RouteData.Values["bolum"]!=null)
            ViewBag.SelectedBolum = RouteData?.Values["bolum"];
                return View(_bolumService.GetAll());
        }
    }
}