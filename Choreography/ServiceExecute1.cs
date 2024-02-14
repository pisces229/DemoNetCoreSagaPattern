using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class ServiceExecute1 : Service, IService
    {
        public void Run(SagaModel current)
        {
            var result = Interactive(current);
            if (result)
            {
                var next = sagaInstance.SagaRepository.Create(current.SagaId, SagaService.ServiceExecute2);
                sagaInstance.SagaQueue.Next(next);
            }
            else
            {
                sagaInstance.SagaQueue.End();
            }
        }
    }
}
