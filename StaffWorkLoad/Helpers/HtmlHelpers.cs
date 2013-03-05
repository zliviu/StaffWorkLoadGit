using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace StaffWorkLoad.Helpers {

	public static class HtmlHelpers {

		public static string Truncate(this HtmlHelper helper, string input, int length) {

			if (input == null)
				return null;

			if (input.Length <= length) {
				return input;
			} else {
				return input.Substring(0, length) + "...";
			}
		}

		public static MvcHtmlString ImageActionLink(            this HtmlHelper helper,            string imageUrl,            string altText,            string actionName,            string controllerName,            object routeValues,            object linkHtmlAttributes,            object imgHtmlAttributes)        {            
			
			var linkAttributes = AnonymousObjectToKeyValue(linkHtmlAttributes);            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);            var imgBuilder = new TagBuilder("img");            imgBuilder.MergeAttribute("src", imageUrl);            imgBuilder.MergeAttribute("alt", altText);            imgBuilder.MergeAttributes(imgAttributes, true);            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);            var linkBuilder = new TagBuilder("a");            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));            linkBuilder.MergeAttributes(linkAttributes, true);            var text = linkBuilder.ToString(TagRenderMode.StartTag);            text += imgBuilder.ToString(TagRenderMode.SelfClosing);            text += linkBuilder.ToString(TagRenderMode.EndTag);            return MvcHtmlString.Create(text);        
		}         
		
		public static MvcHtmlString ImageActionLink(            this HtmlHelper helper,            string imageUrl,            string altText,            string actionName,            object routeValues,            object imgHtmlAttributes)        {            
			
			var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);            var imgBuilder = new TagBuilder("img");            imgBuilder.MergeAttribute("src", imageUrl);            imgBuilder.MergeAttribute("alt", altText);            imgBuilder.MergeAttributes(imgAttributes, true);            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);            var linkBuilder = new TagBuilder("a");            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));            var text = linkBuilder.ToString(TagRenderMode.StartTag);            text += imgBuilder.ToString(TagRenderMode.SelfClosing);            text += linkBuilder.ToString(TagRenderMode.EndTag);            return MvcHtmlString.Create(text);        
		}         
		
		public static MvcHtmlString ImageActionLink(            this HtmlHelper helper,            string imageUrl,            string altText,            string actionName,            object routeValues)        {            
			
			var imgBuilder = new TagBuilder("img");            imgBuilder.MergeAttribute("src", imageUrl);            imgBuilder.MergeAttribute("alt", altText);            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);            var linkBuilder = new TagBuilder("a");            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));            var text = linkBuilder.ToString(TagRenderMode.StartTag);            text += imgBuilder.ToString(TagRenderMode.SelfClosing);            text += linkBuilder.ToString(TagRenderMode.EndTag);            return MvcHtmlString.Create(text);        
		}         
		
		public static MvcHtmlString ImageActionLink(            this HtmlHelper helper,            string imageUrl,            string altText,            string actionName)        {            
			
			var imgBuilder = new TagBuilder("img");            imgBuilder.MergeAttribute("src", imageUrl);            imgBuilder.MergeAttribute("alt", altText);            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);            var linkBuilder = new TagBuilder("a");            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName));            var text = linkBuilder.ToString(TagRenderMode.StartTag);            text += imgBuilder.ToString(TagRenderMode.SelfClosing);            text += linkBuilder.ToString(TagRenderMode.EndTag);            return MvcHtmlString.Create(text);        
		}         
		
		private static Dictionary<string, object> AnonymousObjectToKeyValue(object anonymousObject)        {            
			
			var dictionary = new Dictionary<string, object>();            
			if (anonymousObject != null)            {                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))                {                    dictionary.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(anonymousObject));                }            }            
			
			return dictionary;        
		}

		public static IHtmlString RenderScripts(this HtmlHelper htmlHelper) {

			var scripts = htmlHelper.ViewContext.HttpContext.Items["Scripts"] as IList<string>;

			if (scripts != null) {

				var builder = new StringBuilder();
				builder.AppendLine("<script type='text/javascript'>");
				builder.AppendLine("$(function() {");
				foreach (var script in scripts) {
					builder.AppendLine(script);
				}

				builder.AppendLine("});");
				builder.AppendLine("</script>");

				return new MvcHtmlString(builder.ToString());

			}

			return null;
		}
	}

	public static class ViewDataDictionaryExtensions {

		public static TAttribute GetModelAttribute<TAttribute>(this ViewDataDictionary viewData, bool inherit = false) where TAttribute : Attribute {

			if (viewData == null) throw new ArgumentNullException("viewData");
			
			var containerType = viewData.ModelMetadata.ContainerType;
		
			return ((TAttribute[])containerType.GetProperty(viewData.ModelMetadata.PropertyName)
				.GetCustomAttributes(typeof(TAttribute), inherit)).FirstOrDefault();
		}
	}

}
	
