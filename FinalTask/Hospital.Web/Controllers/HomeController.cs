using System.Web.Mvc;

namespace Hospital.Web.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            if (Request.IsAuthenticated && User.IsInRole("Doctor"))
            {
                return RedirectToAction("Patients", "Home", new { area = "Doctor" });
            }
            if (Request.IsAuthenticated && User.IsInRole("HospitalStaff"))
            {
                return RedirectToAction("Patients", "Home", new { area = "HospitalStaff" });
            }
            return RedirectToAction("Login","Account");
        }
    }
}