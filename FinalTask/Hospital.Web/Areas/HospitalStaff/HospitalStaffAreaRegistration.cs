using System.Web.Mvc;

namespace Hospital.Web.Areas.HospitalStaff
{
    public class HospitalStaffAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HospitalStaff";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HospitalStaff_default",
                "HospitalStaff/{controller}/{action}/{id}",
                new { action = "Patients", id = UrlParameter.Optional }
            );
        }
    }
}