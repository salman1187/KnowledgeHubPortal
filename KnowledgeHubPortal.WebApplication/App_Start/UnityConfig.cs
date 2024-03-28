using KnowledgeHubPortal.WebApplication.Controllers;
using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain;
using System;
using System.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace KnowledgeHubPortal.WebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var implementationTypeName = ConfigurationManager.AppSettings["KHPortalRepositoryImplementationType"];
            if (!string.IsNullOrEmpty(implementationTypeName))
            {
                Type implementationType = Type.GetType(implementationTypeName);
                if (implementationType != null)
                {
                    container.RegisterType(typeof(IKHPortalRepository), implementationType);
                }
            }
            //container.RegisterType<IKHPortalRepository, KHPortalRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}