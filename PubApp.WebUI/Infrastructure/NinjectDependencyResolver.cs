using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Moq;
using PubApp.Domain.Abstract;
using PubApp.Domain.Entities;
using PubApp.Domain.Concrete;

namespace PubApp.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
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

        private void AddBindings()
        {
            kernel.Bind<IPubRepository>().To<PubRepository>();
            
            //Mock<IPubRepository> mock = new Mock<IPubRepository>();
            //mock.Setup(m => m.Pubs).Returns(new List<Pub> {
            //new Pub { Name = "The Vine", Rating = 3.5 },
            //new Pub { Name = "Ape and Apple", Rating = 3 },
            //new Pub { Name = "The Dockyard", Rating = 4 }
            //});

            //kernel.Bind<IPubRepository>().ToConstant(mock.Object);
        }
    }
}