using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RecipeShare.Models;
using System.Data.Entity;


namespace RecipeShare.Controllers
{
	public class RecipeController : Controller
	{
		// GET: Recipe
		public ActionResult AddRecipe()
		{
			return View("AddRecipe");
		}

		public ActionResult EditRecipe(int id)
		{
			
			return View("AddRecipe", id);
		}

		public ActionResult ViewRecipe(int id)
		{
			return View("ViewRecipe",id);
		}

		public JsonResult GetRecipeCategories()
		{
			var dbContext = new RecipeShareDbContext();
			var recipeGroups = dbContext.RecipeCategories.Select(x => new
			{
				id = x.Id,
				recipeCategory = x.Category,
			}).ToList();
			return Json(recipeGroups, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult SaveRecipe(RecipeViewModel data)
		{
	
			var dbContext = new RecipeShareDbContext();

		

			if (data.Id != 0)
			{
				var recipeToUpdate = dbContext.Recipes.First(x => x.Id == data.Id);
				recipeToUpdate.Name = data.Name;
				recipeToUpdate.AspNetUserId = Convert.ToInt32(User.Identity.GetUserId());
				recipeToUpdate.CookTimeMinutes = data.CookTime;
				recipeToUpdate.PrepTimeMinutes = data.PrepTime;
				recipeToUpdate.Serves = data.Serves;
				dbContext.Ingredients.RemoveRange(dbContext.Ingredients.Where(c => c.RecipeId == data.Id));
				dbContext.Instructions.RemoveRange(dbContext.Instructions.Where(c => c.RecipeId == data.Id));

				var groupsToUpdate = dbContext.RecipeGroups.Where(x => x.Recipes.Any(a => a.Id == data.Id)).Include(x => x.Recipes).ToList();

				foreach(var group in groupsToUpdate)
				{
					group.Recipes.Remove(recipeToUpdate);
				}

				foreach(var group in data.Groups)
				{
					if(group.Recipes == null)
					{
						group.Recipes = new List<RecipeModel.Recipe>();
					}


					group.Recipes.Add(recipeToUpdate);
				}

				foreach (var ingredient in data.Ingredients)
				{
					recipeToUpdate.Ingredients.Add(new RecipeModel.Ingredient()
					{
						Amount = ingredient.Amount,
						Food = ingredient.Food,
					});
				}
				for (int i = 1; i <= data.Instructions.Count; i++)
				{

					recipeToUpdate.Instructions.Add(new RecipeModel.Instruction()
					{
						InstructionNumber = i,
						Narrative = data.Instructions[i - 1].Narrative, //Dear lord.... help me

					});
				}

			}
			else
			{
				var recipe = new RecipeModel.Recipe
				{
					Name = data.Name,
					AspNetUserId = Convert.ToInt32(User.Identity.GetUserId()),
					CookTimeMinutes = data.CookTime,
					PrepTimeMinutes = data.PrepTime,
					Serves = data.Serves,
					Ingredients = new List<RecipeModel.Ingredient>(),
					RecipeGroups = new List<GroupModel.RecipeGroup>()
				};

				foreach(var ingredient in data.Ingredients)
				{
					recipe.Ingredients.Add(new RecipeModel.Ingredient()
					{
						Amount = ingredient.Amount,
						Food = ingredient.Food,
					});
				}

				recipe.Instructions = new List<RecipeModel.Instruction>();
				for(int i = 1;i <= data.Instructions.Count;i++)
				{

					recipe.Instructions.Add(new RecipeModel.Instruction()
					{
						InstructionNumber = i,
						Narrative = data.Instructions[i - 1].Narrative, //Dear lord.... help me

					});
				}

				foreach (var group in data.Groups)
				{
					recipe.RecipeGroups.Add(group);
				}

				dbContext.Recipes.AddOrUpdate(recipe);

			}
			
			dbContext.SaveChanges();
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		public ActionResult GetRecipe(int id)
		{
			var dbContext = new RecipeShareDbContext();
			var recipe = dbContext.Recipes.Where(x => x.Id == id)
				.Select(x => new
				{
					Id = x.Id,
					//AspNetUserId = x.AspNetUserId,
					CookTime = x.CookTimeMinutes,
					//CreatedByUser = x.CreatedByUser,
					Ingredients = x.Ingredients.ToList(),
					Instructions = x.Instructions.ToList(),
					Name = x.Name,
					PrepTime = x.PrepTimeMinutes,
					//RecipeCategory = x.RecipeCategory,
					//RecipeGroups = x.RecipeGroups,
					Serves = x.Serves
				}).First();

			return Json(recipe);
		}
	}
}