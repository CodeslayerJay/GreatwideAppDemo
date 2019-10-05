using System;
using System.Collections.Generic;
using System.Text;

namespace GreatwideApp.Domain.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogMessage(string message = null, int level = 0, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
