namespace PatientTracking.Core.Results
{
    public class Result
    {
        public Result(bool success)
        {
            Success = success;
            Message = "";
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
