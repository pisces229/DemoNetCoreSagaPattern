using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class ServiceExecute2 : Service, IService
    {
        public void Run(SagaModel current)
        {
            var result = Interactive(current);
            if (result)
            {
                var next = sagaInstance.SagaRepository.Create(current.SagaId, SagaService.ServiceExecute3);
                sagaInstance.SagaQueue.Next(next);
            }
            else
            {
                var next = sagaInstance.SagaRepository.Create(current.SagaId, SagaService.ServiceCompensate1);
                sagaInstance.SagaQueue.Next(next);
            }
        }
    }
}
