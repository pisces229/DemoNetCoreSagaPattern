using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class ServiceCompensate2 : Service, IService
    {
        public void Run(SagaModel current)
        {
            Interactive(current);
            var next = sagaInstance.SagaRepository.Create(current.SagaId, SagaService.ServiceCompensate1);
            sagaInstance.SagaQueue.Next(next);
        }
    }
}
