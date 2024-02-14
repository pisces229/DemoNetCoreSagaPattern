using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Orchestration
{
    public class SagaRepository
    {
        private readonly List<SagaModel> _datas = [];
        public SagaModel Create(Guid sagaId, int step, SagaService service, int compensateStep)
        {
            var data = new SagaModel()
            {
                SagaId = sagaId,
                TransactionId = Guid.NewGuid(),
                Step = step,
                Service = service,
                CompensateStep = compensateStep,
                Status = SagaStatus.Wait,
            };
            _datas.Add(data);
            return data;
        }
        public bool IsExecuteSuccess(int step) => _datas.Any(p => p.Step == step && p.CompensateStep == 0 && p.Status == SagaStatus.Success);
        public bool IsExecuteFail() => _datas.Any(p => p.CompensateStep == 0 && p.Status == SagaStatus.Fail);
        public void Process(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Process;
        public void None(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.None;
        public void Success(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Success;
        public void Fail(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Fail;
        public void Print() => _datas.ForEach(f => Console.WriteLine($"{f.Service} : {f.Status}"));
    }
}
