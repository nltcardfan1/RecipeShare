using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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
		//public JsonResult GetFoods(string search)
		//{
		//	var dbContext = new RecipeShareDbContext();
		//	var stuffs = dbContext.Foods.Where(x => x.Name.Contains(search))
		//	.Select(x => new
		//	{
		//		id = x.Id,
		//		foodGroup = x.FoodGroupId,
		//		name = x.Name
		//	}).ToList();
		//	return Json(stuffs, JsonRequestBehavior.AllowGet);
		//}

		//public JsonResult GetFoodGroups()
		//{
		//	var dbContext = new RecipeShareDbContext();
		//	var foodGroups = dbContext.FoodGroups.Select(x => new
		//	{
		//		id = x.Id,
		//		foodGroup = x.Name,
		//	}).ToList();
		//	return Json(foodGroups,JsonRequestBehavior.AllowGet);
		//}

		public JsonResult GetRecipeCategories()
		{
			var dbContext = new RecipeShareDbContext();
			var recipeGroups = dbContext.RecipeCategories.Select(x => new
			{
				id = x.Id,
				recipeCategory = x.Category,
			}).ToList();
			return Json(recipeGroups,JsonRequestBehavior.AllowGet);
		}

	    [HttpPost]
	    public ActionResult SaveRecipe(RecipeViewModel data)
	    {
		    
			return new HttpStatusCodeResult(HttpStatusCode.OK);
	    }
    }
}