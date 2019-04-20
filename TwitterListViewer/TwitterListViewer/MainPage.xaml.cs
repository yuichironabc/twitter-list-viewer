using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using CoreTweet;
using CoreTweet.Core;

namespace TwitterListViewer
{
    /// <summary>
    /// メインページクラス
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="token">トークン</param>
        /// <param name="lists">リスト一覧</param>
        public MainPage(Tokens token, ListedResponse<List> lists)
        {
            InitializeComponent();
            this.Title = "リスト一覧";

            //リスト一覧をListViewにバインド
            this.TwitterList.ItemsSource = lists.OrderBy(list => list.Name);

            //リスト選択イベント
            this.TwitterList.ItemSelected += async (sender, e) =>
            {
                //選択したリストの内容を表示する
                ListedResponse<Status> statuses = await Common.GetStatuses(token, ((List)e.SelectedItem).Id, ((List)e.SelectedItem).User.Id);
                await Navigation.PushAsync(new ListContentsPage(statuses));
            };
        }        
    }
}
