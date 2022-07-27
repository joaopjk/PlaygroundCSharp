using GraphiQl;
using GraphQL.Types;
using GraphQLApi.Data;
using GraphQLApi.Queries;
using GraphQLApi.Schemas;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Server;
using GraphQL.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CourseDbContext>(
        options => { options.UseSqlite("Data Source=Data\\coursedb.sqlite"); }
    );
builder.Services.AddScoped<ProQuery>();
builder.Services.AddScoped<ISchema, CourseSchema>();
//builder.Services.AddScoped<CourseType>();
//builder.Services.AddScoped<RatingType>();
//builder.Services.AddScoped<PaymentTypeEnum>();
#pragma warning disable CS0612 // O tipo ou membro é obsoleto
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
//builder.Services.AddSingleton<IDocumentWriter, DocumentWriter>();
builder.Services.AddGraphQL(opt => { opt.EnableMetrics = false; }).AddSystemTextJson();
//var courseTypeAssembly = Assembly.GetAssembly(typeof(CourseType));
//var ratingTypeAssembly = Assembly.GetAssembly(typeof(RatingType));
//var paymentTypeEnumAssembly = Assembly.GetAssembly(typeof(PaymentTypeEnum));
//builder.Services.AddGraphQL(x => x.EnableMetrics = false)
//    .AddGraphTypes(ServiceLifetime.Scoped)
//    .AddGraphTypes(courseTypeAssembly, ServiceLifetime.Scoped)
//    .AddGraphTypes(ratingTypeAssembly, ServiceLifetime.Scoped)
//    .AddGraphTypes(paymentTypeEnumAssembly, ServiceLifetime.Scoped)
//    //.AddUserContextBuilder(httpcontext => httpcontext.User)
//    .AddDataLoader()
//    .AddSystemTextJson();
#pragma warning restore CS0612 // O tipo ou membro é obsoleto

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMvc();
app.Run();
