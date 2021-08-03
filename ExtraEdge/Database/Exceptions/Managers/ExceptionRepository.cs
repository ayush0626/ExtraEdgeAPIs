using ExtraEdge.Database.Exceptions.Interfaces;
using ExtraEdge.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraEdge.Database.Exceptions.Managers
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly LogDbContext dbContext;

        public ExceptionRepository(LogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool d)
        {
            if(d)
            {
                if(this.dbContext!=null)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void LogException(Exception ex, ControllerContext controllerContext)
        {
            if(ex!=null && controllerContext!=null)
            {
                LoggingDB log = new LoggingDB
                {
                    Message = ex.InnerException.Message.ToString(),
                    TimeOfLogging = DateTime.UtcNow,
                    Type = ex.GetType().ToString()
                };
                dbContext.loggingDBs.Add(log);
                dbContext.SaveChangesAsync();
            }
        }

        public void LogException(NullReferenceException ex, ControllerContext controllerContext)
        {
            if (ex != null && controllerContext != null)
            {
                LoggingDB log = new LoggingDB
                {
                    Message = ex.InnerException.Message.ToString(),
                    TimeOfLogging = DateTime.UtcNow,
                    Type = ex.GetType().ToString()
                };
                dbContext.loggingDBs.Add(log);
                dbContext.SaveChangesAsync();
            }
        }
    }
}
