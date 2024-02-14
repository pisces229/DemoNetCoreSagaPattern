using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    public class Saga
    {
        protected SagaContext Context { get; set; }
        public Saga()
        {
            Context = new SagaContext
            {
                SagaId = new Guid(),
                Status = SagaStatus.NotStarted,
                Activities = new List<IActivity>()
            };
        }
        public IList<IActivity> GetActivities()
        {
            return Context.Activities!;
        }
        public SagaStatus Status
        {
            get => Context.Status;
        }
        public int CurrentActivity
        {
            get => Context.CurrentActivity;
        }
        private async Task<ActivityStatus> ExecutingActivities(CancellationToken cancellationToken)
        {
            var activityStatus = ActivityStatus.Failed;
            for (Context.CurrentActivity = 0; Context.CurrentActivity < Context.Activities!.Count; Context.CurrentActivity++)
            {
                Context.LastActivity = Context.CurrentActivity;
                var activity = Context.Activities[Context.CurrentActivity];
                try
                {
                    activityStatus = await activity.ExecuteAsync();
                }
                catch
                {
                    activityStatus = ActivityStatus.Failed;
                }
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                if (activityStatus == ActivityStatus.Failed)
                {
                    break;
                }
            }
            return activityStatus;
        }
        private async Task<ActivityStatus> CompensatingActivities()
        {
            var activityStatus = ActivityStatus.Succeeded;
            Context.CurrentActivity--;
            Context.Status = SagaStatus.Failed;
            for (; Context.CurrentActivity >= 0; Context.CurrentActivity--)
            {
                var activity = Context.Activities![Context.CurrentActivity];
                try
                {
                    if (await activity.CompensateAsync() != ActivityStatus.Succeeded)
                    {
                        activityStatus = ActivityStatus.Failed;
                    }
                }
                catch
                {
                    activityStatus = ActivityStatus.Failed;
                }
            }
            return activityStatus;
        }
        public async Task<SagaStatus> Run(CancellationToken cancellationToken)
        {
            if (Context.Activities!.Count == 0)
            {
                return Context.Status;
            }
            Context.Status = SagaStatus.Running;
            var activityStatus = await ExecutingActivities(cancellationToken);
            if (activityStatus == ActivityStatus.Succeeded)
            {
                Context.Status = SagaStatus.Succeeded;
                return Context.Status;
            }
            if (Context.CurrentActivity == 0)
            {
                Context.Status = SagaStatus.Failed;
                return Context.Status;
            }
            activityStatus = await CompensatingActivities();
            if (activityStatus == ActivityStatus.Failed)
            {
                Context.Status = SagaStatus.UnexpectedError;
            }
            return Context.Status;
        }
    }
}
