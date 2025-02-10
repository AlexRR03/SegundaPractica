using Microsoft.AspNetCore.Mvc;
using SegundaPractica.Models;
using SegundaPractica.Repository;

namespace SegundaPractica.Controllers
{
    public class ComicsController : Controller
    {
        RepositoryComics repo;

        public ComicsController()
        {
            this.repo = new RepositoryComics();
        }
        public IActionResult Index()
        {
            List<Comics> listaComics = this.repo.GetComics();
            return View(listaComics);
        }

        public IActionResult SearchComic() 
        {
            ViewData["NOMBRES"] = this.repo.GetNombreComics();

            return View();
        
        }
                    
        //[HttpPost]
        //public IActionResult SearchComic (string nombreComic)
        //{
            
        //    ViewData["NOMBRES"] = this.repo.GetNombreComics();
        //    Comics comic = this.repo.FindComic(nombreComic);
        //    return View(comic);
        //}
    }
}
