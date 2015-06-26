using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
	public class ProfileController: Controller
	{
		[HttpPost]
		public JsonResult GetProfileForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			
			var user = dbContext.AspNetUsers
				.Where(netUser => netUser.Id == id)
				.Select(netuser => new 
				{
					netuser.Id, 
					netuser.Email,
					netuser.FirstName,
					netuser.LastName
					//netuser.RecipeGroups,
					//netuser.Recipes

				}).First();
			var userjson = Json(user);
			return userjson;

		}

		public ActionResult Index()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var profileInfo = dbContext.AspNetUsers
				.Where(netUser => netUser.Id == id)
				.Select(netuser => new ProfileViewModel
				{
					Groups = netuser.RecipeGroups,
					Recipes = netuser.Recipes,

				}).First();
			return View(profileInfo);
		}

		[HttpPost]
		public ActionResult GetRecipesForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var recipes = dbContext.Recipes.Where(x => x.AspNetUserId == id)
				.Select(recipe => new
				{
					recipe.Name,
					recipe.PrepTimeMinutes,
					recipe.CookTimeMinutes,
					recipe.Id,
					recipe.Serves

				}).ToArray();

			return Json(recipes);
		}

		[HttpPost]
		public JsonResult GetGroupsForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var groups = dbContext.RecipeGroups.Where(x=> x.AdminId == id || x.Members.Contains(dbContext.AspNetUsers.FirstOrDefault(y => y.Id == id)))
				.Select(group => new
				{
					group.Name

				}).ToList();
			return Json(groups);
		}
	}
}