using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MF.Rb.Domain.Repository;
using MF.Rb.FakeRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiContrib.Core.Formatter.Csv;

namespace MF.Rb.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Rejestracja us³ug
            services.AddSingleton<IReportRepository, FakeReportRepository>();
            services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            services.AddSingleton<IUserRepository, FakeUserRepository>();

            var csvOptions = new CsvFormatterOptions
            {
                UseSingleLineHeaderInCsv = true,
                CsvDelimiter = ",",
                IncludeExcelDelimiterHeader = true
            };

            // Dodaj pakiet WebApiContrib.Core.Formatter.Csv
            // https://github.com/WebApiContrib/WebAPIContrib.Core/tree/master/src/WebApiContrib.Core.Formatter.Csv
            services.AddControllers()
                .AddXmlSerializerFormatters()
                .AddCsvSerializerFormatters(csvOptions);


            // Rejestracja us³ug potrzebnych do kompresji

            // Dodaj pakiet Microsoft.AspNetCore.ResponseCompression

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // W³¹czenie kompresji odpowiedzi
           // app.UseResponseCompression();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
