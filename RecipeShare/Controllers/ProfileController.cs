using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
	public class ProfileController: Controller
	{
		[HttpPost]
		public ActionResult GetProfileForUser()
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
					netuser.LastName,
					netuser.RecipeGroups,
					netuser.Recipes

				});
			var userjson = Json(user);
			return userjson;

		}

	}
}