using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interseptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JobManager>().As<IJobService>().SingleInstance();
            builder.RegisterType<JobDal>().As<IJobDal>().SingleInstance();

            builder.RegisterType<TypeManager>().As<ITypeService>().SingleInstance();
            builder.RegisterType<TypeDal>().As<ITypeDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ExperienceManager>().As<IExperienceService>().SingleInstance();
            builder.RegisterType<ExperienceDal>().As<IExperienceDal>().SingleInstance();

            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>().SingleInstance();
            builder.RegisterType<SubCategoryDal>().As<ISubCategoryDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<CityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<EducationManager>().As<IEducationService>().SingleInstance();
            builder.RegisterType<EducationDal>().As<IEducationDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
