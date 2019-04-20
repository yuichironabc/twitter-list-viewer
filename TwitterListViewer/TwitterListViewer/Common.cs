using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;
using CoreTweet.Core;

namespace TwitterListViewer
{
    /// <summary>
    /// 共通クラス
    /// </summary>
    public class Common
    {
        /// <summary>
        /// リスト一覧を取得する。
        /// </summary>
        /// <param name="token">トークン</param>
        /// <returns>リスト</returns>
        public static async Task<ListedResponse<List>> GetLists(Tokens token)
        {
            return await token.Lists.ListAsync();
        }

        /// <summary>
        /// ステータス一覧を取得する。
        /// </summary>
        /// <param name="token">トークン</param>
        /// <param name="listId">リストID</param>
        /// <param name="ownerId">オーナーID</param>
        /// <returns>ステータス</returns>
        public static async Task<ListedResponse<Status>> GetStatuses(Tokens token, long listId, long? ownerId)
        {
            return await token.Lists.StatusesAsync(list_id => listId, owner_id => ownerId, tweet_mode => TweetMode.Extended, count => 100);
        }
    }
}
