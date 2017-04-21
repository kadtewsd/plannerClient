namespace PlannerClient.Model
{
    public class RequestResultModel
    {

        public bool IsSuccess { get; set; }

        public string StatusCode { get; set; }

        public string StackTrace { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExtraMessage { get; set; }

        public bool HasExecuted { get; set; }
    }
}
