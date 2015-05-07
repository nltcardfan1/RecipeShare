using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class FoodModel
	{
		public class Food
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public int FoodGroupId { get; set; }

			public virtual FoodGroup FoodGroup { get; set; }
		}

		public class FoodGroup
		{
			public int Id { get; set; }

			public int Name { get; set; }

			public virtual ICollection<Food> Foods  { get; set; }
		}
	}
}