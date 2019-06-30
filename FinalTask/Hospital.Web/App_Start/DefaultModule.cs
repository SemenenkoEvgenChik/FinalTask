using AutoMapper;
using Hospital.BusinessLogic;
using Hospital.BusinessLogic.Services;
using Hospital.BusinessLogic.Services.Interface;
using Hospital.DAL;
using Hospital.DAL.Entities;
using Hospital.DAL.Repositories;
using Hospital.DAL.Repositories.Interfaces;
using Hospital.DAL.UnitOfWorks;
using Hospital.DAL.UnitOfWorks.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System.Data.Entity;

namespace Hospital.Web.App_Start
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {

            var mapperConfiguration = AutoMapperConfig.CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().ToMethod(ctx =>
             new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));

            Bind<DbContext>().To<HospitalContext>();

            Bind<IUnitOfWork>().To<EFUnitOfWork>();

            Bind<IDoctorRepository>().To<DoctorRepository>();
            Bind<IHistoryIllnessRepository>().To<HistoryIllnessRepository>();
            Bind<IMedicationRepository>().To<MedicationRepository>();
            Bind<IPatientRepository>().To<PatientRepository>();

            Bind<IDoctorService>().To<DoctorService>();
            Bind<IPatientService>().To<PatientService>();

            Bind(typeof(IUserStore<ApplicationUser>)).To(typeof(UserStore<ApplicationUser>)).WithConstructorArgument(arg => Kernel.Get<DbContext>());
            Bind<ApplicationUserManager>().ToSelf();
        }
    }
}