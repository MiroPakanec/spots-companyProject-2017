using System;
using spots.DAL.Mongo.Context;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Location;
using spots.Models.Business;
using spots.Models.Location.Interfaces;
using spots.Models.Location.ViewModels;

namespace spots.DAL.Queries.AtomicWork.Location
{
    public class AtomicLocationWork : AtomicWork, IAtomicLocationWork
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly ILocationRepository _locationRepository;

        public AtomicLocationWork()
        {
            _businessRepository = new BusinessRepository(new MongoContextGeneric<Models.Business.Business>());
            _locationRepository = new LocationRepository(new MongoContextGeneric<Models.Location.Location>());
        }

        public override string Desc => "Atomic location work.";

        public void Add(ILocation location)
        {
            try
            {
                var headquaters = new BusinessHeadquaters
                {
                    Id = location.Id,
                    City = location.City
                };

                Lock();

                _locationRepository.Add(location);
                _businessRepository.AddHeadquaters(headquaters, location.BusinessId);
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

        public void Add(CreateLocationViewModel viewModel)
        {
            try
            {
                var location = new Models.Location.Location
                {
                    Id = viewModel.LocationId,
                    BusinessId = viewModel.BusinessId,
                    Address = viewModel.Address,
                    City = viewModel.City,
                    Zip = viewModel.Zip,
                    Country = viewModel.Country
                    //TODO: ADD LOCATION NAME
                };

                var headquaters = new BusinessHeadquaters
                {
                    Id = viewModel.LocationId,
                    City = viewModel.City
                };

                Lock();

                _locationRepository.Add(location);
                _businessRepository.AddHeadquaters(headquaters, location.BusinessId);
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