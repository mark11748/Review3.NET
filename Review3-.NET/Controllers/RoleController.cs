using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Review3_.NET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Review3_.NET.Controllers
{
    public class RoleController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<User> _userManager;

        public RoleController(UserManager<User> userManager, MyContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string newRole)
        {
            try
            {
                _db.Roles.Add(new IdentityRole()
                {
                    Name = newRole
                });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string RoleName)
        {
            var unwantedRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(unwantedRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Manage()
        {
            // prepopulat roles for the view dropdown
            var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name, Text = rr.Name }).ToList();
            return View(roleList);
        }
        [HttpPost]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            User user = _db.Users.Where(u => u.UserName.Equals(UserName)).FirstOrDefault();
            _userManager.AddToRoleAsync(user, RoleName);
            //^^^MSDN Says 1st arg is id not instance
            ViewBag.ResultMessage = "Role created successfully !";

            var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => 
                new SelectListItem { Value = rr.Name, Text = rr.Name }).ToList();

            return View("Manage",roleList);
        }
        [HttpPost]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                User user = _db.Users.Where(u => u.UserName.Equals(UserName)).FirstOrDefault();

                ViewBag.RolesForThisUser = _userManager.GetRolesAsync(user);

                // prepopulat roles for the view dropdown
                var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => 
                    new SelectListItem { Value = rr.Name, Text = rr.Name }).ToList();

                return View("Manage", roleList);
            }
            else 
            { 
                var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                    new SelectListItem { Value = rr.Name, Text = rr.Name }).ToList();
                return View("Manage",roleList); 
            }

        }
        [HttpPost]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            User user = _db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //if (_userManager.IsInRoleAsync(user, RoleName))

                _userManager.RemoveFromRoleAsync(user, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
           
            var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => 
                new SelectListItem { Value = rr.Name, Text = rr.Name }).ToList();

            return View("Manage",roleList);
        }

    }
}
