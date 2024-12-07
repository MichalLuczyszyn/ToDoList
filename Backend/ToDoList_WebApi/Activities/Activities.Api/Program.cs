using Shared.ValueObjects.Location;
using Shared.ValueObjects.Name;

using ToDoList.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new NameJsonConverter());
        options.JsonSerializerOptions.Converters.Add(new LocationJsonConverter());
    });
ApplicationConfiguration.DependencyInjection.AddApplication(builder.Services);
ApplicationConfiguration.DependencyInjection.AddInfrastructure(builder.Services, builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();