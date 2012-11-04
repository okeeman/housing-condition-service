
namespace HousingConditionWebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the HouseConditionEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class HouseConditionDomainService : LinqToEntitiesDomainService<HouseConditionEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Houses' query.
        public IQueryable<House> GetHouses()
        {
            return this.ObjectContext.Houses;
        }

        public void InsertHouse(House house)
        {
            if ((house.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(house, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Houses.AddObject(house);
            }
        }

        public void UpdateHouse(House currentHouse)
        {
            this.ObjectContext.Houses.AttachAsModified(currentHouse, this.ChangeSet.GetOriginal(currentHouse));
        }

        public void DeleteHouse(House house)
        {
            if ((house.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(house, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Houses.Attach(house);
                this.ObjectContext.Houses.DeleteObject(house);
            }
        }
    }
}


