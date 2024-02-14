using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class ServiceExecute3 : Service, IService
    {
        public void Run(SagaModel current)
        {
            var result = Interactive(current);
            if (result)
            {
                sagaInstance.SagaQueue.End();
            }
            else
            {
                var next = sagaInstance.SagaRepository.Create(current.SagaId, SagaService.ServiceCompensate2);
                sagaInstance.SagaQueue.Next(next);
            }
        }
    }
}
