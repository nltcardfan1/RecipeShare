using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using RecipeShare.Models;

namespace RecipeShare.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult AddRecipe()
        {
			return View("AddRecipe");
        }

	    public ActionResult EditRecipe(RecipeViewModel rvm)
	    {
		    return RedirectToAction("AddRecipe", "Recipe");
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
		    var dbContext = new RecipeShareDbContext();
		    var recipe = new RecipeModel.Recipe
		    {
			    Name = data.Name,
			    AspNetUserId = Convert.ToInt32(User.Identity.GetUserId()),
			    CookTimeMinutes = data.CookTime,
			    PrepTimeMinutes = data.PrepTime,
			    Serves = data.Serves,
			    Ingredients = new List<RecipeModel.Ingredient>()
		    };

		    foreach (var ingredient in data.Ingredients)
		    {
			    recipe.Ingredients.Add(new RecipeModel.Ingredient()
			    {
				    Amount = ingredient.Amount,
					Food = ingredient.Food,
			    });
		    }

			recipe.Instructions = new List<RecipeModel.Instruction>();
			for(int i = 1; i <= data.Instructions.Count; i++ )
			//foreach(var instruction in RecipeModel.Instruction.Select((value,i) => new {i, value}))
			{

				recipe.Instructions.Add(new RecipeModel.Instruction()
				{
					InstructionNumber = i,
					Narrative = data.Instructions[i-1].Narrative, //Dear lord.... help me
					
				});
			}


			dbContext.Recipes.Add(recipe);
		    dbContext.SaveChanges();
			return new HttpStatusCodeResult(HttpStatusCode.OK);
	    }

		//[HttpPost]
		//public ActionResult UpdateRecipe(RecipeViewModel data)
		//{

		//}
    }
}