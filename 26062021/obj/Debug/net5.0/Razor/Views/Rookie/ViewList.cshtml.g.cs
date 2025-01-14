#pragma checksum "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bde13f8aab4506667de6b1ed5235e33ee12e0139"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rookie_ViewList), @"mvc.1.0.view", @"/Views/Rookie/ViewList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\tranning-nash\26062021\Views\_ViewImports.cshtml"
using _26062021;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\tranning-nash\26062021\Views\_ViewImports.cshtml"
using _26062021.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bde13f8aab4506667de6b1ed5235e33ee12e0139", @"/Views/Rookie/ViewList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"361a08088a6d353d013dd7bca55f0378e96d3b1c", @"/Views/_ViewImports.cshtml")]
    public class Views_Rookie_ViewList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PersonModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/view_list.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
  
    ViewBag.Title = "View List Person";
    var index = 1;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bde13f8aab4506667de6b1ed5235e33ee12e01393556", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-10\">\r\n        <h3>List Person in Rookie</h3>\r\n    </div>\r\n    <div class=\"col-2\">\r\n        <a class=\"btn btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 290, "\"", 318, 1);
#nullable restore
#line 12 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
WriteAttributeValue("", 297, Url.Action("Create"), 297, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" role=""button"">Add New Person</a>
    </div>
</div>

<br>
<table class=""table table-striped table-dark"">
    <thead>
        <tr>
            <th scope=""col"">STT</th>
            <th scope=""col"">FullName</th>
            <th scope=""col"">Gender</th>
            <th scope=""col"">PhoneNumber</th>
            <th scope=""col"">BirthPlace</th>
            <th scope=""col"">Age</th>
            <th scope=""col"">IsGraduated</th>
            <th scope=""col"">Email</th>
            <th scope=""col"">Action</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 35 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                           Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1011, "\"", 1062, 1);
#nullable restore
#line 36 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
WriteAttributeValue("", 1018, Url.Action("Detail" , new {id = @item.Id }), 1018, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 36 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                                                                      Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td>");
#nullable restore
#line 37 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
               Write(item.Gender.ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
               Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 39 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                 if (@item.BirthPlace != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 41 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                   Write(item.BirthPlace.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 42 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td></td>\r\n");
#nullable restore
#line 46 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 47 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
               Write(item.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 48 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                 if (@item.IsGraduated)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Done</td>\r\n");
#nullable restore
#line 51 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Not Yet</td>\r\n");
#nullable restore
#line 55 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 56 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a class=\"btn btn-secondary\"");
            BeginWriteAttribute("href", " href=\"", 1750, "\"", 1799, 1);
#nullable restore
#line 57 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
WriteAttributeValue("", 1757, Url.Action("Edit" , new {id = @item.Id }), 1757, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" , role=\"button\">Edit</a>\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-toggle=\"modal\" data-target=\"#confirmDelete\"");
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 1943, "\"", 2016, 6);
            WriteAttributeValue("", 1974, "Confirm(\'", 1974, 9, true);
#nullable restore
#line 59 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
WriteAttributeValue("", 1983, item.Id, 1983, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1993, "\',", 1993, 2, true);
            WriteAttributeValue(" ", 1995, "\'", 1996, 2, true);
#nullable restore
#line 59 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
WriteAttributeValue("", 1997, item.FullName, 1997, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2013, "\');", 2013, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Delete\r\n                    </button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 64 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"

            index++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        
    </tbody>


    <!-- Modal -->
    <div class=""modal fade"" id=""confirmDelete"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
        aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">Đu diu goan tu đi lít</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    We will be so sad
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">No</button>
");
#nullable restore
#line 87 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                     using (Html.BeginForm("Delete", "Rookie", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <input type=\"hidden\" id=\"Id\" name=\"Id\" />\r\n                        <button type=\"submit\" class=\"btn btn-primary\">Yes</button>\r\n");
#nullable restore
#line 91 "D:\tranning-nash\26062021\Views\Rookie\ViewList.cshtml"
                    }             

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PersonModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
