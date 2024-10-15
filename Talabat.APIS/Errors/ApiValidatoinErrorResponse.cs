namespace Talabat.APIS.Errors
{
	public class ApiValidatoinErrorResponse : ApiResponse
	{
        public IEnumerable<string> Errors { get; set; }

        public ApiValidatoinErrorResponse() : base(400)
        {
            Errors = new List<string>();
        }
    }
}
