using Microsoft.AspNetCore.Mvc;
using StoreProceDureCrud.Areas.ProfileArea.Models;
using StoreProceDureCrud.Data.Entity;
using StoreProceDureCrud.Helper;
using StoreProceDureCrud.Service.ProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreProceDureCrud.Areas.ProfileArea.Controllers
{
    [Area("ProfileArea")]
    public class ProfileController : Controller
    {
        ProfileService _profileService = new ProfileService();

        //GET:/ProfileArea/Profile/Index
        public IActionResult Index()
        {
            List<ProfileViewModel> lstProfile = new List<ProfileViewModel>();
            ProfileDataViewModel data = new ProfileDataViewModel
            {
                profileViewModels = _profileService.GetProfilesList().ToList(),
                countries=_profileService.GetAllCountries(),
                genders = _profileService.GetAllGender(),
                hobbies = _profileService.GetAllHobby()
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult Index([FromForm]ProfileViewModel model)
        {
            string ImageUrl = "DefaultImage/NoFile.png";
            string fileName;
            string message = FileSave.SaveAttachment(out fileName, model.ImageUrl);
            if (message == "success")
            {
                ImageUrl = "";
                ImageUrl = fileName;
            }
            else
            {
                return View(model);
            }

            Profile data = new Profile
            {
                ProfileId = model.ProfileId,
                Name = model.Name,
                email = model.email,
                contact = model.contact,
                websiteLink = model.websiteLink,
                Password = model.Password,
                GenderId = model.GenderId,
                CityId = model.CityId,
                ProfileImage = ImageUrl,
                dateOfBirth = model.dateOfBirth,
                Remarks = model.Remarks
            };
            if (model.ProfileId>0)
            {
                _profileService.UpdateProfile(data);
            }
            else
            {
                _profileService.AddProfile(data);
            }
           
            return View();
        }



        public IActionResult LoadCityByCountry(int? id)
        {
            return Json(_profileService.GetAllCityByCountry(id));
        }

        public IActionResult LoadHobbyByProfile(int? id)
        {
            return Json(_profileService.GetAllHobbyByProfileId(id));
        }
    }
}
