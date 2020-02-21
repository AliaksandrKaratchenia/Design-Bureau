using Autofac;
using Design_Bureau.DAL.Repositories;

namespace Design_Bureau.Api.Modules
{
    public class DalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }
    }
}
