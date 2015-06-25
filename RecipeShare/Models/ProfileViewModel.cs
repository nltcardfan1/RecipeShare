using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class ProfileViewModel
	{
		public ICollection<GroupModel.RecipeGroup> Groups { get; set; }
		public ICollection<RecipeModel.Recipe> Recipes { get; set; }
	}
}