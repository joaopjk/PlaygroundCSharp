using GraphiQl;
using GraphQLApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CourseDbContext>(
        options => { options.UseSqlite("Data Source=Data\\coursedb.sqlite"); }
    );
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGraphiQl("/graphql");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMvc();
app.Run();
