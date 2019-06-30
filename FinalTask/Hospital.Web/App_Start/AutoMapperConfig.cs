using AutoMapper;
using Hospital.Web.MappingProfiles;

namespace Hospital.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DefaultProfile>();
            });

            return configuration;
        }
    }
}