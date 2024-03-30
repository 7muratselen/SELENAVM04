using SELENAVM04.Data;
using Serilog;
using Serilog.Sinks.Email;  
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using SELENAVM04.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Serilog.Settings.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SelenavmDbContext>(); // Bu satýrý ekleyin

// E-posta þifresini yapýlandýrma dosyasýndan al
// Serilog yapýlandýrmasýný appsettings.json'dan yükleyin ve e-posta ile log göndermek için ayarlayýn
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Smtp(
        fromEmail: builder.Configuration["Serilog:WriteTo:Args:FromEmail"],
        toEmail: builder.Configuration["Serilog:WriteTo:Args:ToEmail"],
        mailServer: builder.Configuration["Serilog:WriteTo:Args:SmtpServer"],
        networkCredentials: new NetworkCredential(
            builder.Configuration["Serilog:WriteTo:Args:SmtpUsername"],
            builder.Configuration["Serilog:WriteTo:Args:SmtpPassword"]
        ),
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
        mailSubject: builder.Configuration["Serilog:WriteTo:Args:EmailSubject"])
    .CreateLogger();

// Use Serilog as the logging provider


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
    Log.Information("Uygulama baþlatýlýyor");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Uygulama düzgün baþlatýlamadý");
}
finally
{
    Log.CloseAndFlush();
}
