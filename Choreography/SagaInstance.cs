using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    public class SagaInstance
    {
        public readonly SagaQueue SagaQueue;
        public readonly SagaRepository SagaRepository;
        public SagaInstance()
        {
            SagaQueue = new SagaQueue();
            SagaRepository = new SagaRepository();
        }
        private static SagaInstance? _instance;
        public static SagaInstance GetSagaInstance()
        {
            _instance ??= new();
            return _instance;
        }
    }
}
