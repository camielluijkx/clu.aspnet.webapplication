using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace clu.aspnet.webapplication.mvc.core.Components
{
    public class MyViewComponent : ViewComponent
    {
        //public Task<IViewComponentResult> InvokeAsync()
        //{
        //    return Task.FromResult<IViewComponentResult>(View("Default"));
        //}

        public async Task<IViewComponentResult> InvokeAsync(int param)
        {
            int id = await SomeOperationAsync(param);
            return View("Default", id);
        }

        private async Task<int> SomeOperationAsync(int param)
        {
            await Task.Run(() => {/* some operation */});
            return param;
        }
    }
}