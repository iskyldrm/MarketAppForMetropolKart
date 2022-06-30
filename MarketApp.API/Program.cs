using AutoMapper;
using MarketApp.API.AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.BL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITaxManager, TaxManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ISupplierManager, SupplierManager>();
builder.Services.AddScoped<ICatagoryManager, CategoryManager>();
builder.Services.AddScoped<ITaxManager, TaxManager>();
builder.Services.AddAutoMapper(typeof(ProductMapping));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
