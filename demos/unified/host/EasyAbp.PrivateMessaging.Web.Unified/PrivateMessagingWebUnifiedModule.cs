using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyAbp.PrivateMessaging.MultiTenancy;
using EasyAbp.PrivateMessaging.UnifiedDemo;
using EasyAbp.PrivateMessaging.UnifiedDemo.EntityFrameworkCore;
using EasyAbp.PrivateMessaging.UnifiedDemo.Web;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.PrivateMessaging
{
    [DependsOn(typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule))]

    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(AbpAspNetCoreSerilogModule))]
    [DependsOn(typeof(AbpSwashbuckleModule))]

    [DependsOn(typeof(UnifiedDemoHttpApiModule))]
    [DependsOn(typeof(UnifiedDemoEntityFrameworkCoreModule))]
    [DependsOn(typeof(UnifiedDemoApplicationModule))]
    [DependsOn(typeof(UnifiedDemoWebModule))]
    public class PrivateMessagingWebUnifiedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(PrivateMessagingApplicationModule).Assembly, conventionalControllerSetting =>
                    {
                        conventionalControllerSetting.ApplicationServiceTypes =
                            ApplicationServiceTypes.IntegrationServices;
                    });
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<UnifiedDemoDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EasyAbp.PrivateMessaging.UnifiedDemo.Domain.Shared", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<UnifiedDemoDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EasyAbp.PrivateMessaging.UnifiedDemo.Domain", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<UnifiedDemoApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EasyAbp.PrivateMessaging.UnifiedDemo.Application.Contracts", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<UnifiedDemoApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EasyAbp.PrivateMessaging.UnifiedDemo.Application", Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<UnifiedDemoWebModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}..{0}src{0}EasyAbp.PrivateMessaging.UnifiedDemo.Web", Path.DirectorySeparatorChar)));
                });
            }

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "PrivateMessaging API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            ConfigureConventionalControllers();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            if (context.GetEnvironment().IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");
            });

            app.UseAbpRequestLocalization();
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
        
        private void ConfigureConventionalControllers()
        {
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
            });
        }
    }
}
