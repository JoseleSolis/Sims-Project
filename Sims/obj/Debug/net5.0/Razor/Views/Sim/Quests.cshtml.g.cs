#pragma checksum "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbc7dbba99a81baa158284e709d04a1f4f4e566b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sim_Quests), @"mvc.1.0.view", @"/Views/Sim/Quests.cshtml")]
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
#line 1 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\_ViewImports.cshtml"
using Sims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\_ViewImports.cshtml"
using Sims.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\_ViewImports.cshtml"
using Sims.Models.Relations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\_ViewImports.cshtml"
using Sims.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\_ViewImports.cshtml"
using System.Web.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbc7dbba99a81baa158284e709d04a1f4f4e566b", @"/Views/Sim/Quests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3195615aab047eac0eefd9b1d6fa14d9a9caf0e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Sim_Quests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimQuestViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
 using (Html.BeginForm("Quests", "Sim", FormMethod.Post, new { id = "simQuests" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group margin\">\r\n        ");
#nullable restore
#line 7 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
   Write(Html.LabelFor(p => p.QuestID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 8 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
   Write(Html.DropDownListFor(p => p.QuestID, new SelectList(Model.Quests, "QuestID", "Name"), new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 11 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.SimID));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.LastName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.Gender));

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.Money));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Sim.LifeStage));

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.SimID));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.Date));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.World.WorldID));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.World.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.World.Description));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
Write(Html.HiddenFor(p => p.Travel.WorldID));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Enter Quest</button>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbc7dbba99a81baa158284e709d04a1f4f4e566b8088", async() => {
                WriteLiteral("Back to profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"
                              WriteLiteral(Model.Travel.SimID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\Jose Alejandro\Documents\asp .net\Projects\Sims\Sims\Sims\Views\Sim\Quests.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimQuestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
