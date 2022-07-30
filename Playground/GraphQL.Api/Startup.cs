using GraphiQl;
using GraphQL.Api.Converter;
using GraphQL.Api.Data;
using GraphQL.Api.Queries;
using GraphQL.Api.Schemas;
using GraphQL.Api.Types;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GraphQL.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<CourseDbContext>(options =>
                options.UseSqlite("Data Source=Data\\coursedb.sqlite"));

            services.AddScoped<ProQuery>();

            services.AddScoped<ISchema, CourseSchema>();

            services.AddScoped<CourseType>();
            services.AddScoped<RatingType>();
            services.AddScoped<PaymentTypeEnum>();

            services.AddGraphQL(_ => _.EnableMetrics = false).AddSystemTextJson();

            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                .AddJsonOptions(_ =>
                {
                    _.JsonSerializerOptions.WriteIndented = true;
                    _.JsonSerializerOptions.Converters.Add(new CustomJsonConverterForType());
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL.Api v1"));
            }
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
