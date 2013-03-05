using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace StaffWorkLoad.Helpers {

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class ColorPickerAttribute : Attribute, IMetadataAware{    
		
		private const string Template =        
			"$('#{0}').ColorPicker({{onSubmit: function(hsb, hex, rgb, el) {{" +         
			"var self = $(el); self.val(hex);self.ColorPickerHide();}}, onBeforeShow: function () " +         
			"{{$(this).ColorPickerSetColor(this.value);}}}}).bind('keyup', function(){{ $(this).ColorPickerSetColor(this.value); }});";             
		
		public const string ColorPicker = "_ColorPicker";     
		
		private int _count;    
		private HttpContextBase _context;     
		// I personally don't like to do this -     
		// is there some other way to get the current HttpContext in the attribute?    
		internal HttpContextBase Context    {        
			get { 
				return _context ?? (_context = new HttpContextWrapper(HttpContext.Current)); 
			}        
			set { _context = value; } // so we can unit test this attribute    
		}     
		
		public string Id    {        
			get { 
				return "jquery-colorpicker-" + _count;  
			}    
		}     
		
		public void OnMetadataCreated(ModelMetadata metadata)    
		{        
			var list = Context.Items["Scripts"] as IList<string> ?? new List<string>();        
			_count = list.Count;         
			metadata.TemplateHint = ColorPicker;        
			metadata.AdditionalValues[ColorPicker] = Id;         
			list.Add(string.Format(CultureInfo.InvariantCulture, Template, Id));         
			Context.Items["Scripts"] = list;    
		}
	}
}