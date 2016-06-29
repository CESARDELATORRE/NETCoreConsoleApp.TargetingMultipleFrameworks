using System;

#if NET452
using System.Diagnostics; 
#endif

namespace NetCoreConsole.MultipleFXs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Howdy!");
            Console.WriteLine("This line is executed no matter what framework I'm running my Core app on");

#if NET452
            // Access something that requires the traditional .NET Framework, like some Windows related stuff
            
            // Writing to the Windows EventLog
            // NOTE: Writing to the Windows EventLog might need ADMIN PRIVILEGES!!
            string sSource = "My .NET Core Console App";
            string sLog = "Application";
            string sEvent = "My sample Event when running on the .NET Framework";

            if (!EventLog.SourceExists(sSource))
	            EventLog.CreateEventSource(sSource,sLog);

            EventLog.WriteEntry(sSource,sEvent);
            EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Warning,  234);
            Console.WriteLine("EventLog code was executed because it was running on top of .NET Framework 4.5.2");
#endif
            Console.ReadKey();
        }
    }
}
