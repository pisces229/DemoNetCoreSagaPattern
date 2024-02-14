
Console.WriteLine("Saga Choreography...");

await Choreography.SagaInstance.GetSagaInstance().SagaQueue.Start();
