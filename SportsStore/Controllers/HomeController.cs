using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
#pragma warning disable S1104
#pragma warning disable CS8601

namespace SportsStore.Controllers
{
    public class HomeController: Controller
    {
        private readonly IStoreRepository repository;
        public int PageSize = 5;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int productPage = 1)
         => View(new ProductsListViewModel
         {
             Products = repository.Products
         .Where(p => category == null || p.Category == category)
         .OrderBy(p => p.ProductID)
         .Skip((productPage - 1) * PageSize)
         .Take(PageSize),
             PagingInfo = new PagingInfo
             {
                 CurrentPage = productPage,
                 ItemsPerPage = PageSize,
                 TotalItems = category == null ?
                 repository.Products.Count() :
                 repository.Products.Where(e =>
                 e.Category == category).Count()
             },
             CurrentCategory = category
         });
    }
}
