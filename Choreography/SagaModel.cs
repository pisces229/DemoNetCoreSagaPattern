using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class SagaModel
    {
        public Guid SagaId { get; set; }
        public Guid TransactionId { get; set; }
        public SagaService Service { get; set; }
        public SagaStatus Status { get; set; }    
    }
}
