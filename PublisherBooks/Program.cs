using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using PublisherBooks.Extensions;

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(configuration => configuration.AddMaps(typeof(Program).Assembly));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PublisherBooks.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
