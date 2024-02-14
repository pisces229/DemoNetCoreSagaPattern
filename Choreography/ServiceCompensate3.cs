using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class ServiceCompensate3 : Service, IService
    {
        public void Run(SagaModel current)
        {
            // Interactive(current);
            sagaInstance.SagaQueue.End();
        }
    }
}
