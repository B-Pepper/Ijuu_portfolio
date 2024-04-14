using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// 麻紐(短)のView
    /// </summary>
    public class ShortAsahimo2View : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.ShortAsahimo2Presenter _presenter;

        /// <summary>
        /// アイテム画像
        /// </summary>
        [SerializeField] GameObject _itemImage;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.ShortAsahimo2Presenter();
            if (Config.GetItemStatus(ItemConstant.ITEM_ASAHIMO2_ID) == ItemConstant.ITEM_DEFAULT
                && Config.GetGimmickStatus(GimmickConstant.GIMMICK_SYOSAI_SCISSORS2_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _itemImage.SetActive(true);
            }
            else if (Config.GetItemStatus(ItemConstant.ITEM_ASAHIMO2_ID) > ItemConstant.ITEM_DEFAULT)
            {
                _itemImage.SetActive(false);
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // アイテムのステータスを設定
            _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_GET);
            _itemImage.SetActive(false);
        }
    }
}