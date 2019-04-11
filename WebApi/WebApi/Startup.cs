namespace WebApi
{
	using AutoMapper;

	using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Serialization;

    using Models;
    using Repositories;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

	    /// <summary>
	    /// Gets the configuration.
	    /// </summary>
	    public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.

	    /// <summary>
	    /// The configure services.
	    /// </summary>
	    /// <param name="services">
	    /// The services.
	    /// </param>
	    public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                            {
                                builder
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                            });
                });

            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddScoped<IOrderBraspagRepository, OrderBraspagRepository>();
            services.AddScoped<IBranchsRepository, BranchsRepository>();
            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddApiVersioning(config =>
                {
                    config.ReportApiVersions = true;
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
                });

	        services.AddAutoMapper();
            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc(
		            options =>
			            {
				            options.InputFormatters.Add(new XmlSerializerInputFormatter());
						})
	            .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

	    /// <summary>
	    /// The configure.
	    /// </summary>
	    /// <param name="app">
	    /// The app.
	    /// </param>
	    /// <param name="env">
	    /// The env.
	    /// </param>
	    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}