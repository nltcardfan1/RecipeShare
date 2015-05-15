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
	    public JsonResult GetFoods(string search)
	    {
		    var dbContext = new RecipeShareDbContext();
		    var stuffs = dbContext.Foods.Where(x => x.Name.Contains(search))
			.Select(x => new
		    {
			    id = x.Id,
			    foodGroup = x.FoodGroupId,
			    name = x.Name
		    }).ToList();
		    return Json(stuffs, JsonRequestBehavior.AllowGet);
	    }
    }
}