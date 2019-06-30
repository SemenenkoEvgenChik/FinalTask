using Hospital.BusinessLogic.Services.Interface;
using Hospital.BusinessLogic.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Hospital.BusinessLogic.Models.ViewModels;
using System;

namespace Hospital.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public HomeController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }
        public ActionResult Patients()
        {
            return View();
        }
        public ActionResult RecoveredPatients()
        {
            return View();
        }
        public ActionResult ShowPatients(PatientViewModel search, int page = 1, int size = 12, int sortIndex = 0)
        {
            var UserId = User.Identity.GetUserId();
            var doctorId = _doctorService.GetIdIdentityDoctor(UserId);
            var patients = _patientService.SearchPatient(search, page, size, sortIndex, doctorId);

            return PartialView("_SearchPatient", patients);
        }
        public ActionResult ShowRecoveredPatients(PatientViewModel search, int page = 1, int size = 12, int sortIndex = 0)
        {
            var UserId = User.Identity.GetUserId();
            var doctorId = _doctorService.GetIdIdentityDoctor(UserId);
            var patients = _patientService.SearchRecoveredPatient(search, page, size, sortIndex, doctorId);

            return PartialView("_SearchPatient", patients);
        }
        public ActionResult ShowDetails(int id)
        {
            var detail = _patientService.ShowDetails(id);
            return View(detail);
        }

        public ActionResult EstablishDiagnosis(EstablishDiagnosisViewModel establishDiagnosisViewModel)
        {
            _patientService.EstablishDiagnos(establishDiagnosisViewModel);

            return RedirectToAction("ShowDetails", new { id = establishDiagnosisViewModel.PatientId });
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult AddMedication(MedicationForDoctorViewModel medicationViewModel)
        {
            var UserId = User.Identity.GetUserId();
            var doctorId = _doctorService.GetIdIdentityDoctor(UserId);
            medicationViewModel.DoctorId = doctorId;
            _patientService.AddMedicationForDoctor(medicationViewModel);

            return RedirectToAction("Patients");
        }

        public ActionResult PatientCard(int HistoryIllnessId)
        {
            var medication = _patientService.GetMedication(HistoryIllnessId);
            return View(medication);
        }

        public ActionResult DischargeFromHospital(EstablishDiagnosisViewModel establishDiagnosisViewModel)
        {
            _patientService.DischargeFromHospital(establishDiagnosisViewModel);

            return RedirectToAction("ShowDetails", new { id = establishDiagnosisViewModel.PatientId });
        }
        public FilePathResult CreateCertificate(int id)
        {
            string file_path = Server.MapPath("~/CertificateFromTheHospital/Certificate.txt");
            _doctorService.CreateCertificate(id, file_path);
            // Путь к файлу
            // Тип файла - content-type
            string file_type = "application/txt";
            // Имя файла - необязательно
            string file_name = "Certificate.txt";
            return File(file_path, file_type, file_name);
        }
    }
}