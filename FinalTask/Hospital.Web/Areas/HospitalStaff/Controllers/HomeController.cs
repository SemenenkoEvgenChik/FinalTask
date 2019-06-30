using Hospital.BusinessLogic.Services.Interface;
using Hospital.BusinessLogic.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Web.Areas.HospitalStaff.Controllers
{
    [Authorize(Roles = "HospitalStaff")]
    public class HomeController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public HomeController(IPatientService patientService ,IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public ActionResult Patients()
        {
            return View();
        }
        public ActionResult ShowPatients(PatientViewModel search, int page = 1, int size = 12, int sortIndex = 0)
        {
            var UserId = User.Identity.GetUserId();
            var doctorId = _doctorService.GetIdIdentityDoctor(UserId);
            var patients = _patientService.SearchPatientForHospitalStaff(search, page, size, sortIndex, doctorId);

            return PartialView("_SearchPatient", patients);
        }
        public ActionResult ShowDetails(int id)
        {
            var detail = _patientService.ShowDetails(id);
            return View(detail);
        }
        [Authorize(Roles = "HospitalStaff")]
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
    }
}