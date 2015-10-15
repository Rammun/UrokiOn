using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Security;
using DAL;
using System.Configuration;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementaions;
using Web.Models;
using Microsoft.AspNet.Identity;
using DAL.Entities;

namespace Web
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }


        //Извлекаем экземпляр контроллера для заданного контекста запроса и типа контроллера
        //protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        //{
        //    return controllerType == null ? null : (IController)kernel.Get(controllerType);
        //}

        //Определяем все привязки
        private void AddBindings()
        {
            kernel.Bind<ICityRepository>().To<EFCityRepository>();
            kernel.Bind<ICountryRepository>().To<EFCountryRepository>();
            kernel.Bind<IFriendRequestRepository>().To<EFFriendRequestRepository>();
            kernel.Bind<IGroupNewseRepository>().To<EFGroupNewseRepository>();
            kernel.Bind<IGroupProfileRepository>().To<EFGroupProfileRepository>();
            kernel.Bind<IGroupRepository>().To<EFGroupRepository>();
            kernel.Bind<IGroupRequestRepository>().To<EFGroupRequestRepository>();
            kernel.Bind<IGroupTypeRepository>().To<EFGroupTypeRepository>();
            kernel.Bind<IMemberRoleRepository>().To<EFMemberRoleRepository>();
            kernel.Bind<IMessageRepository>().To<EFMessageRepository>();
            kernel.Bind<IRegionRepository>().To<EFRegionRepository>();
            kernel.Bind<IApplicationUserRepository>().To<EFApplicationUserRepository>();
            kernel.Bind<IUserProfileRepository>().To<EFUserProfilRepository>();
            kernel.Bind<IWallOfUserRepository>().To<EFWallOfUserRepository>();
            //kernel.Bind<ApplicationUser>().ToSelf();
            kernel.Bind<ApplicationDbContext>().ToSelf();
        }
    }
}