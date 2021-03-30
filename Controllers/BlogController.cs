using System.Threading.Tasks;
using LeadSpider.Data.Repository;
using LeadSpider.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeadSpider.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _repo;
        public BlogController(IBlogRepository repo)
        {
            _repo = repo;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.AddPost(post);

            if(await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(post);
        }
    }
}