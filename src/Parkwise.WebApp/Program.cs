using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(options =>
    {
        options.Title = "Orion180 Token Service";
        options.Theme = ScalarTheme.Purple;
        options.ShowSidebar = true;
        options.DefaultHttpClient = new KeyValuePair<ScalarTarget, ScalarClient>(ScalarTarget.JavaScript, ScalarClient.Axios);
        options.DarkMode = true;
        options.ShowDeveloperTools = DeveloperToolsVisibility.Always;
    });
    app.MapGet("/", () => Results.Redirect("/scalar"));
}
else
{
    app.MapGet("/", () => "Parkwise Web App is running...");
}

app.UseHttpsRedirection();

await app.RunAsync();