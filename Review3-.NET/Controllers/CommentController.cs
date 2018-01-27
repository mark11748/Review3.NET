using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Review3_.NET.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review3_.NET.Controllers
{
    public class CommentController : Controller
    {
        private MyContext db = new MyContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}
