using ModelsV4.DAOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;
using Repositories.Repoository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ShipperViewFormat>();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<RouteViewFormat>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddTransient<IWarehouseManagerRepository, WarehouseManagerRepository>();
builder.Services.AddSingleton<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddSingleton<IBirdRepository, BirdRepository>();
builder.Services.AddSingleton<IShipperRepository,ShipperRepository>();
builder.Services.AddSingleton<IOrderRepository,OrderRepository>();
builder.Services.AddSingleton<BirdTransportationSystemContext, BirdTransportationSystemContext>();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseSession();
app.Run();