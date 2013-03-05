using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using StaffWorkLoad.Helpers;

namespace StaffWorkLoad.Models {
	
	public class WorkLoad {

		public int ID { get; set; }

		[Display(Name = "Staff Name")]
		[Required(ErrorMessage = "Staff name is required")]
		public int PersonID { get; set; }

		[Display(Name = "Workload Start Date")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[Required(ErrorMessage = "Start Date is required")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Workload End Date")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[Required(ErrorMessage = "End Date is required")]
		[DateGreaterThanAttribute("StartDate", ErrorMessage = "End Date must be greater than Start Date")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Workload Type")]
		[Required(ErrorMessage = "Work type must be specified")]
		public string WorkType { get; set; }

		[Display(Name = "Workload Notes")]
		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }

		public virtual Person StaffName { get; set; }
	}

	public class Person {

		public int PersonID { get; set; }

		[Display(Name = "First Name")]
		[Required(ErrorMessage = "First Name is required")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[Required(ErrorMessage = "Last Name is required")]
		public string LastName { get; set; }

		//[ColorPicker]
		[Display(Name = "Legend Colour")]
		public string LineColour { get; set; }

		public string FullName {
			get {
				return FirstName + " " + LastName;
			}
		}
	} 

	public class WorkLoadDBContext : DbContext {

		public DbSet<WorkLoad> WorkLoads { get; set; }
		public DbSet<Person> Staff { get; set; }

	}
}