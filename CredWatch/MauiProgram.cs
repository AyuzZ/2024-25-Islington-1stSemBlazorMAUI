using CredWatch.Services;
using Microsoft.Extensions.Logging;
using Radzen;

namespace CredWatch
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            //Registering Services
            //Radzen
            builder.Services.AddRadzenComponents();
            //Default Data Service (add currencies, categories, default tags,)
            builder.Services.AddTransient<DefaultDataService>();
            //Currency
            builder.Services.AddSingleton<ICurrencyService, CurrencyService>();
            //Category
            builder.Services.AddSingleton<ICategoryService, CategoryService>();
            //Tag
            builder.Services.AddSingleton<ITagService, TagService>();
            //User
            builder.Services.AddSingleton<IUserService, UserService>();
            //AddTransaction
            builder.Services.AddSingleton<ITransactionService, TransactionService>();
            //Debt
            builder.Services.AddSingleton<IDebtService, DebtService>();
            //Auth 
            builder.Services.AddSingleton<AuthStateService>();
         

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            
#endif

            return builder.Build();
        }
    }
}
