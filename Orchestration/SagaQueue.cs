using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class SagaQueue
    {
        private readonly Queue<SagaModel> queue = new();
        public void Add(SagaModel item)
        {
            queue.Enqueue(item);
        }
        public void Run()
        {
            SagaCoordinator.Create();
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                GetService(current.Service).Run(current);
            }
            Console.WriteLine();
            SagaInstance.GetSagaInstance().SagaRepository.Print();
        }
        private IService GetService(SagaService service) 
        {
            switch (service)
            {
                case SagaService.ServiceExecute1:
                    return new ServiceExecute1();
                case SagaService.ServiceExecute2:
                    return new ServiceExecute2();
                case SagaService.ServiceExecute3:
                    return new ServiceExecute3();
                case SagaService.ServiceCompensate1:
                    return new ServiceCompensate1();
                case SagaService.ServiceCompensate2:
                    return new ServiceCompensate2();
                case SagaService.ServiceCompensate3:
                    return new ServiceCompensate3();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
