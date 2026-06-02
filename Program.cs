using BlazorApps.Components;
using BlazorApps.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSingleton<AuthenticationStateService>();
builder.Services.AddSingleton<NotificationConfig>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<TodoDbService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
