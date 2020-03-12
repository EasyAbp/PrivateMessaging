using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.Users
{
    public class PmUserLookupService : UserLookupService<PmUser, IPmUserRepository>, IPmUserLookupService
    {
        public PmUserLookupService(IPmUserRepository userRepository, IUnitOfWorkManager unitOfWorkManager) : base(userRepository, unitOfWorkManager)
        {
        }

        protected override PmUser CreateUser(IUserData externalUser)
        {
            throw new System.NotImplementedException();
        }
    }
}