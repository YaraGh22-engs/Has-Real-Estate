using AutoMapper;
using Has_Real_Estate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Has_Real_Estate.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateRepo _estateRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public EstateController(IEstateRepo estateRepo, IMapper mapper, ApplicationDbContext context,IUserService userService)
        {
            _estateRepo = estateRepo;
            _mapper = mapper;
            _context = context;
            _userService= userService;

        }
        public static List<SelectListItem> GetEnumSelectList<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            var selectList = enumValues.Select((e, i) => new SelectListItem
            {
                Value = i.ToString(),
                Text = e.ToString()
            }).ToList();

            return selectList;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_estateRepo.GetEstatesByUserId());
        }
        public IActionResult Explore(string? forSale, string? forRent, string? searchName, [FromQuery] Category? categoryName,
                                             [FromQuery] Governorate? governorate, int? minPrice, int? maxPrice)
        {
            var estates = _estateRepo.GetEstates();
            if (!string.IsNullOrEmpty(searchName))
            {
                estates = _estateRepo.SearchByName(searchName);
            }
            if (categoryName.HasValue)
            {
                estates = estates.Where(p => p.Category == categoryName.Value).ToList();
            }
            if (governorate.HasValue)
            {
                estates = estates.Where(p => p.Governorate == governorate.Value).ToList();
            }
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                estates = estates.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            }
            if (forSale == "forSale")
            {
                estates = estates.Where(p => p.ForSale == true).ToList();
            }
            if (forRent == "forRent")
            {
                estates = estates.Where(p => p.ForRent == true).ToList();
            }
            ViewBag.selectCategories = GetEnumSelectList<Category>();
            ViewBag.selectGovernorate = GetEnumSelectList<Governorate>();
            //now we will get the user's inputs to display them in their boxes
            ViewBag.category = categoryName;
            ViewBag.governorate = governorate;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.searchName = searchName;
            ViewBag.forSale = forSale;
            ViewBag.forRent = forRent;
            return View(estates);
        }
        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateEstateVM()
            {
                SelectCategory = GetEnumSelectList<Category>(),
                SelectMethodPay = GetEnumSelectList<MethodPay>(),
                SelectLegalType = GetEnumSelectList<LegalType>(),
                SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>(),
                SelectGovernorate = GetEnumSelectList<Governorate>(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateEstateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectCategory = GetEnumSelectList<Category>();
                viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
                viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
                viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
                viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();


                return View(viewModel);
            }
            var isAdded = _estateRepo.Create(viewModel);
            if (isAdded > 0)
                return RedirectToAction("Index");
            return BadRequest();
        }
        public IActionResult Update(int estateId)
        {
            var estate = _estateRepo.GetById(estateId);
            if (estate == null)
            {
                return BadRequest();
            }
            var viewModel = _mapper.Map<UpdateEstateVM>(estate);
            viewModel.SelectCategory = GetEnumSelectList<Category>();
            viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
            viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
            viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
            viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateEstateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SelectCategory = GetEnumSelectList<Category>();
                viewModel.SelectMethodPay = GetEnumSelectList<MethodPay>();
                viewModel.SelectLegalType = GetEnumSelectList<LegalType>();
                viewModel.SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>();
                viewModel.SelectGovernorate = GetEnumSelectList<Governorate>();
                return View(viewModel);
            }
            var isUpdated = _estateRepo.Update(viewModel);
            if (isUpdated > 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public IActionResult UpdateEstateImages(int estateId)
        {
            var estate = _estateRepo.GetById(estateId);
            if (estate != null)
            {
                var viewModel = new UpdateEstateImagesVM()
                {
                    Id = estate.Id,
                    Images = estate.EstateImages?.Select(image => image.Path).ToList(),
                };
                return View(viewModel);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateEstateImages(UpdateEstateImagesVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var isUpdated = _estateRepo.UpdateEstateImages(viewModel);
            if (isUpdated >= 0)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult DeleteEstateImage(int estateId, string image)
        {
            var isDeleted = _estateRepo.DeleteEstateImage(estateId, image);
            if (isDeleted > 0)
            {
                return RedirectToAction("UpdateEstateImages", "Estate", new { estateId = estateId });
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _estateRepo.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
        
        public async Task<IActionResult> Detail(int estateId) 
        {
            var userId = _userService.GetUserId();
            var es =await _context.Estates.Include(h => h.EstateImages) 
                                           .Where(h => h.Id == estateId)
                                           .SingleOrDefaultAsync();

            ViewBag.savePropertyStatus = _estateRepo.CheckSaveStatus(estateId, userId);
            return View(es);
        }
        [Authorize]
        public async Task<IActionResult> Save(int estateId)
        {
            var userId = _userService.GetUserId();
            var isSaved = await _context.SavedProperties
                                         .Where(x => x.UserId == userId && x.EstateId == estateId)
                                         .SingleOrDefaultAsync();
            if (isSaved == null)
            {
                ViewBag.savePropertyStatus = true;
                SavedProperty SP = new SavedProperty
                {
                    UserId = userId,
                    EstateId = estateId, 
                };
                await _context.SavedProperties.AddAsync(SP);
                await _context.SaveChangesAsync();
               
                TempData["successMessage"] = "Saved";
            }
            else
            {
                _context.SavedProperties.Remove(isSaved);
                _context.SaveChanges();
               
                TempData["successMessage"] = "Removed";
            }
            return RedirectToAction("Detail", "Estate", new { estateId = estateId });
        }

        public IActionResult GetSavedProperty()
        {
            var es = _estateRepo.GetSavedProperty();
            
            return View(es); 
        }
    
    }
}
