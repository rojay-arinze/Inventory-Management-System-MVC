var builder = WebApplication.CreateBuilder(args);
/*
#4 Inject the service needed by the MapControllerRoute method to function properly. This has to be done before the var app = builder.Build()*/
builder.Services.AddControllersWithViews();
var app = builder.Build();

//Add middleware to allow for the use of static files like .css / .js files
app.UseStaticFiles();

//#1 add routing middleware so that the app can handle routes
app.UseRouting();

/*
#2 add a default url pattern so that the controller can map a particular request to an action method. 
controller=Home: If no controller is specified, it maps to the Home controller
action=Index: if no action is specified, it maps to the index action*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
