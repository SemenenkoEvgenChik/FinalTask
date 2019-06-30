using AutoMapper;
using Hospital.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.WEB.Tests
{
    public class MapperTest
    {
        private static IMapper mapper;

        public static IMapper AutoMapper
        {
            get
            {
                if (mapper is null)
                {
                    var configuration = AutoMapperConfig.CreateConfiguration();
                    mapper = configuration.CreateMapper();
                }
                return mapper;
            }
        }

    }
}
