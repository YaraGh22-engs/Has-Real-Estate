using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Has_Real_Estate.Controllers
{
    public class EstatesController : Controller
    {
        private readonly IHomeRepo _homeRepo;
        private readonly IMapper _mapper;

        public EstatesController(IHomeRepo homeRepo, IMapper mapper)
        {
            _homeRepo = homeRepo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(_homeRepo.GetHomes());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateHomeVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isAdded = _homeRepo.Create(viewModel);
            if (isAdded > 0)
                return RedirectToAction("Index");
            return BadRequest();
        }
        public IActionResult Update(int homeId)
        {
            var home = _homeRepo.GetById(homeId);
            if (home == null)
            {
                return BadRequest();
            }
            var viewModel = _mapper.Map<UpdateHomeVM>(home);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(UpdateHomeVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _homeRepo.Update(viewModel);
            if (isUpdated > 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        public IActionResult UpdateHomeImages(int homeId)
        {
            var home = _homeRepo.GetById(homeId);
            if (home != null)
            {
                var viewModel = new UpdateHomeImagesVM()
                {
                    Id = home.Id,
                    Images = home.HomeImages?.Select(image => image.Path).ToList(),
                };
                return View(viewModel);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateHomeImages(UpdateHomeImagesVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _homeRepo.UpdateHomeImages(viewModel);
            if (isUpdated >= 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult DeleteHomeImage(int homeId, string image)
        {
            var isDeleted = _homeRepo.DeleteHomeImage(homeId, image);
            if (isDeleted > 0)
            {
                return RedirectToAction("UpdateHomeImages", "Home", new { homeId = homeId });
            }
            return BadRequest();
        }
    }
}
