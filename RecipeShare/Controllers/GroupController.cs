using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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

			return new HttpStatusCodeResult(HttpStatusCode.OK);
	    }
    }
}