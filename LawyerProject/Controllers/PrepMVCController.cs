using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LawyerProject.Controllers
{
    public class PrepMVCController : Controller
    {
        private IEnumerable<Type> typelist;
        public PrepMVCController()
        {
            typelist = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == "LawyerProject.Models.DB");
        }
        public async Task<IActionResult> Index()
        {

            Type type = typeof(DocumentKind);
            //Directory.CreateDirectory($@"./Services/{type.Name}Services");
            Directory.CreateDirectory($@"./Views/{type.Name}/");
           // await Create_Service(type);
            await Create_Controller(type);
            await Create_Index_View(type);
            await Create_Edit_View(type);
            await Create_Create_View(type);
            await Create_DetailsView(type);
            return RedirectToAction("Index", "Home");
        }

        private async Task Create_DetailsView(Type type)
        {
            string name = type.Name;
            string path = $"./Views/{name}/Details.cshtml";
            string fields = prepare_Details(type);
            string viewDetails =
@$"
@model LawyerProject.Models.DB.{name}

@{{
    ViewData[""Title""] = ""{name} Details"";
}}
<h1 class=""text-center text-secondary font-monospace"">@ViewData[""Title""]</h1>

<div>
    <h4>@ViewData[""Title""]</h4>
    <hr />
    <dl class=""row"">
{fields}
    </dl>
</div>
<div>
    <a class=""btn btn-outline-info"" asp-action=""Edit"" asp-route-id=""@Model?.Id"">Edit</a> |
    <a class=""btn btn-outline-info"" asp-action=""Index"">Back to List</a>
</div>

";
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(viewDetails);
            }
        }

        private string prepare_Details(Type type)
        {
            string feilds = "";
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (item.PropertyType.Name.Contains("IEnumerable") || item.Name.ToLower().Contains("_fk"))
                {

                }
                else
                {
                    feilds +=
$@"
        <dt class = ""col-sm-2"">
            @Html.DisplayNameFor(model => model.{item.Name})
        </dt>
        <dd class = ""col-sm-10"">
            @Html.DisplayFor(model => model.{item.Name})
        </dd>
";
                }
            }
            return feilds;
        }

        public async Task<IActionResult> getprop()
        {
            string result = "";
            int count = 0;

            //foreach (var item in typeof(ApplicationDbContext).GetProperties())
            //{
            //    if (item.PropertyType.Name.ToLower().Contains("dbset"))
            //    {
            //        result += $"======> {{ {item.PropertyType} }} \n";
            //        count++;
            //    }
            //}

            foreach (Type t in typelist)
            {
                result += $"======> {{ {t.Name} }} \n";
                count++;
            }

            result += $"\n Count is {count}";
            return Content(result);
        }
        private async Task Create_Controller(Type type)
        {
            string name = type.Name;
            string x =

@$"
namespace LawyerProject.Controllers
{{
    public class {name}Controller : GeneralController<{name}>
    {{
        private readonly I{name}Service _{name.ToLower()}Service;
        public {name}Controller(I{name}Service service) : base(service)
        {{
            _{name.ToLower()}Service= service;
        }}

        protected override int GetEntityId({name} entity)
        {{
            return entity.Id;
        }}
    }}
}}

";
            string path = $"./Controllers/{name}Controller.cs";
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(x);
            }

        }
        private async Task Create_Service(Type type)
        {
            string name = type.Name;
            string IServicepath = $"./Services/{name}Services/I{name}Service.cs";
            string IService =
@$"
namespace LawyerProject.Services
{{
    public interface I{name}Service:IGeneralService<{name}>
    {{
    }}
}}

";
            using (StreamWriter sw = new StreamWriter(IServicepath))
            {
                await sw.WriteAsync(IService);
            }
            string ServicePath = $"./Services/{name}Services/{name}Service.cs";
            string Service =
@$"
using LawyerProject.Data;

namespace LawyerProject.Services
{{
    public class {name}Service : GeneralService<{name}>, I{name}Service
    {{
        public {name}Service(ApplicationDbContext db) : base(db)
        {{
        }}
    }}
}}

";
            using (StreamWriter sw = new StreamWriter(ServicePath))
            {
                await sw.WriteAsync(Service);
            }
        }
        private async Task Create_Index_View(Type type)
        {
            string name = type.Name;
            string path = @$"./Views/{name}/Index.cshtml";
            string tablebody = "";
            string tablehead = Create_Table(type, out tablebody);
            string indexView =
@$"
@model IEnumerable<LawyerProject.Models.DB.{name}>

@{{
    ViewData[""Title""] = ""{name}"";
}}
<h1 class=""text-center text-secondary font-monospace"">@ViewData[""Title""]</h1>

<p>
    <a class=""btn btn-primary"" asp-action=""Create"">إضافة</a>
</p>
<table class=""text-center table table-bordered table-hover table-striped"">
    <thead>
        <tr>
{tablehead}    
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {{
        <tr>
{tablebody}
            <td>
                <a class=""btn btn-outline-info mx-1"" asp-action=""Edit"" asp-route-id=""@item.Id"">Edit</a> 
                    <a class=""btn btn-outline-info mx-1"" asp-action=""Details"" asp-route-id=""@item.Id"">Details</a> 
            </td>
        </tr>
}}
    </tbody>
</table>

";
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(indexView);
            }
        }
        private string Create_Table(Type type, out string body)
        {
            string tbl_Head = "";
            body = "";
            foreach (System.Reflection.PropertyInfo item in type.GetProperties())
            {
                if (!item.Name.Contains("FK") && !item.PropertyType.Name.Contains("IEnumerable"))
                {

                    tbl_Head +=
$@"
            <th>
                @Html.DisplayNameFor(model => model.{item.Name})
            </th>

";
                    body +=
$@"
            <td>
                @Html.DisplayFor(modelItem => item.{item.Name})
            </td>
";
                }
            }

            return tbl_Head;
        }

        private async Task Create_Edit_View(Type type)
        {
            string name = type.Name;
            string path = $@"./Views/{name}/Edit.cshtml";
            string fieds = prepare_Edit(type, true);
            string editView =
$@"
@model LawyerProject.Models.DB.{name}

@{{
    ViewData[""Title""] = ""Edit {name}"";
}}

<h1 class=""text-center text-secondary font-monospace"">@ViewData[""Title""]</h1>

<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
{fieds}
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a class=""btn btn-outline-info""  asp-action=""Index"">Back to List</a>
</div>

@section Scripts {{
    @{{await Html.RenderPartialAsync(""_ValidationScriptsPartial"");}}
}}

";
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(editView);
            }
        }
        public string prepare_Edit(Type type, bool IsEdit)
        {
            string feilds = "";
            foreach (PropertyInfo item in type.GetProperties())
            {
                if (item.PropertyType.Name.Contains("IEnumerable") || typelist.Contains(item.PropertyType))
                {
                    continue;

                }
                else if (item.Name.ToLower().Contains("id") && IsEdit)
                {
                    feilds +=
$@"
            <input type=""hidden"" asp-for=""{item.Name}"" />

";
                    continue;

                }
                else if (item.Name.ToLower().Contains("fk"))
                {
                    feilds +=
$@"

            <div class=""form-group"">
                <label asp-for=""{item.Name}"" class=""control-label""></label>
                <select asp-for=""{item.Name}"" class=""form-control"" asp-items=""ViewBag.{item.Name}""></select>
                <span asp-validation-for=""{item.Name}"" class=""text-danger""></span>
            </div>
";
                    continue;

                }
                else if (item.PropertyType.Name.ToLower().Contains( "bool"))
                {
                    feilds +=
$@"
            <div class=""form-check"">
              <input class=""form-check-input"" type=""checkbox"" asp-for=""{item.Name}"" id=""{item.Name}"">
              <label class=""form-check-label"" asp-for=""{item.Name}"">
              </label>
            </div>
";
                    continue;
                }
                else if (!item.Name.ToLower().Contains("id"))
                {
                    feilds +=
$@"
            <div class=""form-group"">
                <label asp-for=""{item.Name}"" class=""control-label""></label>
                <input asp-for=""{item.Name}"" class=""form-control"" />
                <span asp-validation-for=""{item.Name}"" class=""text-danger""></span>
            </div>
";
                    continue;

                }
            }
            return feilds;
        }
        public async Task Create_Create_View(Type type)
        {
            string name = type.Name;
            string path = @$"./Views/{name}/Create.cshtml";
            string feilds = prepare_Edit(type, false);
            string pody =
@$"
@model LawyerProject.Models.DB.{name}

@{{
    ViewData[""Title""] = ""Create {name}"";
}}

<h1 class=""text-center text-secondary font-monospace"">@ViewData[""Title""]</h1>

<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
{feilds}
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a class=""btn btn-outline-info""  asp-action=""Index"">Back to List</a>
</div>

@section Scripts {{
    @{{await Html.RenderPartialAsync(""_ValidationScriptsPartial"");}}
}}

";


            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(pody);
            }
        }
    }
}
