using Microsoft.AspNetCore.Mvc;

namespace Has_Real_Estate.Controllers
{
    public class UserController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IUserService _userService;
        private readonly IEstateRepo _estateRepo;


        public UserController(IUserService userService, ICommentRepo commentRepo, IEstateRepo estateRepo)
        {

            _userService = userService;
            _commentRepo = commentRepo;
            _estateRepo = estateRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
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
