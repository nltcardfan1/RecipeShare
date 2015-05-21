using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeShare.Models
{
	public class GroupViewModel
	{
			public string Name { get; set; }

			public List<String> UserEmails { get; set; }

			public ICollection<RecipeModel.Recipe> Recipes { get; set; }
	}
}