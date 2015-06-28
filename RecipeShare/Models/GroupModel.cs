using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class GroupModel
	{
		public class RecipeGroup
		{
			
			public int Id { get; set; }
			
			public string Name { get; set; }

			//Id if admin user
			public int AdminId { get; set; }

			//Id of member List
			public ICollection<AspNetUser> AspNetUsers { get; set; }

			public ICollection<RecipeModel.Recipe> Recipes { get; set; }

		}

	}
}