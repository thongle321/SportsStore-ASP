using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {

        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        /*        public IActionResult Index()
                {
                    return View(repository.Products);
                }*/
        // public ViewResult Index(int productPage = 1) => View(repository.Products
        //                                                 .OrderBy(p => p.ProductID)
        //                                                 .Skip((productPage - 1) * PageSize)
        //                                                 .Take(PageSize));
        public ViewResult Index(int productPage = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}