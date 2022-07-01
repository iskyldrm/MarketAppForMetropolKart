using AutoMapper;
using MarketApp.API.AutoMapper;
using MarketApp.API.Extensions;
using MarketApp.BL.Abstract;
using MarketApp.BL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// MarketExtension eklendi
builder.Services.AddMarketManagerService();


builder.Services.AddEndpointsApiExplorer();

//API METODTLARININ APP PROJESÝ OLAMADAN KULLANILMASI ÝÇÝN AÇIK BIRAKTIM.
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
