using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetCoreSagaPattern
{
    public enum SagaStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnexpectedError
    }
}
