using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// ダイナマイトを設置するギミックのView
    /// </summary>
    public class BedRoomDynamiteGimmickView : MonoBehaviour
    {
        /// <summary>
        /// ワイヤー状態のタンス
        /// </summary>   
        private const int CHEST_WIRE = 0;
        
        /// <summary>
        /// ワイヤー切断後開けた状態のタンス
        /// /// </summary>
        private const int CHEST_OPEN = 1;
        
        /// <summary>
        /// ワイヤー切断後閉めた状態のタンス
        /// </summary>
        private const int CHEST_CLOSE = 2;

        /// <summary>
        /// パネル変更ボタン
        /// </summary>
        [SerializeField] ChangePanelButtonView _changePanelButtonView;

        /// <summary>
        /// 選択アイテム画像の更新用インスタンス
        /// </summary>
        /// <returns></returns>
        [SerializeField] private ItemBoxSelectItemImageView _itemBoxSelectItemImageView;
        
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private BedRoomDynamiteGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// タンスの状態を取得するインスタンス
        /// </summary>
        private ChangeChestStatusView _changeChestStatusView;

        private void Awake()
        {
            _presenter = new BedRoomDynamiteGimmickPresenter();
            _changeImageView = new ChangeImageView();
            _changeChestStatusView = new ChangeChestStatusView();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ダイナマイトが選択状態であるか
            // このギミックがロック状態であるか
            if(Config.GetItemStatus(ItemConstant.ITEM_DYNAMITE_ID) == ItemConstant.ITEM_HAVE 
            && _presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                
                // ダイナマイトを消費
                Config.SetItemStatus(ItemConstant.ITEM_DYNAMITE_ID, ItemConstant.ITEM_CONSUME);
                // 選択アイテム画像を更新
                _itemBoxSelectItemImageView.UpdateSelectItemImage();

                // ダイナマイト設置フラグを立てる
                Config.SetIsSetDynamite(true);

                // 寝室のステータスを変更
                if (Config.GetBedroomStatus() == GimmickConstant.BEDROOM_STATUS_WIRE)
                {
                    Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_WIREDYNAMITE);
                }
                else if(Config.GetBedroomStatus() == GimmickConstant.BEDROOM_STATUS_DEFAULT)
                {
                    Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_DYNAMITE);
                }
                // 残り移動回数機能 初期化処理
                // RemainingStepsView.GetInstance().Init();
                // パネル切り替え
                _changePanelButtonView.Onclick();
            }
        }
    }
}