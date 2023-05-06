using Microsoft.AspNetCore.Mvc.Formatters;
using MoviesApp.Business.Services.Abstract;
using MoviesApp.Business.Services.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = doc =>
    {
        doc.Info.Title = "M.Semih BİLİŞ";
        doc.Info.Version = "1.0.1";
        doc.Info.Contact = new NSwag.OpenApiContact()
        {
            Name = "M.Semih BİLİŞ",
            Email = "semihbilis@gmail.com",
            Url = "https://semihbilis.github.io/cv/"
        };
    };
});
builder.Services.AddControllers(config =>
{
    config.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    config.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.General)
    {
        ReferenceHandler = ReferenceHandler.Preserve
    }));
});
builder.Services.AddSingleton<IMovieService, MovieService>();
builder.Services.AddSingleton<IVoteService, VoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUI();

app.Run();
