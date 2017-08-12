using System;
using Microsoft.Practices.Unity;
using spots.BL;
using spots.BL.Core;
using spots.BL.Core.Interfaces;
using spots.BL.Facades;
using spots.BL.Facades.Interfaces;
using spots.Controllers;
using spots.DAL.Mongo;
using spots.DAL.Mongo.Context;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.AtomicWork.Business;
using spots.DAL.Queries.AtomicWork.Event;
using spots.DAL.Queries.AtomicWork.Group;
using spots.DAL.Queries.AtomicWork.Location;
using spots.DAL.Queries.AtomicWork.Modules.Timeline;
using spots.DAL.Queries.AtomicWork.Spot;
using spots.DAL.Queries.AtomicWork.User;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Account.Interfaces;
using spots.Models.Account.Viewmodels;
using spots.Models.Business;
using spots.Models.Business.Interfaces;
using spots.Models.Business.ViewModels;
using spots.Models.Event;
using spots.Models.Event.Interfaces;
using spots.Models.Event.ViewModels;
using spots.Models.Feedback;
using spots.Models.Feedback.Interfaces;
using spots.Models.Group;
using spots.Models.Group.Interfaces;
using spots.Models.Location;
using spots.Models.Location.Interfaces;
using spots.Models.Log;
using spots.Models.Spot;
using spots.Models.Spot.Interfaces;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;
using spots.Modules.Timeline;
using spots.Modules.Timeline.Interfaces;
using spots.Modules.Timeline.ViewModels;
using spots.Services.EmailService;
using spots.Services.EmailService.Interfaces;

namespace spots
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            //container.LoadConfiguration();

            //Identity
            container.RegisterType<AccountController>(new InjectionConstructor(
               typeof(IAccountFacade), typeof(IAccount), typeof(ISpotUser), typeof(IEmailService)));

            container.RegisterType<ManageController>(new InjectionConstructor());

            //Models
            container.RegisterType<IAccount, AccountViewModel>();
            container.RegisterType<IRegister, RegisterViewModel>();
            container.RegisterType<ILogin, LoginViewModel>();

            container.RegisterType<ISpotUser, SpotUser>();
            container.RegisterType<IUserResponse, UserResponse>();
            container.RegisterType<IUserBusiness, UserBusiness>();
            container.RegisterType<IUserEvent, UserEvent>();

            container.RegisterType<IBusiness, Business>();
            container.RegisterType<IBusinessResponse, BusinessResponse>();
            container.RegisterType<ICreateBusiness, CreateBusinessViewModel>();
            container.RegisterType<ILocationResponse, LocationResponse>();
            container.RegisterType<ISpotResponse, SpotResponse>();

            container.RegisterType<ILocation, Location>();
            container.RegisterType<ISpot, Spot>();

            container.RegisterType<IEvent, Event>();
            container.RegisterType<IEventResponse, EventResponse>();
            container.RegisterType<IEventDetails, EventDetailsViewModel>();

            container.RegisterType<IGroup, Group>();
            container.RegisterType<IGroupResponse, GroupResponse>();

            container.RegisterType<IDelete, DeleteViewModel>();

            container.RegisterType<IFeedback, Feedback>();
            container.RegisterType<IFeedbackResponse, FeedbackResponse>();

            container.RegisterType<ILog, Log>();
            container.RegisterType<IExceptionLog, ExceptionLog>();


            //facades
            container.RegisterType<ICalendarFacade, CalendarFacade>();
            container.RegisterType<IBusinessFacade, BusinessFacade>();
            container.RegisterType<IGroupFacade, GroupFacade>();
            container.RegisterType<IAccountFacade, AccountFacade>();
            container.RegisterType<IUserFacade, UserFacade>();
            container.RegisterType<IFeedbackFacade, FeedbackFacade>();
            container.RegisterType<ILogFacade, LogFacade>();
            container.RegisterType<IEventFacade, EventFacade>();
            container.RegisterType<ISpotFacade, SpotFacade>();
            container.RegisterType<ILocationFacade, LocationFacade>();
            container.RegisterType<IMapFacade, MapFacade>();
            container.RegisterType<IExceptionLogFacade, ExceptionLogFacade>();

            //db context
            container.RegisterType<IMongoContext, MongoContext>();
            container.RegisterType<IMongoContextGeneric<SpotUser>, MongoContextGeneric<SpotUser>>();
            container.RegisterType<IMongoContextGeneric<Business>, MongoContextGeneric<Business>>();
            container.RegisterType<IMongoContextGeneric<Location>, MongoContextGeneric<Location>>();
            container.RegisterType<IMongoContextGeneric<Spot>, MongoContextGeneric<Spot>>();
            container.RegisterType<IMongoContextGeneric<Event>, MongoContextGeneric<Event>>();
            container.RegisterType<IMongoContextGeneric<Group>, MongoContextGeneric<Group>>();
            container.RegisterType<IMongoContextGeneric<Feedback>, MongoContextGeneric<Feedback>>();
            container.RegisterType<IMongoContextGeneric<Log>, MongoContextGeneric<Log>>();
            container.RegisterType<IMongoContextGeneric<ExceptionLog>,
                MongoContextGeneric<ExceptionLog>>();

            

            container.RegisterType<IAtomicBusinessWork, AtomicBusinessWork>();
            container.RegisterType<IAtomicLocationWork, AtomicLocationWork>();
            container.RegisterType<IAtomicSpotWork, AtomicSpotWork>();
            container.RegisterType<IAtomicUserWork, AtomicUserWork>();
            container.RegisterType<IAtomicEventWork, AtomicEventWork>();
            container.RegisterType<IAtomicGroupWork, AtomicGroupWork>();
            container.RegisterType<IAtomicTimelineWork, AtomicTimelineWork>();

            //repository 
            container.RegisterType<ISpotUserRepository, SpotUserRepository>();
            container.RegisterType<IGroupRepository, GroupRepository>();
            container.RegisterType<IBusinessRepository, BusinessRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ISpotRepository, SpotRepository>();
            container.RegisterType<IEventRepository, EventRepository>();


            //Modules
            container.RegisterType<ITimeline, Timeline>();
            container.RegisterType<ITimelineEvent, TimelineEventViewModel>();

            //serices
            container.RegisterType<IEmailService, Services.EmailService.EmailService>();
            container.RegisterType<ITemplate, Template>();

            //Core
            container.RegisterType<IEventCore, EventCore>();
            container.RegisterType<ISpotCore, SpotCore>();
            container.RegisterType<ILocationCore, LocationCore>();
            container.RegisterType<IMapCore, MapCore>();
        }
    }
}
