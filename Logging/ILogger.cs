using System.ComponentModel.Composition;

namespace Logging
{
    [InheritedExport(typeof(ILogger))]
    public interface ILogger
    {
        void Log(string message);
    }
}
