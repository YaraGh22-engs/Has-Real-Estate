using Has_Real_Estate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Has_Real_Estate.Controllers
{
    [Authorize ]
    public class UserController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IUserService _userService;
        private readonly IEstateRepo _estateRepo;
        private readonly ApplicationDbContext _context;


        public UserController(IUserService userService, ICommentRepo commentRepo, IEstateRepo estateRepo, ApplicationDbContext context)
        {

            _userService = userService;
            _commentRepo = commentRepo;
            _estateRepo = estateRepo;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult AddComment(int EstateId)
        //{
        //    var com = _context.Comments.Include(x => x.Estate).Where(x=>x.EstateId== EstateId).SingleOrDefault();
            
        //    return RedirectToAction("Detail", "Estate", new { estateId = com.EstateId });

        //} 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment([Bind("Id,Content,UserId,EstateId")] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            _commentRepo.Add(comment);
            return RedirectToAction("Detail", "Estate", new { estateId = comment.EstateId });
        }

        public IActionResult RemoveComment(int id )
        {
            var com = _commentRepo.GetById(id);
            if (com == null)
            {
                return BadRequest();
            }
            var estateId = com.EstateId;
            var isDelete = _commentRepo.RemoveComment(id);
            if (isDelete > 0)
            {
                //return Ok();
                return RedirectToAction("Detail", "Estate", new { estateId = estateId });

            }
            return BadRequest();
            // return RedirectToAction("Detail", "Estate", new { estateId = commentId });
        }
    }
}
