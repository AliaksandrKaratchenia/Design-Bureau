using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Bureau.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Design_Bureau.Api.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("designers-list")]
    public class DesignersListHelper : TagHelper
    {
        [HtmlAttributeName("for-designers-list")]
        public ModelExpression List { get; set; }
 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "DesignersList";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            foreach (var item in List.Model as IEnumerable<Designer>)
            {
                sb.AppendLine($"<span>Name: {item.Name}</span> <br/>");
            }

            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
