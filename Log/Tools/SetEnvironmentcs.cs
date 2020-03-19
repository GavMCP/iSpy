using System;
using System.Collections.Generic;
using System.IO;

namespace Log.Tools
{
    public static class SetEnvironmentcs
    {
                
        // List of True/False for each of the Directories checked for Write Access.
        public static List<bool> ListOfRules;
                
        /// <summary>
        /// Delegate that points to each of the Access Tests.
        /// </summary>
        /// <returns></returns>
        public delegate bool pCheckWriteMethod();

                      
        // Array of possible folder save locations.
        private static string[] FileSaveLocations = new string[4];
        static SetEnvironmentcs()
        {
            FileSaveLocations[0] = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FileSaveLocations[1] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            FileSaveLocations[2] = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            FileSaveLocations[3] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        
            // Files in save folders.
        }
                                   
        
        /// <summary>
        /// Check for Write permission for the user to ApplicationData and MyDocuments directories.
        /// </summary>
        /// <returns>True if all elements in TestResults are also, true</returns>
        public static bool CheckAllRules()
        {
            Dictionary<string, bool> testResults = new Dictionary<string, bool>();
                       
            pCheckWriteMethod fPointerMyDocuments = new pCheckWriteMethod(CheckWritePermissionMyDocuments);
            pCheckWriteMethod fPointerApplicationData = new pCheckWriteMethod(CheckWritePermssionApplicationData);
          
            // Check and set the access right foreach folder location. 
            if(fPointerMyDocuments())
            {
                testResults.Add(FileSaveLocations[1], true);
            }
            else
            {
                testResults.Add(FileSaveLocations[1], false);
            }
            
            if(fPointerApplicationData())
            {
                testResults.Add(FileSaveLocations[0], true);
            }
            else
            {
                testResults.Add(FileSaveLocations[0], false);
            }
           
            // Save to settings the first folder location that has true access rights.
            foreach(KeyValuePair<string, bool> check in testResults)
            {
               if(check.Value)
                {
#if DEBUG
                    Console.WriteLine($"Creating log in {check.Key}");
#endif         
                    Settings1.Default.SavedLogLocation = check.Key + "\\NewLogFileTEST.txt";
                    Settings1.Default.Save();
                                      
                    return true;
                }
            }
            return false;
        }

        
        /// <summary>
        /// Creates a FileSecurity object which encapulates the ACL (Access Control List) for local MyDocuments directory. 
        /// </summary>
        /// <returns>l.</returns>
        private static bool CheckWritePermissionMyDocuments()
        {
            try
            {
                File.GetAccessControl(FileSaveLocations[1]);
                return true;
            }
            catch(UnauthorizedAccessException)
            {
                return false;
            }
        }

        private static bool CheckWritePermssionApplicationData()
        {
            try
            {
                File.GetAccessControl(FileSaveLocations[1]);
                return true;
            }
            catch(UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
