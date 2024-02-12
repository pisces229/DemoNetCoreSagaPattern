using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetCoreSagaPattern
{
    public class InteractiveActivity
    {
        public ActivityStatus InteractiveExecute(string activityName)
        {
            var status = ActivityStatus.Failed;
            Console.WriteLine($"\nActivity {activityName} executing ...");
            Console.Write("Enter Return Status (Y=Succeeded, N=Failed)? ");
            var reply = Console.ReadLine();
            if (reply != null)
            {
                reply = reply.Trim().ToUpper();
                if (reply == "y" || reply == "yes")
                {
                    status = ActivityStatus.Succeeded;
                }
            }
            if (status == ActivityStatus.Succeeded)
            {
                Console.WriteLine($"Activity {activityName} Execution Succeeded.");
            }
            else
            {
                Console.WriteLine($"Activity {activityName} Execution Failed!");
            }
            return status;
        }
        public ActivityStatus InteractiveCompensate(string activityName)
        {
            var status = ActivityStatus.Failed;
            Console.WriteLine($"\nActivity {activityName} compensating ...");
            Console.Write("Enter Return Status (Y=Succeeded, N=Failed)? ");
            var reply = Console.ReadLine();
            if (reply != null)
            {
                reply = reply.Trim().ToUpper();
                if (reply == "y" || reply == "yes")
                {
                    status = ActivityStatus.Succeeded;
                }
            }
            if (status == ActivityStatus.Succeeded)
            {
                Console.WriteLine($"Activity {activityName} Compensation Succeeded.");
            }
            else
            {
                Console.WriteLine($"Activity {activityName} Compensation Failed!");
            }
            return status;
        }
    }
}
