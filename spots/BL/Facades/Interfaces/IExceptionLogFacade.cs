using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spots.BL.Facades.Interfaces
{
    public interface IExceptionLogFacade
    {
        void StoreException(Exception exception);
    }
}
