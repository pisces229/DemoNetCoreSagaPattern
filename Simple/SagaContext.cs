using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class SagaContext
    {
        public Guid SagaId { get; set; }
        public IList<IActivity>? Activities { get; set; }
        public SagaStatus Status { get; set; }
        public int CurrentActivity { get; set; }
        public int LastActivity { get; set; }
    }
}
