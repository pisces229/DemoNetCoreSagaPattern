using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class Service
    {
        protected readonly SagaInstance sagaInstance = SagaInstance.GetSagaInstance();
        public void Interactive(SagaModel sagaModel)
        {
            if (sagaModel.CompensateStep == 0)
            {
                if (sagaModel.Step == 1 || sagaInstance.SagaRepository.IsExecuteSuccess(sagaModel.Step - 1))
                {
                    Do(sagaModel);
                }
                else
                {
                    sagaInstance.SagaRepository.None(sagaModel.TransactionId);
                }
            }
            else
            {
                if (sagaInstance.SagaRepository.IsExecuteFail())
                {
                    if (sagaInstance.SagaRepository.IsExecuteSuccess(sagaModel.CompensateStep))
                    {
                        Do(sagaModel);
                    }
                    else
                    {
                        sagaInstance.SagaRepository.None(sagaModel.TransactionId);
                    }
                }
                else
                {
                    sagaInstance.SagaRepository.None(sagaModel.TransactionId);
                }
            }
        }
        private void Do(SagaModel sagaModel)
        {
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
        }
    }
}
