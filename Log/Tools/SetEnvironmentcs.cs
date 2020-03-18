using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Log.Tools
{
    public static class SetEnvironmentcs
    {
        // TODO: 
        // 1. Check the folder for access right. 
        // 2. Have a list of possible locations to save the log to.
        // 3. Try to create the log file folder and the text logfile.
        // 4. Get the path location of where the log ends up being created.
        
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

            //bool[] TestResults = new bool[2] { false, false};
            pCheckWriteMethod fPointerMyDocuments = new pCheckWriteMethod(CheckWritePermissionMyDocuments);
            pCheckWriteMethod fPointerApplicationData = new pCheckWriteMethod(CheckWritePermssionApplicationData);
            //Console.WriteLine(FileSaveLocations[0]);
            

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
