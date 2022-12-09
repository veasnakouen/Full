//import form Extensions folder in our project(Api)
using Api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();//added code
    app.UseSwagger();
    app.UseSwaggerUI();
}

//added code
else
{
    app.UseHsts();//will add middleware for using HSTS, which adds the Strict-Transport-Security header.
}


app.UseHttpsRedirection();//add the middleware for the redirect from http|https


app.UseStaticFiles();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All//will forward proxy headers to the current request.
});


app.UseCors("CorsPolicy");

app.UseAuthorization();//add authorization middleware to specified IApplicationBuilder to enable authorization capabilities

app.MapControllers();

app.Run();
