using Elanat;
using Microsoft.AspNetCore.StaticFiles;
using SetCodeBehind;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddResponseCaching();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(StaticLoad.GetSessionLifeTime().ToNumber());
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseSession();

app.UseHttpsRedirection();

app.UseRouting();

app.UseResponseCaching();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/page/error/");
    app.UseHsts();
}

CodeBehindCompiler.Initialization(true);

StaticObject.SystemStart();

StaticObject.ApplicationStart();

StaticObject.RunStartUp();

app.UseMiddleware<HandheldStaticFiles>();

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".dat"] = "application/octet-stream";
provider.Mappings[".bak"] = "application/octet-stream";
app.UseStaticFiles(new StaticFileOptions()
{
    ContentTypeProvider = provider
});

app.Use(async (context, next) =>
{
    if (context.Session.GetString("el_session_set") == null)
    {
        StaticObject.SessionStart();
        context.Session.SetString("el_session_set", "true");
    }

    await next(context);
});

app.Run(async context =>
{
    // Is Repeated
    if (context.Request.ContentType == null)
        context.Request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";

    PathAccessHandler pah = new PathAccessHandler();
    pah.ProcessRequest(context);

    await context.Response.WriteAsync(pah.ContentValue);
    await context.Response.CompleteAsync();
});

app.Run();