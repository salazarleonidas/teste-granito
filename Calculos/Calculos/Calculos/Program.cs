using Domain.Shared.AutoMapper;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

IoC.Boostrap.Inicializar(builder.Services);

builder.Services.AddAutoMapper(c => AutoMapperConfig.RegisterMappings());

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization(op =>
{
    var cultureInfo = new CultureInfo("pt-BR");
    op.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(cultureInfo);
    op.SupportedCultures = new List<CultureInfo> { cultureInfo };
    op.SupportedUICultures = new List<CultureInfo> { cultureInfo };
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
