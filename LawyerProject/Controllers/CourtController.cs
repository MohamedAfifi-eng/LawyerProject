using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace LawyerProject.Controllers
{
    public class CourtController : GeneralController<Court>
    {
        private readonly IcourtService _courtService;
        private readonly ICourtKindService _courtKindService;
        private readonly ICityService _CityService;
        private readonly INyabaKindService _nyabaKindService;
        public CourtController(IcourtService service,
                               ICourtKindService courtKindService,
                               ICityService cityService,
                               INyabaKindService nyabaKindService) : base(service)
        {
            _courtService = service;
            _courtKindService = courtKindService;
            _CityService = cityService;
            _nyabaKindService = nyabaKindService;
        }
        protected override int GetEntityId(Court entity)
        {
            return entity.ID;
        }
        public override Court? Find(int id)
        {
            return _courtService.Find_Incloude_Nyabat_City_Kind(id);
        }
        public override IEnumerable<Court> GetAll(int page)
        {
            return _courtService.GetAll_Incloude_City_Kind(page);
        }
        public override void PrepViewBags()
        {
            ViewBag.CityID_FK = new SelectList(_CityService.GetAll(), "Id", "Name");
            ViewBag.CourtKindID_FK = new SelectList(_courtKindService.GetAll(), "Id", "Name");
        }
        public override IActionResult Details(int id)
        {
            ViewBag.NyabaKindId_FK = new SelectList(_nyabaKindService.GetAll(), "Id", "Name");
            return base.Details(id);
        }
        //public override IActionResult GetAllAPI()
        //{
        //    var result = GetAll(0).Select(x => new { x.ID, x.Name });
        //    var options = new JsonSerializerOptions
        //    {
        //        Encoder = JavaScriptEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic })
        //    };
        //    return Json(result, options);
        //}
    }
}
