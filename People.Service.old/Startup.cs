//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TightCoupling
//{
//	public class Startup
//	{
//		public Startup(IConfiguration configuration)
//		{
//			Configuration = configuration;
//		}

//		public IConfiguration Configuration { get; }

//		// This method gets called by the runtime. Use this method to add services to the container.
//		public void ConfigureServices(IServiceCollection services)
//		{
//			services.AddControllersWithViews();
//		}

//		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//		{
//			if (env.IsDevelopment())
//			{
//				app.UseDeveloperExceptionPage();
//			}
//			else
//			{
//				app.UseExceptionHandler("/Home/Error");
//				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//				app.UseHsts();
//			}
//			app.UseHttpsRedirection();
//			app.UseStaticFiles();

//			app.UseRouting();

//			app.UseAuthorization();

//			app.UseEndpoints(endpoints =>
//			{
//				endpoints.MapControllerRoute(
//									name: "default",
//									pattern: "{controller=Home}/{action=Index}/{id?}");
//			});
//		}
//	}
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using People.Service.Models;

namespace People.Service
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

			services.AddControllers();
			services.AddSingleton<IPeopleProvider, HardCodedPeopleProvider>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "People.Service", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "People.Service v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
