using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StaffWorkLoad.Helpers {
	
	public sealed class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable {

		private const string _defaultErrorMessage = "'{0}' must be greater than '{1}'";
		private string _basePropertyName;

		public DateGreaterThanAttribute(string basePropertyName) : base(_defaultErrorMessage) {

			_basePropertyName = basePropertyName;
		}

		//Override default FormatErrorMessage Method  
		public override string FormatErrorMessage(string name) {
			return string.Format(_defaultErrorMessage, name, _basePropertyName);
		}

		//Override IsValid  
		protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
			//Get PropertyInfo Object  
			var basePropertyInfo = validationContext.ObjectType.GetProperty(_basePropertyName);

			//Get Value of the property  
			var refDate = (DateTime)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);

			var thisDate = (DateTime)value;

			//Actual comparision  
			if (thisDate < refDate) {
				//var message = FormatErrorMessage(validationContext.DisplayName);
				var message = this.ErrorMessage;
				return new ValidationResult(message);
			}

			//Default return - This means there were no validation error  
			return null;
		}


		#region IClientValidatable Members

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			List<ModelClientValidationRule> mcvrs = new List<ModelClientValidationRule>();
			ModelClientValidationRule rule = new ModelClientValidationRule();

			rule.ValidationType = "dategreaterthan";	// client-side function name
			rule.ValidationParameters.Add("refdate", _basePropertyName);
			rule.ErrorMessage = this.ErrorMessage; // FormatErrorMessage(metadata.DisplayName);

			mcvrs.Add(rule);
			return mcvrs;
		}

		#endregion
	}

}