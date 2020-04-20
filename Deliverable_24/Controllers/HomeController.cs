using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deliverable_24.Models;
using Deliverable_24.EntityModels;
using Microsoft.AspNetCore.Http;

namespace Deliverable_24.Controllers
{
    public class HomeController : Controller
    {
        private ShopDBContext _context = new ShopDBContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeNewUser([Bind("FirstName,LastName,Email,Password,Balance")] User u)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ShopDBContext())
                {
                    var user = new User()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Password = u.Password,
                        Balance = u.Balance
                    };
                    context.Users.Add(u);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
        }

        public IActionResult Items()
        {
            var items = _context.Items.ToList();
            List<Items> itemsForView = new List<Items>();
            int userId = 0;
            if (HttpContext.Session.IsAvailable)
            {
                userId = (int)(HttpContext.Session.GetInt32("UserId"));
            }
            var user = _context.Users.Find(userId);
            foreach (var item in items)
            {
                var tempItem = new Items()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price
                };
                itemsForView.Add(tempItem);
            }

            return View(itemsForView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
