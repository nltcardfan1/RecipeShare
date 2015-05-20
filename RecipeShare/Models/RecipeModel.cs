using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class RecipeModel
	{
		public class RecipeCategory
		{
			public int Id { get; set; }

			public string Category { get; set; }
		}

		public class Instruction
		{
			public int Id { get; set; }

			public int RecipeId { get; set; }

			public int InstructionNumber { get; set; }

			public string Narrative { get; set; }


			public virtual Recipe Recipe { get; set; }


		}

		public class Ingredient
		{
			public int Id { get; set; }

			public int RecipeId { get; set; }

			public string Food { get; set; }

			public string Amount { get; set; }

		}

		public class Recipe
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public RecipeCategory RecipeCategory { get; set; }

			public string Serves { get; set; }

			public int? PrepTimeMinutes { get; set; }

			public int? CookTimeMinutes { get; set; }

			public int AspNetUserId { get; set; }

			public virtual ICollection<Instruction> Instructions  { get; set; }

			public virtual ICollection<GroupModel.RecipeGroup> RecipeGroups  { get; set; }

			public virtual AspNetUser CreatedByUser { get; set; }

			public virtual ICollection<Ingredient> Ingredients { get; set; }  
			
		}
	}

	class RecipeModelImpl : RecipeModel
	{
	}
}