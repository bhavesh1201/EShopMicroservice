var builder = WebApplication.CreateBuilder(args);

//Add Service Container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
var app = builder.Build();


//Configure HTTP request Pipeline

app.MapCarter();

app.Run();
