﻿using AutoMapper;
using Has_Real_Estate.Models;
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

        public EstateController(IEstateRepo estateRepo, IMapper mapper, ApplicationDbContext context)
        {
            _estateRepo = estateRepo;
            _mapper = mapper;
            _context = context;
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
        public IActionResult Index()
        {
            return View(_estateRepo.GetEstatesByUserId());
        }
        public IActionResult Create()
        {
            var viewModel = new CreateEstateVM()
            {
                SelectCategory = GetEnumSelectList<Category>(),
                SelectMethodPay = GetEnumSelectList<MethodPay>(),
                SelectLegalType = GetEnumSelectList<LegalType>(),
                SelectCompleteBuildingState = GetEnumSelectList<CompleteBuildingState>(),
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
        public IActionResult Explore()
        {
            var es = _estateRepo.GetEstates();
            return View(es);

        }
        public async Task<IActionResult> Detail(int estateId) 
        {
            var es =await _context.Estates.Include(h => h.EstateImages)
                                           .Where(h => h.Id == estateId)
                                           .SingleOrDefaultAsync();
            //var es =await _estateRepo.GetById(estateId);
            return View(es);
        }
    }
}
