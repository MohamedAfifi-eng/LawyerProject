using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LawyerProject.Controllers
{
    //[Route("[Controller]")]
    public abstract class GeneralController<T> : Controller
    {
        protected readonly IGeneralService<T> _service;

        protected GeneralController(IGeneralService<T> service)
        {
            _service = service;
        }
        #region Use Service For Actions
            public virtual void PrepViewBags()
            {

            }
            public virtual T? Find(int id)
            {
                return _service.Find(id);
            }
            public virtual IEnumerable<T> GetAll(int page)
            {
                return _service.GetAll(page);
            }
            public virtual void CreateFunc(T entity)
            {
                _service.Add(entity);
            }
            public virtual void UpdateFunc(T entity)
            {
                _service.Update(entity);
            }
        public virtual T? FindForDetails(int id)
                {
                    return Find(id);
                }
            protected abstract int GetEntityId(T entity);
        #endregion

        #region Actions
        public virtual IActionResult Index(int id)
        {
            IEnumerable<T> Model = GetAll(id);
            return View(Model);
        }
        public virtual IActionResult Delete(int id)
        {
            T? entity = Find(id);
            if (entity is null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost(nameof(Delete))]
        public virtual IActionResult ConfirmDelete(int id)
        {
            T? entity = _service.Find(id);
            if (entity is null)
            {
                return NotFound();
            }
            Boolean result = _service.Delete(entity);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return RedirectToAction(nameof(Index));
        }
        public virtual IActionResult Details(int id)
        {
            T? model = FindForDetails(id);
            if (model is null)
            {
                return NotFound();
            }
            return View(model);
        }
        public virtual IActionResult Create()
        {
            PrepViewBags();
            return View();
        }
        [HttpPost]
        public virtual IActionResult Create(T entity, string? referer = "")
        {
            if (ModelState.IsValid)
            {
                CreateFunc(entity);
                if (!string.IsNullOrEmpty(referer))
                {
                    return Redirect(referer);
                }

                return RedirectToAction(nameof(Details), new { id = GetEntityId(entity) });
            }
            PrepViewBags();
            return View(entity);
        }
        public virtual IActionResult Edit(int id)
        {
            T? entity = _service.Find(id);
            if (entity is null)
                return NotFound();
            PrepViewBags();
            return View(entity);
        }
        [HttpPost]
        public virtual IActionResult Edit(T entity)
        {

            if (ModelState.IsValid)
            {
                UpdateFunc(entity);
                return RedirectToAction(nameof(Details), new { id = GetEntityId(entity) });
            }
            PrepViewBags();
            return View(entity);
        }


        #endregion

        #region API
        public virtual string GetAllAPI()
        {
            return Serialize(GetAll(0));
        }


        [HttpPost("api/create")]
        public virtual IActionResult CreateApi(T entity)
        {
            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return Json(entity);
            }
            else
            {
                return StatusCode(400, entity);
            }
        }

        #endregion

        #region Extra Functions
            protected string Serialize(object entity)
        {
            return JsonConvert.SerializeObject(entity, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
        #endregion
    }
}
