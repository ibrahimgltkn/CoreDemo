using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListhWithCategory();
            return View(values);
        }

		public IActionResult BlogReadAll(int id)
		{
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
			return View(values);
		}
	}
}
