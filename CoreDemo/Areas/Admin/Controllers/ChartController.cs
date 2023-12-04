using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category
            {
                categoryname = "Teknoloji",
                categorycount = 10,
            });
            list.Add(new Category
            {
                categoryname = "Yazılım",
                categorycount = 14,
            });
            list.Add(new Category
            {
                categoryname = "Spor",
                categorycount = 5,
            });
            list.Add(new Category
            {
                categoryname = "Sinema",
                categorycount = 5,
            });
            return Json(new { jsonlist = list });
        }
    }
}
