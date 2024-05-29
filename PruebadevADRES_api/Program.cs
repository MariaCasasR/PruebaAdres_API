using PruebadevADRES_api.Clases;
using PruebadevADRES_api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var cn = new DAO();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/GetUnidades", () => {
    return cn.GetUnidades();
});
app.MapGet("/GetProveedors", () => {
    return cn.GetProveedors();
});
app.MapGet("/GetRequerimientosMed", () => {
    return cn.GetRequerimientosMed();
});
//post
app.MapPost("/PostUnidades", (Unidad data) => {
    return cn.PostUnidades(data);
});
app.MapPost("/PostProvedores", (Proveedor data) => {
    return cn.PostProvedores(data);
});
app.MapPost("/PostRequerimientosMed", (RequerimientosMed data) =>
{
    return cn.PostRequerimientosMed(data);
});
//edit 
app.MapPut("/EditUnidades", (Unidad data) =>
{
    return cn.EditUnidades(data);
});
app.MapPut("/EditProveedor", (Proveedor data) =>
{
    return cn.EditProveedor(data);
});
app.MapPut("/EditRequerimientosMed", (RequerimientosMed data) =>
{
    return cn.EditRequerimientosMed(data);
});
//delete
app.MapPost("/DltUnidad", (Unidad data) =>
{
    return cn.DltUnidad(data);
});
app.MapPost("/DltProveedor", (Proveedor data) =>
{
    return cn.DltProveedor(data);
});
app.MapPost("/DltRequerimiento", (RequerimientosMed data) =>
{
    return cn.DltRequerimiento(data);
});
app.Run();
