using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetCoreSagaPattern
{
    public interface IActivity
    {
        Task<ActivityStatus> ExecuteAsync();
        Task<ActivityStatus> CompensateAsync();
    }
}
