using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class GroupViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<String> UserEmails { get; set; }

		public ICollection<RecipeModel.Recipe> Recipes { get; set; }
	}
}