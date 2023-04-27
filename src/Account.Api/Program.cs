using Account.ApplicationServices;
using Account.Domain;
using Account.Infrastructure.Sql;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Text.Json.Serialization;
using System.Text.Json;
using Shared.AspNetCore.Mvc.Abstractions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(config =>
        {
            config.Filters.Add(typeof(ExceptionFilter));
        })
        .AddJsonOptions(ops =>
        {
            ops.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            ops.JsonSerializerOptions.WriteIndented = true;
            ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AccountQuery>());

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IAccountReader, AccountReader>();
        builder.Services.AddScoped<IAccountWriter, AccountWriter>();

        builder.Services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                            new HeaderApiVersionReader("x-api-version"),
                                                            new MediaTypeApiVersionReader("x-api-version"));
        });


        var app = builder.Build();

        if (!app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}