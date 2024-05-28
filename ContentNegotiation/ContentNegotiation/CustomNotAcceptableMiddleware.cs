using System.Text.Json;

namespace ContentNegotiation
{
	public class CustomNotAcceptableMiddleware
	{
		private readonly RequestDelegate _next;
		public CustomNotAcceptableMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task Invoke(HttpContext context)
		{
			await _next(context);
			if (context.Response.StatusCode == StatusCodes.Status406NotAcceptable)
			{
				// Retrieve the Accept header from the request
				var acceptHeader = context.Request.Headers["Accept"].ToString();
				// Custom response logic here
				context.Response.ContentType = "application/json";
				var response = new
				{
					Code = StatusCodes.Status406NotAcceptable,
					ErrorMessage = $"The Requested Format {acceptHeader} is Not Supported."
				};
				await context.Response.WriteAsync(JsonSerializer.Serialize(response));
			}
		}
	}
}
