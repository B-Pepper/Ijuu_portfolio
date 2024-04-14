using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// ダイナマイトを着火して自殺エンド遷移ギミックのView
    /// </summary>
    public class IceBlockGimmickView : MonoBehaviour
    {
        /// <summary>
        /// プレゼンタ
        /// </summary>
        private IceBlockGimmickPresenter _presenter;

        /// <summary>
        /// コンロの状態を取得するためのインスタンス
        /// </summary>
        [SerializeField] private ChangeStoveStatusView _changeStoveStatusView;

        /// <summary>
        /// キッチンギミックの管理用インスタンス
        /// </summary>
        [SerializeField] private KitchenGimmickView _kitchenGimmickView;

        /// <summary>
        /// 選択アイテム画像の更新用インスタンス
        /// </summary>
        /// <returns></returns>
        [SerializeField] private ItemBoxSelectItemImageView _itemBoxSelectItemImageView;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new IceBlockGimmickPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // 氷塊が選択状態であるか
            // コンロが着火状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_ICEBLOCK_ID) == ItemConstant.ITEM_HAVE
            && _changeStoveStatusView.GetStatus()
            && _presenter.GetGimmickStatus(GimmickConstant.GIMMICK_KITCHEN_ID) == GimmickConstant.GIMMICK_LOCK)
            {
                // ギミック状態を変更
                _presenter.SetGimmickStatus(GimmickConstant.GIMMICK_KITCHEN_ID, GimmickConstant.GIMMICK_UNLOCK);
                // 氷塊消費
                Config.SetItemStatus(ItemConstant.ITEM_ICEBLOCK_ID, ItemConstant.ITEM_CONSUME);
                _kitchenGimmickView.HandleViewKeyInIce(true);
                // チャリンSE
                SoundManageView.GetInstance().PlaySE((int)SEType.Charin);
                // 選択アイテム画像を更新
                _itemBoxSelectItemImageView.UpdateSelectItemImage();
            }
        }
    }
}