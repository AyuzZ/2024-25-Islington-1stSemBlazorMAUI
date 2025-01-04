using CredWatch.Services;

namespace CredWatch
{
    public partial class App : Application
    {
        //private readonly DefaultDataService _defaultDataService;

        public App() //DefaultDataService defaultDataService
        {
            InitializeComponent();

            MainPage = new MainPage();
            //_defaultDataService = defaultDataService;
        }

        //protected override async void OnStart()
        //{
        //    base.OnStart();
        //    //await _defaultDataService.InsertDefaultDataAsync();
        //}
    }
}
