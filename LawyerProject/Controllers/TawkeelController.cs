using LawyerProject.MyServices.UploadedFileService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.VisualBasic;

namespace LawyerProject.Controllers
{
    public class TawkeelController : GeneralController<Tawkeel>
    {
        private readonly ITawkeelService _tawkeelService;
        private readonly IMaktabTawseekService _maktabTawseekService;
        private readonly IUploadedFileService _uploadedFileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TawkeelController(ITawkeelService service,
                                 IMaktabTawseekService maktabTawseekService,
                                 IUploadedFileService uploadedFileService,
                                 IWebHostEnvironment webHostEnvironment) : base(service)
        {
            _tawkeelService = service;
            _maktabTawseekService = maktabTawseekService;
            _uploadedFileService = uploadedFileService;
            _webHostEnvironment = webHostEnvironment;
        }
        public override void PrepViewBags()
        {
            ViewBag.MaktabTawseekId_FK = new SelectList(_maktabTawseekService.GetAll(), "Id", "Name");
        }
        public override Tawkeel? FindForDetails(int id)
        {
            return _tawkeelService.Find_with_MaktabTawseek(id);
        }
        public override IEnumerable<Tawkeel> GetAll(int page)
        {
            return _tawkeelService.GetAll_with_MaktabTawseek(page);
        }
        protected override int GetEntityId(Tawkeel entity)
        {
            return entity.Id;
        }
        public IActionResult CreateTawkeel(Tawkeel entity,IFormFile? file ,string? referer)
        {
            if (ModelState.IsValid)
            {
                CreateFunc(entity);
                if (file!=null)
                {
                    string path= _uploadedFileService.UploadFile(file, $"Tawkeel/{entity.Id}");
                    entity.TawkeelPath = path;
                    UpdateFunc(entity);
                }
                if (referer != null)
                {
                    return Redirect(referer);
                }
                return RedirectToAction(nameof(Details), new { id = entity.Id });
            }
            else
            {
                return View("Create", entity);
            }

        }
        public IActionResult EditTawkeel(Tawkeel entity, IFormFile? file, string? referer)
        {
            if (ModelState.IsValid)
            {
                if (file is not null)
                {
                    if (entity.TawkeelPath!=null)
                    {
                        _uploadedFileService.DeleteUploadedFile(entity.TawkeelPath);
                    }
                  var filePath=  _uploadedFileService.UploadFile(file, $"Tawkeel/{entity.Id}");
                    entity.TawkeelPath= filePath;
                    UpdateFunc(entity);
                }
                else
                {
                    UpdateFunc(entity);
                }
                if (referer !=null)
                {
                    return Redirect(referer);
                }
                return RedirectToAction(nameof(Details), new { id = entity.Id });
            }
            return View(nameof(Edit), entity);

        }
        public IActionResult Download(int id)
        {
            var entity = Find(id);

            if (entity == null || entity.TawkeelPath == null || !System.IO.File.Exists(_webHostEnvironment.WebRootPath + "/" + entity.TawkeelPath))
                return NotFound();
            
            string path= entity.TawkeelPath;
            FileInfo fileInfo = new FileInfo(path);
            string filename = fileInfo.Name;
            return File(path, "application/octet-stream",filename);
        }
    }
}
