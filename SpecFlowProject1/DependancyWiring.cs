using Autofac;
using Automation.BrowserDrivers;
using Automation.Common;
using Automation.Common.Config;
using Automation.Hooks;
using Automation.Pages;
using Microsoft.Extensions.Configuration;
using SpecFlow.Autofac;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Setup.DependencyInjection.Selenium
{
    public static class DependencyWiring
    {
        [ScenarioDependencies]
        public static Autofac.ContainerBuilder CreateContainerBuilder()
        {
            Autofac.ContainerBuilder builder = new Autofac.ContainerBuilder();

            IConfiguration config = CreateConfig();

            AppConfig appConfig = config.Get<AppConfig>();

            builder.RegisterInstance(appConfig)
                .As<AppConfig>();

            builder.RegisterInstance(config)
                .As<IConfiguration>()
                .SingleInstance();

            AddSpecFlowHooks(builder);
            AddBrowserDrivers(builder);
            AddClassesWithBindingAttribute(builder);
            AddBaseCodeClasses(builder);

            return builder;
        }

        private static IConfiguration CreateConfig()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            return configurationRoot;
        }

        private static void AddSpecFlowHooks(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<SpecFlowHooks>().SingleInstance();
        }

        private static void AddBrowserDrivers(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<ChromeContext>().As<ISeleniumContext>().SingleInstance();
        }

        private static void AddClassesWithBindingAttribute(Autofac.ContainerBuilder builder)
        {
            // Auto-register all classes with the [Binding] attribute from our assembly
            Type[] types = typeof(DependencyWiring).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray();

            builder.RegisterTypes(types).SingleInstance();
        }

        private static void AddBaseCodeClasses(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<BasePage>().SingleInstance();
            builder.RegisterType<LandingPage>().SingleInstance();
            builder.RegisterType<FormAuthenticationPage>().SingleInstance();
            builder.RegisterType<InfiniteScrollPage>().SingleInstance();
            builder.RegisterType<KeyPressesPage>().SingleInstance();

        }
    }
}