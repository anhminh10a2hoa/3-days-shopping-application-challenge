using demo_web_2.Data;
using demo_web_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_web_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult IndexAsync()
        {
            IEnumerable<Product> objList = _db.Product;
            return View(objList);
        }

        public async Task<IActionResult> Create()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    _db.Product.Add(product);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var obj = _db.Product.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                return View(obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product obj)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    _db.Product.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                var obj = _db.Product.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                return View(obj);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var obj = _db.Product.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                _db.Product.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
