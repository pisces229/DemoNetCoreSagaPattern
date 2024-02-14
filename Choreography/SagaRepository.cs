using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Choreography
{
    public class SagaRepository
    {
        private readonly List<SagaModel> _datas = [];
        public SagaModel Create(Guid sagaId, SagaService service)
        {
            var data = new SagaModel()
            {
                SagaId = sagaId,
                TransactionId = Guid.NewGuid(),
                Service = service,
                Status = SagaStatus.Wait,
            };
            _datas.Add(data);
            return data;
        }
        public void Process(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Process;
        public void Success(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Success;
        public void Fail(Guid transactionId) => _datas.Where(p => p.TransactionId == transactionId).Single().Status = SagaStatus.Fail;
        public void Print() => _datas.ForEach(f => Console.WriteLine($"{f.Service} : {f.Status}"));
    }
}
