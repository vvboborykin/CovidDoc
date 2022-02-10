using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter.Deserialization;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.AspNetCore.OData.Routing.Template;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using CovidDoc.Model;
using System.Reflection;
using CovidDoc.WebApi.Services;

namespace CovidDoc.WebApi
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // регистрируем OData в списке сервисов (в вер 8 порядок регистрации изменен)
            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel())
                .Filter().Select().Expand().Count().OrderBy().SkipToken());

            // сервис безопасности API
            services.AddScoped<SecurityService>();
            services.AddScoped<StateMachineService>();
            services.AddScoped<StatusTransitionPredicateEvaluator>();

            services.AddLogging();
            services.AddDbContext<CovidDoc.Model.CovidDocModel>(options => options.UseSqlite(Configuration.GetConnectionString(@"CovidDoc")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CovidDoc.WebApi", Version = "v1" });
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            
            // определяем модель OData для кождого из типов бизнес - классов EF
            foreach (var entityclass in typeof(AppUser).Assembly.GetTypes().Where(x => x.IsClass && x.GetProperty("Id") != null))
            {
                if (entityclass.Name.Contains(@"Anonymou"))
                    continue;
                EntityTypeConfiguration entityType = builder.AddEntityType(entityclass);
                entityType.HasKey(entityclass.GetProperty("Id"));
                builder.AddEntitySet(entityclass.Name, entityType);
            }
            
            return builder.GetEdmModel();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CovidDoc.WebApi v1"));
            }

            app.UseAuthentication();

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
