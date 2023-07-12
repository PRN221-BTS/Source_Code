using ModelsV5.DAOs;
using Repositories.HandleViewFormat;
using Repositories.IRepository;
using Repositories.Repoository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ITrackingOrderRepository, TrackingOrderRepository>();    
builder.Services.AddTransient<WarehouseTrackingFormat>();
builder.Services.AddTransient<OrderTrackingFormat>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddTransient<ShipperViewFormat>();
builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<RouteViewFormat>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddTransient<IWarehouseManagerRepository, WarehouseManagerRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IBirdRepository, BirdRepository>();
builder.Services.AddScoped<IShipperRepository,ShipperRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<BirdTransportationSystemContext, BirdTransportationSystemContext>();
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
