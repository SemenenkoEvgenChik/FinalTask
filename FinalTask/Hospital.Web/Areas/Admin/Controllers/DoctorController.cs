using Hospital.BusinessLogic.Services.Interface;
using Hospital.BusinessLogic.ViewEnums;
using Hospital.BusinessLogic.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public ActionResult Doctors()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(DoctorViewModel doctorViewModel)
        {
            var entity = _doctorService.Edit(doctorViewModel);

            return RedirectToAction("Doctors");
        }

        [HttpPost]
        public ActionResult AddDoctor(DoctorViewModel doctorViewModel)
        {
            if (ModelState.IsValid)
            {
                _doctorService.AddDoctor(doctorViewModel);
                return Json(new { success = true });
            }
            return Json(new { success = false, error = ModelState.Values.FirstOrDefault(v => v.Errors?.Count > 0).Errors.FirstOrDefault()?.ErrorMessage });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _doctorService.SotfDelete(id);
            return RedirectToAction("Doctors");
        }

        public ActionResult ShowDoctors(DoctorViewModel search, int page = 1, int size = 5, int sortIndex = 0)
        {
            var doctors = _doctorService.SearchDoctor(search, page, size,sortIndex);
            return PartialView("_SearchDoctors", doctors);
        }

        public ActionResult SearchToAssign(ViewClassificationOfDoctors search = 0)
        {
            var doctors = _doctorService.SearchToAssign(search);
            return PartialView("_AppointDoctor", doctors);
        }

        public ActionResult AppointADoctorToThePatient(DoctorAssigningViewModel doctorAssigningViewModel)
        {
             _doctorService.Appoint(doctorAssigningViewModel);

            return RedirectToAction("ShowDetails", "Patient", new { id = doctorAssigningViewModel.PatientId });
        }
    }
}