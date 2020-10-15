using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MF.Rb.Domain.Repository;
using MF.Rb.FakeRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            //services.AddSingleton<IReportRepository, FakeReportRepository>();
            //services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            //services.AddSingleton<IUserRepository, FakeUserRepository>();

            // Rejestracja za pomoc¹ metody rozszerzaj¹cej
            services.AddRbServices();


            string connectionString = Configuration["connectionString"];

            var csvOptions = new CsvFormatterOptions
            {
                UseSingleLineHeaderInCsv = true,
                CsvDelimiter = ",",
                IncludeExcelDelimiterHeader = true
            };

          //  services.Configure<CsvFormatterOptions>(Configuration.GetSection("CsvOptions"));


            // Rejestracja opcji IOptions<T> i pobranie ustawieñ z pliku konfiguracyjnego
            services.Configure<FakeUserRepositoryOptions>(Configuration.GetSection("FakeUserRepositoryOptions"));

            // .NET Core 2
            // services.AddMvc()

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


            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            // Brotli - kompresor

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
             //   options.Providers.Add<GzipCompressionProvider>();   // Accept-Encoding: gzip
                options.Providers.Add<BrotliCompressionProvider>();  // Accept-Encoding: br
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
            app.UseResponseCompression();

            app.UseRouting();

            app.UseAuthorization();

            // .NET Core 2
            // app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/dashboard", context => context.Response.WriteAsync("Hello Dashboard"));
                endpoints.MapControllers();
            });
        }
    }
}
