using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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
				var groupToUpdate = dbcontext.RecipeGroups.First(x => x.Id == data.Id);
				groupToUpdate.Name = data.Name;
				//groupToUpdate.AspNetUsers.Remove();
				dbcontext.SaveChanges();
				groupToUpdate.AspNetUsers = new List<AspNetUser>();
				foreach(var email in data.UserEmails)
				{
					if (dbcontext.AspNetUsers.Any(x => x.Email == email))
					{
						groupToUpdate.AspNetUsers.Add(new AspNetUser()
						{
							Id = dbcontext.AspNetUsers.First(x => x.Email == email).Id
						});
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
		
				
			dbcontext.SaveChanges();
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
    }
}