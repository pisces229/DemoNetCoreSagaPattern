using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class SagaCoordinator
    {
        public static void Create()
        {
            var sagaInstance = SagaInstance.GetSagaInstance();
            sagaInstance.SagaQueue.Add(sagaInstance.SagaRepository.Create(Guid.NewGuid(), 1, SagaService.ServiceExecute1, 0));
            sagaInstance.SagaQueue.Add(sagaInstance.SagaRepository.Create(Guid.NewGuid(), 2, SagaService.ServiceExecute2, 0));
            sagaInstance.SagaQueue.Add(sagaInstance.SagaRepository.Create(Guid.NewGuid(), 3, SagaService.ServiceExecute3, 0));
            sagaInstance.SagaQueue.Add(sagaInstance.SagaRepository.Create(Guid.NewGuid(), 4, SagaService.ServiceCompensate2, 2));
            sagaInstance.SagaQueue.Add(sagaInstance.SagaRepository.Create(Guid.NewGuid(), 5, SagaService.ServiceCompensate1, 1));
        }
    }
}
