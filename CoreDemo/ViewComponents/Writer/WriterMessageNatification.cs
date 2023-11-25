using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNatification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
