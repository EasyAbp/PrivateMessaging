using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.AuthDemo
{
    public abstract class AuthDemoDomainService : DomainService
    {
        protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();
    }
}