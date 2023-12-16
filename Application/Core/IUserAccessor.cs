using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IUserAccessor
    {
        string GetEmail();
    }
}