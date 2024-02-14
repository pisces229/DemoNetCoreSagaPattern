using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public enum SagaStatus
    {
        Wait,
        Process,
        Success,
        Fail,
    }
}
