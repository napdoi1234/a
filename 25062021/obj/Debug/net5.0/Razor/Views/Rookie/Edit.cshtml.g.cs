#pragma checksum "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7af818f3c0067e38a19744a758c0b38c982ac00a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rookie_Edit), @"mvc.1.0.view", @"/Views/Rookie/Edit.cshtml")]
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
#line 1 "D:\tranning-nash\25062021\Views\_ViewImports.cshtml"
using tranning;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\tranning-nash\25062021\Views\_ViewImports.cshtml"
using tranning.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7af818f3c0067e38a19744a758c0b38c982ac00a", @"/Views/Rookie/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9fde7e3d707e5efdc27a482b8a0a01fd1a4c4a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Rookie_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PersonModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
  
    ViewBag.Title = "Update person";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"jumbotron\">\r\n    <h3>Form Update A Person</h3>\r\n");
#nullable restore
#line 7 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
     using (Html.BeginForm("Edit", "Rookie", FormMethod.Post))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>");
#nullable restore
#line 9 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
         Write(Html.ValidationSummary(true,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 12 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 13 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.FirstName,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 14 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.FirstName,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 18 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 19 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.LastName,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.LastName,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 24 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 25 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.Gender,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 26 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.Gender,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 30 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.DateOfBirth));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 31 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.DateOfBirth,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 32 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.DateOfBirth,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 36 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 37 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.PhoneNumber,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 38 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.PhoneNumber,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 42 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.BirthPlace));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 43 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.BirthPlace,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 47 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.IsGraduated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 48 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.DropDownListFor(
        model => model.IsGraduated,
        new SelectList(
        new List<Object>{
        new { value = true , text = "Done" },
        new { value = false , text = "Not Yet" } },
        "value",
        "text"
        ),
        new {@class = "form-control"}
        ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 62 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.LabelFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 63 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.EditorFor(model => model.Email,new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 64 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.Email,"",new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 66 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"submit\" value=\"Update\" class=\"form-control\">\r\n");
#nullable restore
#line 69 "D:\tranning-nash\25062021\Views\Rookie\Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersonModel> Html { get; private set; }
    }
}
#pragma warning restore 1591