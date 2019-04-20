using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoreTweet;
using CoreTweet.Core;

namespace TwitterListViewer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            Tokens token = Tokens.Create(Secret.CONSUMER_KEY, Secret.CONSUMER_SECRET, Secret.ACCESS_TOKEN, Secret.ACCESS_SECRET);
            
            //リスト一覧取得
            ListedResponse<List> lists = await Common.GetLists(token);

            //メインページ生成
            MainPage = new NavigationPage(new MainPage(token, lists));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
