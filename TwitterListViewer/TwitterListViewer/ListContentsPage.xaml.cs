using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;
using CoreTweet.Core;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TwitterListViewer
{
    /// <summary>
    /// リスト内容クラス
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContentsPage : ContentPage
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="statuses">ステータス一覧</param>
        public ListContentsPage(ListedResponse<Status> statuses)
        {
            InitializeComponent();

            //Twitterリストの内容をListViewにバインド
            this.TweetsView.ItemsSource = statuses.OrderByDescending(status => status.CreatedAt);
        }
    }
}