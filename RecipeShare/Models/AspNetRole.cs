namespace RecipeShare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }

    }

	//used like an enum to get strings to compare to roles. see http://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp
	//super genius
	public class RoleType
	{
		private RoleType(string value) { Value = value; }
		public string Value { get; set; }

		public static RoleType SuperAdmin {get{ return new RoleType("SuperAdmin");}}
	}
}
