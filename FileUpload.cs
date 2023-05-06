using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Serialization;

public static class CustomHtmlHelpers
{
    //public static MvcHtmlString FileUpload(this HtmlHelper htmlHelper, string name)
    //{
    //    //var name = ExpressionHelper.GetExpressionText(expression);
    //    //var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

    //    //var fileInputTag = new TagBuilder("input");
    //    //fileInputTag.Attributes.Add("type", "file");
    //    //fileInputTag.Attributes.Add("name", name);
    //    //fileInputTag.Attributes.Add("data-validation", "mime");
    //    //fileInputTag.Attributes.Add("data-validation-allowing", "pdf,doc,docx");
    //    //fileInputTag.Attributes.Add("data-validation-max-size", "2M");

    //    var hiddenFieldTag = new TagBuilder("input");
    //    hiddenFieldTag.Attributes.Add("type", "hidden");
    //    hiddenFieldTag.Attributes.Add("name", $"{name}_FilePath");

    //    string script = $@"
    //        $('input[name={name}]').on('change', function () {{
    //            var fileInput = this;
    //            var formData = new FormData();
    //            formData.append('file', fileInput.files[0]);
    //            $.ajax({{
    //                url: '{htmlHelper.ViewContext.HttpContext.Request.Url.Scheme}://{htmlHelper.ViewContext.HttpContext.Request.Url.Authority}/Upload/SaveFile',
    //                type: 'POST',
    //                data: formData,
    //                processData: false,
    //                contentType: false,
    //                success: function (data) {{
    //                    $('input[name={name}_FilePath]').val(data);
    //                }}
    //            }});
    //        }});";

    //    htmlHelper.ViewContext.Writer.Write($"<script>{script}</script>");

    //    return MvcHtmlString.Create($"{fileInputTag.ToString(TagRenderMode.SelfClosing)}{hiddenFieldTag.ToString(TagRenderMode.SelfClosing)}");    


        //fileInputTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

        //return MvcHtmlString.Create(fileInputTag.ToString(TagRenderMode.SelfClosing));
    }
