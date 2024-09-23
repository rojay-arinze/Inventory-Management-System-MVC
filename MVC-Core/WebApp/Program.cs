using Microsoft.Extensions.DependencyInjection.Extensions;
using Plugins.DataStore.InMemory;
using UseCasesLayer.CategoriesUseCases;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;
using UseCasesLayer.Interfaces.TransactionsUseCaseInterfaces;
using UseCasesLayer.ProductsUseCases;
using UseCasesLayer.TransactionsUseCases;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);
/*
#4 Inject the service needed by the MapControllerRoute method to function properly. This has to be done before the var app = builder.Build()*/
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
builder.Services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();
builder.Services.AddSingleton<ITransactionsRepository, TransactionsInMemoryRepository>();
////Categories

builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
//Products
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryIdUseCase, ViewProductsByCategoryIdUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

//Transactions
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();


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
