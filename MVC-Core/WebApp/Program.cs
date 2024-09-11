var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//#1 add routing middleware so that the app can handle routes
app.UseRouting();

app.Run();
