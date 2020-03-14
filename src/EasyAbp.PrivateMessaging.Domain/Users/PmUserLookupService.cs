using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace EasyAbp.PrivateMessaging.Users
{
    public class PmUserLookupService : UserLookupService<PmUser, IPmUserRepository>, IPmUserLookupService
    {
        private readonly IPmUserRepository _userRepository;

        public PmUserLookupService(
            IPmUserRepository userRepository,
            IUnitOfWorkManager unitOfWorkManager) : base(userRepository, unitOfWorkManager)
        {
            _userRepository = userRepository;
        }

        protected override PmUser CreateUser(IUserData externalUser)
        {
            throw new System.ApplicationException();
        }

        public virtual async Task<IReadOnlyList<PmUser>> GetListByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _userRepository.GetListAsync(ids);
        }
    }
}