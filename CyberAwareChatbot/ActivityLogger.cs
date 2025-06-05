using System;
using System.Collections.Generic;

namespace CyberAwareChatbot
{
    public class ActivityLogger
    {
        private readonly List<string> logs = new List<string>();

        public void LogAction(string action)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {action}";
            logs.Add(logEntry);
        }

        public List<string> GetLogs()
        {
            return new List<string>(logs); // Return a copy to prevent external modification
        }
    }
}