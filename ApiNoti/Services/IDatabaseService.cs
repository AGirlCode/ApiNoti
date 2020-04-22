using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoti.Services
{
    public interface IDatabaseService
    {
        long GetCountUnreadNotiSent(string clientCode, string appName);

    }
}
