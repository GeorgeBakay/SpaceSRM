using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Repository;
using SpaceSRM.ViewModels;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CalendarView.MAUI;
namespace SpaceSRM;

public static class MauiProgram
{
	//Реєстрація сервісу для Http Підключення
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IHttpClientSend,HttpClientRepository>();
		return mauiAppBuilder;
    
    }
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseSkiaSharp(true)
            .UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.RegisterAppServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<EditServiceViewModel>();
		builder.Services.AddSingleton<EditClientViewModel>();
		builder.Services.AddSingleton<EditSetServiceViewModel>();
		builder.Services.AddSingleton<EditEmployerViewModel>();
		builder.Services.AddSingleton<RecordsViewModel>();
        builder.Services.AddSingleton<CostViewModel>();
        builder.Services.AddSingleton<StatisticClientViewModel>();
        builder.Services.AddSingleton<StatisticEmployerViewModel>();
        builder.Services.AddSingleton<StatisticViewModel>();



        return builder.Build();
	}
}

