using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Xin.Data;
using Xin.Models;

namespace Xin.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;



        //========================
        private readonly UserManager<ApplicationUser> _userManager;

        //public MainController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public MainController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //========================

        public async Task<IActionResult> Index()
        {
            
            var user  = await GetCurrentUserAsync(); 
            var profile = (from x in _context.Profile where x.UserId == user.Id select x).FirstOrDefault();
            var des = (from x in _context.Description where x.UserId == user.Id select x).ToList();
            //mutiplute items put into des need to have tolist 
            List<FullDes>  AllfullDes= null;
            if (des!= null)
            {
                AllfullDes = new List<FullDes>();
                foreach(Description Item in des)
                {
                    FullDes fullDes = new FullDes();
                    fullDes.Descriptions = Item;
                    fullDes.DesDetails = (from x in _context.DesDetails where x.DescriptionId == Item.Id select x).ToList();
                    AllfullDes.Add(fullDes);

                }
            }
            var eductions = (from x in _context.Eduction where x.UserId == user.Id select x).ToList();
            var projects = (from x in _context.Project where x.UserId == user.Id select x).ToList();
            var skills = (from x in _context.Skill where x.UserId == user.Id select x).ToList();
            var WKE = (from x in _context.WorkExperience where x.UserId == user.Id select x).ToList();
            List<FullWE> AllFullWE = null;
            if (WKE != null)
            {
                AllFullWE = new List<FullWE>();
                foreach (WorkExperience Item in WKE)
                {
                    FullWE fullWE = new FullWE();
                    fullWE.WorkExperience = Item;
                    fullWE.WorkExperienceDetail = (from x in _context.WorkExperienceDetail where x.WorkExperienceId == Item.Id select x).ToList();
                    AllFullWE.Add(fullWE);

                }
            }



            Everything everything = new Everything();
            everything.ApplicationUser = user;
            everything.Profiles = profile;
            //everything.Descriptions = des;
            //everything.DesDetails = desDtList;
            everything.FullDes = AllfullDes;
            everything.Eductions = eductions;
            everything.Projects = projects;
            everything.Skills = skills;
            everything.FullWE = AllFullWE;
            return View(everything);
        }
    }
}