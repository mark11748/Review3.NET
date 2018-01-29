using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Review3_.NET.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Review3_.NET.Controllers
{
    public class PostController : Controller
    {
        private readonly MyContext _db;
        private readonly UserManager<User> _userManager;

        public PostController(UserManager<User> userManager, MyContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            //get posts associated with user
            IQueryable<Post> blogPosts = _db.Posts.Where(x => x.UserId == currentUser.Id);
            foreach (Post post in blogPosts)
            {
                post.Comments = _db.Comments.Where(c => c.PostId == post.Id);
                foreach (Comment comment in post.Comments)
                {
                    User commentAuthor = await _userManager.FindByIdAsync(comment.UserId);
                    if (commentAuthor != null)
                    { comment.User = commentAuthor; }
                    else
                    { 
                        comment.User = new User { UserName = "Guest" , Email = "N/A" , ImgString = "http://media.culturemap.com/crop/06/03/320x240/Anonymous_Group_logo_this.jpg" }; 
                    } 
                }
            }
            return View();
        }
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            { return View(); }
            else
            { return RedirectToAction("Index"); }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            post.User = currentUser;
            _db.Posts.Add(post);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
