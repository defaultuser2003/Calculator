using System;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace Logging
{
    [Export(typeof(ILogger))]
    public class LogDbContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    public class EfLogger : ILogger
    {
        private LogDbContext dbContext;

        public EfLogger(LogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Log(string message)
        {
            Log log = new Log { Message = message, Date = DateTime.Now };
            dbContext.Logs.Add(log);
            dbContext.SaveChanges();
        }
    }
}
