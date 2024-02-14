using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class Activity2 : InteractiveActivity, IActivity
    {
        public Task<ActivityStatus> ExecuteAsync() => Task.FromResult(InteractiveExecute("Two"));
        public Task<ActivityStatus> CompensateAsync() => Task.FromResult(InteractiveCompensate("Two"));
    }
}
