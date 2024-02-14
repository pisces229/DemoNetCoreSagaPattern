using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class ServiceCompensate2 : Service, IService
    {
        public void Run(SagaModel current)
        {
            Interactive(current);
        }
    }
}
