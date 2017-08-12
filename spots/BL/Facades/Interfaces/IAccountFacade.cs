using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Account.Interfaces;
using spots.Models.Account.Viewmodels;

namespace spots.BL.Facades.Interfaces
{
    public interface IAccountFacade
    {
        void Register(RegisterViewModel viewModel);
    }
}
