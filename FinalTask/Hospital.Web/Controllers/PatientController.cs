using Hospital.BusinessLogic.Services.Interface;
using Hospital.BusinessLogic.ViewModels;
using System.Web.Mvc;

namespace Hospital.Web.Controllers
{
    [Authorize(Roles = "Doctor")]
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

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel patient)
        {
            _patientService.Create(patient);
            return RedirectToAction("Patients");
        }
        public ActionResult ShowDetails(int id)
        {
            var detail = _patientService.ShowDetails(id);
            return View(detail);
        }
        public ActionResult ShowPatients(PatientViewModel search, int page = 1, int size = 12, int sortIndex=0)
        {
            var patients = _patientService.SearchPatient(search, page, size, sortIndex);

            return PartialView("_SearchPatient",patients);
        }
     
    }
}