using SeinfeldApi.Persistence;
using SeinfeldApi.Application;
using SeinfeldApi.Mapper;
using SeinfeldApi.Application.Exceptions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;//DEVELOPMENT VEYA PRODUCTÝON ALMAMI SAÐLAYACAK
builder.Configuration
	.SetBasePath(env.ContentRootPath)
	.AddJsonFile("appsettings.json",optional:false)
	.AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:false);

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.ConfigureExceptionMiddleware(); //runtime ile entegre edildi.

app.UseAuthorization();

app.MapControllers();

app.Run();
