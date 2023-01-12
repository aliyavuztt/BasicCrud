using AutoMapper;
using BasicCrud.Business.AutoMapper.Profiles;
using BasicCrud.Business.DependencyResolvers;
using BasicCrud.Business.ValidationRules.FluentValidation;
using BasicCrud.Entities.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddFluentValidation(x =>
    {
        x.ImplicitlyValidateChildProperties = true;
    });

builder.Services.AddTransient<IValidator<ProductAddDto>, ProductAddValidator>();
builder.Services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateValidator>();

builder.Services.LoadMyServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200"));
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();