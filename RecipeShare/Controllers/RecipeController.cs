using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult AddRecipe()
        {
            return View();
        }

	    public JsonResult GetFoods()
	    {
		    var dbContext = new RecipeShareDbContext();
		    var stuffs = dbContext.Foods.Select(x => new
		    {
			    id = x.Id,
			    foodGroup = x.FoodGroupId,
			    name = x.Name
		    }).ToList();
		    return Json(stuffs);
	    }
    }
}