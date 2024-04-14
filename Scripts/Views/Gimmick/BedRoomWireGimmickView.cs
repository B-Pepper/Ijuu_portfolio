using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 寝室タンスワイヤーギミックのView
    /// </summary>
    public class BedRoomWireGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.BedRoomWireGimmickPresenter _presenter;

        /// <summary>
        /// 画像を変更する処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

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
        /// 効果音の種類
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.BedRoomWireGimmickPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ハサミが選択状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_SCISSORS_ID) == ItemConstant.ITEM_HAVE)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);

                // ハサミをボロボロにする
                Config.SetItemStatus(ItemConstant.ITEM_SCISSORS_ID, ItemConstant.ITEM_CONSUME);
                Config.SetItemStatus(ItemConstant.ITEM_SABISCISSORS_ID, ItemConstant.ITEM_CANT_USE);
                // 選択アイテム画像を更新
                _itemBoxSelectItemImageView.UpdateSelectItemImage();

                // 寝室のステータスを変更
                if (Config.GetBedroomStatus() == GimmickConstant.BEDROOM_STATUS_DYNAMITE)
                {
                    Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_WIREDYNAMITE);
                }
                else if(Config.GetBedroomStatus() == GimmickConstant.BEDROOM_STATUS_DEFAULT)
                {
                    Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_WIRE);
                }

                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)_seId);
                // パネル切り替え
                _changePanelButtonView.Onclick();
            }
        }
    }
}