var builder = WebApplication.CreateBuilder(args);

//Add service
var app = builder.Build();

//configure prebuilt

app.Run();

//configure post built
