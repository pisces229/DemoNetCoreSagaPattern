using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public enum SagaStatus
    {
        Wait,
        Process,
        None,
        Success,
        Fail,
    }
}
