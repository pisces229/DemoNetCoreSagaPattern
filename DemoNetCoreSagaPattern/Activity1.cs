using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetCoreSagaPattern
{
    public class Activity1 : InteractiveActivity, IActivity
    {
        public Task<ActivityStatus> ExecuteAsync() => Task.FromResult(InteractiveExecute("One"));
        public Task<ActivityStatus> CompensateAsync() => Task.FromResult(InteractiveCompensate("One"));
    }
}
