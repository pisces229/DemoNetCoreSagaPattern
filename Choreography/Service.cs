using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class Service
    {
        protected readonly SagaInstance sagaInstance = SagaInstance.GetSagaInstance();
        public bool Interactive(SagaModel sagaModel)
        {
            var result = false;
            sagaInstance.SagaRepository.Process(sagaModel.TransactionId);
            Console.WriteLine();
            Console.Write($"Interactive {sagaModel.Service} Status (Y=Success, N=Fail)? ");
            if ("Y".Equals(Console.ReadLine()?.Trim().ToUpper()))
            {
                sagaInstance.SagaRepository.Success(sagaModel.TransactionId);
            }
            else
            {
                sagaInstance.SagaRepository.Fail(sagaModel.TransactionId);
            }
            return result;
        }
    }
}
