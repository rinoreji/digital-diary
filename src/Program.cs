var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api", () => "Hello World!");
app.MapGet("/api/{name}", (string name) => $"Hello {name}!");

app.UseRouting();
app.UseEndpoints(_ => {});
app.Use((ctx,next)=>{
    if(ctx.Request.Path.StartsWithSegments("/api")){
        ctx.Response.StatusCode = 404;
        return Task.CompletedTask;
    }
    return next();
});

app.UseSpa(x=>{
    x.UseProxyToSpaDevelopmentServer("https://3000-rinoreji-digitaldiary-6owqkgb9h75.ws-us97.gitpod.io");
});
app.Run();
