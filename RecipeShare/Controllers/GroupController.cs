using System;
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

		[HttpPost]
	    public ActionResult SaveGroup(GroupViewModel data)
		{
			int userId = Convert.ToInt32(User.Identity.GetUserId());
			var dbcontext = new RecipeShareDbContext();
			var group = new GroupModel.RecipeGroup
			{
				Name = data.Name,
				AdminId = userId
			};

			group.Members = new List<AspNetUser>();

			var emailHash = new HashSet<string>(data.UserEmails);
			var users = dbcontext.AspNetUsers.Where(x => emailHash.Contains(x.Email)).ToList();
			//
			users.Add(dbcontext.AspNetUsers.First(x => x.Id == userId));
			users.ForEach(x => group.Members.Add(x));

			dbcontext.RecipeGroups.Add(group);
			dbcontext.SaveChanges();
			return new HttpStatusCodeResult(HttpStatusCode.OK);

	    }
    }
}