using Hospital.BusinessLogic.Services.Interface;
using Hospital.BusinessLogic.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Hospital.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public ActionResult Patients()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.Create(patient);
                return Json(new { success = true });
            }
            return Json(new { success = false, error = ModelState.Values.FirstOrDefault(v => v.Errors?.Count > 0).Errors.FirstOrDefault()?.ErrorMessage });
        }
        public ActionResult ShowDetails(int id)
        {
            var detail = _patientService.ShowDetails(id);
            return View(detail);
        }
        public ActionResult ShowPatients(PatientViewModel search, int page = 1, int size = 12, int sortIndex=0,int doctorId = 0)
        {
            var patients = _patientService.SearchPatient(search, page, size, sortIndex,doctorId);

            return PartialView("_SearchPatient",patients);
        }
     
    }
}