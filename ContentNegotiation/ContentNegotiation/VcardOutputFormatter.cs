using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace ContentNegotiation
{
	public class VcardOutputFormatter : TextOutputFormatter
	{
		public VcardOutputFormatter()
		{
			SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

			SupportedEncodings.Add(Encoding.UTF8);
			SupportedEncodings.Add(Encoding.Unicode);
		}

		protected override bool CanWriteType(Type? type)
			=> typeof(Employee).IsAssignableFrom(type)
				|| typeof(IEnumerable<Employee>).IsAssignableFrom(type);

		public override async Task WriteResponseBodyAsync(
			OutputFormatterWriteContext context, Encoding selectedEncoding)
		{
			var httpContext = context.HttpContext;
			var serviceProvider = httpContext.RequestServices;

			var logger = serviceProvider.GetRequiredService<ILogger<VcardOutputFormatter>>();
			var buffer = new StringBuilder();

			if (context.Object is IEnumerable<Employee> employees)
			{
				foreach (var employee in employees)
				{
					FormatVcard(buffer, employee, logger);
				}
			}
			else
			{
				FormatVcard(buffer, (Employee)context.Object!, logger);
			}

			await httpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
		}

		private static void FormatVcard(
			StringBuilder buffer, Employee contact, ILogger logger)
		{
			buffer.AppendLine("BEGIN:VCARD");
			buffer.AppendLine("VERSION:2.1");
			buffer.AppendLine($"N:{contact.LastName};{contact.FirstName}");
			buffer.AppendLine($"FN:{contact.FirstName} {contact.LastName}");
			buffer.AppendLine($"UID:{contact.Id}");
			buffer.AppendLine("END:VCARD");

			logger.LogInformation("Writing {FirstName} {LastName}",
				contact.FirstName, contact.LastName);
		}
	}
}
