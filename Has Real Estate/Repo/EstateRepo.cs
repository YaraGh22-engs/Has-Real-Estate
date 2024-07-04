﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace Has_Real_Estate.Repo
{
    public class EstateRepo : IEstateRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper; 
        public EstateRepo(ApplicationDbContext context, IUserService userService, IImageService imageService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _imageService = imageService;
            _mapper = mapper; 
        } 
        public IEnumerable<Estate> GetEstates()
        {
            return _context.Estates.ToList();
        }
        public IEnumerable<EstateImages> GetAllImages(int estateId)
        {
            var estate = GetById(estateId);
            if (estate != null)
            {
                return estate.EstateImages?.ToList();
            }
            return null;
        }
        public int Create(CreateEstateVM viewModel)
        {
            var userId = _userService.GetUserId();
            var estate = _mapper.Map<Estate>(viewModel);
            estate.UserId = _userService.GetUserId();
            estate.Cover = _imageService.SaveImageInDatabase(viewModel.FormCover);
            estate.EstateImages = StoreImagesNames(viewModel.FormFiles);
            _context.Estates.Add(estate);
            return _context.SaveChanges();
        }

        public Estate GetById(int estateId)
        {
            var home = _context.Estates?.Include(h => h.EstateImages)
                .Where(h => h.Id == estateId).AsNoTracking().SingleOrDefault();
            if (home == null)
            {
                return null;
            }
            return home;
        }

        public int Update(UpdateEstateVM viewModel)
        {
            var home = GetById(viewModel.Id);
            byte[] oldCover = home.Cover;
            if (home == null)
            {
                return 0;
            }
            home = _mapper.Map<Estate>(viewModel);
            home.UserId = _userService.GetUserId();
            if (viewModel.FormCover != null)
            {
                home.Cover = _imageService.SaveImageInDatabase(viewModel.FormCover);
            }
            else
            {
                home.Cover = oldCover;
            }
            _context.Estates.Update(home);
            return _context.SaveChanges();
        }

        public int UpdateEstateImages(UpdateEstateImagesVM viewModel)
        {
            var existingHome = GetById(viewModel.Id);

            if (existingHome == null)
            {
                return -1;
            }

            if (viewModel.FormFiles != null)
            {
                existingHome.EstateImages = StoreImagesNames(viewModel.FormFiles);
                _context.Estates.Update(existingHome);
                return _context.SaveChanges();
            }
            return 0;
        }
        public int DeleteEstateImage(int estateId, string image)
        {
            var home = GetById(estateId);
            if (home != null)
            {
                var img = home.EstateImages?.Where(hi => hi.Path == image).SingleOrDefault();
                if (img == null)
                {
                    return -1;
                }
                var path = _imageService.GetImagePath(image);
                File.Delete(path);
                _context.EstateImages.Remove(img);
                return _context.SaveChanges();
            }
            else
                return -1;
        }
        public bool Delete(int id)
        {

            var isDeleted = false;

            var est = _context.Estates.Include(x => x.EstateImages).FirstOrDefault(x => x.Id==id);
               
            if (est is null)
                return isDeleted;

            _context.Remove(est);
            isDeleted = true;
            var effectedRows = _context.SaveChanges();
            
            //if (effectedRows > 0)
            //{
            //    isDeleted = true;
            //    foreach (var img in est.EstateImages)
            //    {
            //        var cover = Path.Combine(Settings.imagesPath, img.Path);
            //        File.Delete(cover);
            //    }

            //}

            return isDeleted;
        }
        public List<EstateImages> StoreImagesNames(List<IFormFile> formFiles)
        {
            if (formFiles != null)
            {
                List<EstateImages> estateImages = new List<EstateImages>();
                foreach (var item in formFiles)
                {
                    var image = new EstateImages { Path = _imageService.SaveImgInServer(item) };
                    estateImages.Add(image);
                }
                return estateImages;
            }
            return null;
        }


    }
}
