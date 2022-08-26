using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication15.Models;

namespace cart_Example.Controllers
{
    public class PurchaseControllers : Controller
    {

        private CategoriesContext _context;
        private IHttpContextAccessor _accessor;
        public PurchaseControllers(CategoriesContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }



        public IActionResult GetCategories()
        {
            return View(_context.categorys.ToList());
        }



        [Authorize]
        public IActionResult GetProducts(int id)
        {
            return View(_context.products.Where(e => e.categID == id).ToList());
        }
        [HttpPost]
        public IActionResult Getproducts(List<product>plist)
        {
            foreach (product p in plist)
            {
                if (p.check)
                {
                    cart c = new cart()
                    {
                        prodID = p.id,
                        categid = p.categID,
                        dt = DateTime.Now,
                        user = _accessor.HttpContext.User.Identity.Name
                    };
                    _context.carts.Add(c);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("GetCategories");
        }
    }
        
}
