using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

namespace MVP.Views
{
    /// <summary>
    /// 氷塊のView
    /// </summary>
    public class IceBlockView : MonoBehaviour
    {
        /// <summary>
        /// アイテム画像
        /// </summary>
        [SerializeField] GameObject _itemImage;
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.IceBlockPresenter _presenter;
        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.IceBlockPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // アイテムのステータスを設定
            _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_GET);
            // アイテムの画像を非表示にする
            Debug.Log("itemImage => FALSE");
            _itemImage.SetActive(false);
            // アイテムボックスに表示する
            

            /* STEAM対応必須箇所 */

            Debug.Log("API初期化開始");
            // API初期化
            if (SteamManager.Initialized)
            {
                Debug.Log("API初期化完了");
                // ユーザーの現在のデータと実績を非同期に要求
                if (SteamUserStats.RequestCurrentStats())
                {
                    Debug.Log("ユーザーの現在のデータと実績を非同期に要求");

                    SteamUserStats.SetAchievement("test_0");
                    // 更新を反映
                    bool bSuccess = SteamUserStats.StoreStats();
                    Debug.Log("更新が反映されているか :"+bSuccess);
                    
                    bool ok = SteamUserStats.GetAchievement("test_0", out ok);
                    Debug.Log("実績が反映されているか :" + ok);
                    
                    // if (SteamUserStats.ResetAllStats(true))
                    // {
                    //     SteamUserStats.RequestCurrentStats();
                    //     // // statsを更新
                    //     // SteamUserStats.SetStat("stat_test_0", 1);
                    //     // // 更新を反映
                    //     // bool bSuccess = SteamUserStats.StoreStats();

                    //     SteamUserStats.SetAchievement("test_0");
                    //     // 更新を反映
                    //     bool bSuccess = SteamUserStats.StoreStats();
                    //     Debug.Log("更新が反映されているか :"+bSuccess);

                    //     bool ok = SteamUserStats.GetAchievement("test_0", out ok);
                    //     Debug.Log("実績が反映されているか :" + ok);

                    // }
                    
                    string playerName = SteamFriends.GetPersonaName();
                    Debug.Log("スチームプレイヤー名 :"+playerName);

                }
            }
            Debug.Log("API処理終了");
            
            /* STEAM対応必須箇所 */
        }
    }
}