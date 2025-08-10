using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailSideBarSearchBoxComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // This view component does not require any data from the server
            // It simply renders a search box for the blog detail sidebar
            return View();
        }
    }
}
