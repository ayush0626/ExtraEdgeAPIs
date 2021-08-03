using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge.Database.Exceptions.Interfaces
{
    public interface IExceptionRepository : IDisposable
    {
        void LogException(Exception ex, ControllerContext controllerContext);
        void LogException(NullReferenceException ex, ControllerContext controllerContext);
    }
}
