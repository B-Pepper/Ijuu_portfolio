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
    /// ダイナマイトが着火されるギミックのView
    /// </summary>
    public class IgnitionDynamiteGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.IgnitionDynamiteGimmickPresenter _presenter;
        
        /// <summary>
        /// コンロの状態を取得するためのインスタンス
        /// </summary>
        [SerializeField] private ChangeStoveStatusView _changeStoveStatusView;

        /// <summary>
        /// 選択アイテム画像の更新用インスタンス
        /// </summary>
        /// <returns></returns>
        [SerializeField] private ItemBoxSelectItemImageView _itemBoxSelectItemImageView;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new IgnitionDynamiteGimmickPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // 麻紐(長)が選択状態であるか
            // ダイナマイト設置ギミックがUNLOCK(ダイナマイト設置済)であるか
            // コンロが着火状態であるか
            if (Config.GetItemStatus(ItemConstant.ITEM_LONGASAHIMO_ID) == ItemConstant.ITEM_HAVE
            && _presenter.GetGimmickStatus(GimmickConstant.GIMMICK_BEDROOM_DYNAMITE_ID) == GimmickConstant.GIMMICK_UNLOCK
            && _changeStoveStatusView.GetStatus() == true)
            {
                // ギミックステータスのステータスを設定
                // このギミックがUNLOCKされていることを寝室爆破のフラグとする
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);

                // 麻紐(長)を消費
                Config.SetItemStatus(ItemConstant.ITEM_LONGASAHIMO_ID, ItemConstant.ITEM_CONSUME);
                // 選択アイテム画像を更新
                _itemBoxSelectItemImageView.UpdateSelectItemImage();

                // 着火SE
                SoundManageView.GetInstance().PlaySE((int)SEType.TikTikTik);
                // 移動回数を0に設定
                Config.ResetCountStepNum();
            }
        }
    }
}