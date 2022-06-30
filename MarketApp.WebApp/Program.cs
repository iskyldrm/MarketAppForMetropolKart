using MarketApp.BL.Abstract;
using MarketApp.BL.Concrete;
using MarketApp.WebApp.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ITaxManager, TaxManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ISupplierManager, SupplierManager>();
builder.Services.AddScoped<ICatagoryManager, CategoryManager>();
builder.Services.AddScoped<ITaxManager, TaxManager>();
builder.Services.AddAutoMapper(typeof(ProductMap));

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

app.Run();
