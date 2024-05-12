using SeinfeldApi.Persistence;
using SeinfeldApi.Application;
using SeinfeldApi.Mapper;
using SeinfeldApi.Application.Exceptions;
using SeinfeldApi.Infrastructure;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var env = builder.Environment;//DEVELOPMENT VEYA PRODUCTÝON ALMAMI SAÐLAYACAK
builder.Configuration
	.SetBasePath(env.ContentRootPath)
	.AddJsonFile("appsettings.json",optional:false)
	.AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:false);

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddInFrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Seinfeld API", Version = "V1", Description = "Seinfeld API swagger client" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "'Bearer'yazýp boþluk býraktýktan sonra Token'ý girebilirsiniz \r\n\r\n örneðin: \"Bearer 3v9HwDXu8PlanJ2SkNEeMpYHpKD6NG\""
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			Array.Empty<string>()
		}
	});
});
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
