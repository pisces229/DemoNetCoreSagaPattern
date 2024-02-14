using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class SagaQueue
    {
        private readonly Queue<SagaModel> queue = new();
        private bool run = true;
        public async Task Start()
        {
            var next = SagaInstance.GetSagaInstance().SagaRepository.Create(Guid.NewGuid(), SagaService.ServiceExecute1);
            Next(next);
            while (run)
            {
                await Task.Delay(1000);
                if (queue.Count != 0)
                {
                    var current = queue.Dequeue();
                    GetService(current.Service).Run(current);
                }
            }
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
        public void Next(SagaModel item)
        {
            queue.Enqueue(item);
        }
        public void End()
        {
            Console.WriteLine();
            SagaInstance.GetSagaInstance().SagaRepository.Print();
            run = false;
        }
    }
}
