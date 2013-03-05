using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.ComponentModel;

namespace StaffWorkLoad.Helpers
{
	/// <summary>
	/// Model binder to ensure Date formats are in GB format: dd/MM/yyyy
	/// </summary>
	public class EnGBModelBinder : IModelBinder     
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) 
		{ 
			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
			ModelState modelState = new ModelState { Value = valueResult };

			object actualValue = null;
			try
			{
				actualValue = DateTime.Parse(valueResult.AttemptedValue, CultureInfo.GetCultureInfo("en-GB"));  
			}
			catch (FormatException e)
			{
				modelState.Errors.Add(e);
			}

			bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
			return actualValue;
		}
	}
}