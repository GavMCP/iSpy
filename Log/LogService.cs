using System;
using System.IO;

namespace Log
{
    public static class LogService
    {
        /// <summary>
        /// Get the logfile save location saved in the settings file.
        /// </summary>
        public static string LogPath { get; } = Settings1.Default.SavedLogLocation;

       
        /// <summary>
        /// Append text to the log. If the log does not exist, then create it.
        /// </summary>
        /// <param name="logLocation"></param>
        /// <param name="value"></param>
        public static void WriteToLog(string logLocation, string value)
        {
            try
            {
                using (StreamWriter swLog = new StreamWriter(logLocation, append: true))
                {
                    swLog.WriteLineAsync(DateTime.Now + ": " + value);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"In LogService. Could not write to log at {logLocation} Reason:{ex.Message}");
#endif
            }
        }
    }
}
