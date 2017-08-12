using System;
using Castle.Core.Internal;
using spots.DAL.Mongo.Context;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Authorisation.Roles;
using spots.Models.Business.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.User;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Business
{
    public class AtomicBusinessWork : AtomicWork, IAtomicBusinessWork
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly ISpotUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IGroupRepository _groupRepository;

        public AtomicBusinessWork(IGroupRepository groupRepository)
        {
            _businessRepository = new BusinessRepository(new MongoContextGeneric<Models.Business.Business>());
            _userRepository = new SpotUserRepository(new MongoContextGeneric<SpotUser>());
            _locationRepository = new LocationRepository(new MongoContextGeneric<Models.Location.Location>());
            _groupRepository = groupRepository;
        }

        public override string Desc => "Atomic business work.";

        public void Add(IBusiness business, ILocation location, IUserBusiness userBusiness, IGroup group)
        {
            try
            {
                Lock();

                _businessRepository.Add(business);
                _locationRepository.Add(location);
                _groupRepository.Add(group);

                foreach (var email in business.Members)
                {
                    var userGroup = new UserGroup
                    {
                        Id = group.Id,
                        Name = group.Name,
                        Role = GroupRoles.Admin
                    };

                    _userRepository.AddBusinessWithEmail(userBusiness, email);
                    _userRepository.AddGroupWithEmail(userGroup, email);
                }
            }
            catch (Exception)
            {
                //TODO: Rollback logic
                throw new Exception("Failed to perform atomic action - " + Desc);
            }
            finally
            {
                Unlock();
            }

        }
    }
}