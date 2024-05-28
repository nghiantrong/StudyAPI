using ContentNegotiation;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
	//options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
	options.ReturnHttpNotAcceptable = true;
	options.OutputFormatters.Add(new VcardOutputFormatter());
}).AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
	//.AddXmlSerializerFormatters();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<CustomNotAcceptableMiddleware>();

app.Run();
