using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult AddEditGroups()
        {
            return View();
        }

	    public ActionResult EditGroups(int id)
	    {
		    return View("AddEditGroups", id);
	    }

		[HttpPost]
	    public ActionResult SaveGroup(GroupViewModel data)
		{
			int userId = Convert.ToInt32(User.Identity.GetUserId());
			var dbcontext = new RecipeShareDbContext();
			if (data.Id != 0)
			{
				var groupToUpdate = dbcontext.RecipeGroups.Include(x=> x.AspNetUsers).First(x => x.Id == data.Id);
				groupToUpdate.Name = data.Name;

				//JUST KILL ME NOW
				var users = groupToUpdate.AspNetUsers.Select(x => x).ToList();
				foreach (var user in users)
				{
					groupToUpdate.AspNetUsers.Remove(user);
				}

				dbcontext.SaveChanges();
				foreach(var email in data.UserEmails)
				{
					if (dbcontext.AspNetUsers.Any(x => x.Email == email))
					{
						groupToUpdate.AspNetUsers.Add(dbcontext.AspNetUsers.First(x => x.Email == email));
					}
				}
			}
			else
			{
				var group = new GroupModel.RecipeGroup
				{
					Name = data.Name,
					AdminId = userId
				};

				group.AspNetUsers = new List<AspNetUser>();

				var emailHash = new HashSet<string>(data.UserEmails);
				var users = dbcontext.AspNetUsers.Where(x => emailHash.Contains(x.Email)).ToList();
				//
				users.Add(dbcontext.AspNetUsers.First(x => x.Id == userId));
				users.ForEach(x => group.AspNetUsers.Add(x));

				dbcontext.RecipeGroups.Add(group);
			}

			try
			{

				dbcontext.SaveChanges();
			}
			catch(DbEntityValidationException e)
			{
				foreach(var eve in e.EntityValidationErrors)
				{
					Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name,eve.Entry.State);
					foreach(var ve in eve.ValidationErrors)
					{
						Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName,ve.ErrorMessage);
					}
				}
				throw;
			}
			return new HttpStatusCodeResult(HttpStatusCode.OK);

	    }

	    [HttpPost]
	    public ActionResult GetGroupInfo(int id)
		{
			int userId = Convert.ToInt32(User.Identity.GetUserId());
			var dbcontext = new RecipeShareDbContext();
		//	var ret = from g in dbcontext.RecipeGroups
		//			  join userLU in dbcontext.
		//			  on user.Id in g.AdminId
		//			  where g.AdminId
			var ret = dbcontext.RecipeGroups.Where(x => x.Id == id)
				.Select(x => new 
				{
					x.Id,
					Name = x.Name,
					UserEmails = x.AspNetUsers.Select(z => z.Email)
				}).First();

			

		    return Json(ret);
	    }

		[HttpPost]
		public JsonResult GetGroupsForUser()
		{
			var dbContext = new RecipeShareDbContext();
			int id = Convert.ToInt32(User.Identity.GetUserId());
			var groups = dbContext.RecipeGroups.Where(x => x.AdminId == id || x.AspNetUsers.Contains(dbContext.AspNetUsers.FirstOrDefault(y => y.Id == id)))
				.Select(group => new
				{
					group.Id,
					group.Name

				}).ToList();
			return Json(groups);
		}

		[HttpPost]
		public JsonResult GetGroupsForRecipeAndUser(int recipeId)
		{
			var dbContext = new RecipeShareDbContext();
			int userId = Convert.ToInt32(User.Identity.GetUserId());
			var recipes = dbContext.RecipeGroups.Include(x => x.Recipes).Where(x => x.Id == recipeId);
			var groups = dbContext.RecipeGroups.Where(x => x.AdminId == userId || x.AspNetUsers.Contains(dbContext.AspNetUsers.FirstOrDefault(y => y.Id == userId)))
				.Select(group => new
				{
					group.Id,
					group.Name,
					assocWithRecipe = recipes.Contains(group)
					

				}).ToList();
			return Json(groups);
		}
    }
}