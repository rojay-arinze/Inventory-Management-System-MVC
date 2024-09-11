var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//#1 add routing middleware so that the app can handle routes
app.UseRouting();

//#2 add a default url pattern so that the controller can map a particular request to an action method.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
