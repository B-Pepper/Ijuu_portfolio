using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVP.Views
{
    /// <summary>
    /// 麻紐(長)のView
    /// </summary>
    public class LongAsahimoView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.LongAsahimoPresenter _presenter;

        /// <summary>
        /// 選択アイテム画像の更新用インスタンス
        /// </summary>
        /// <returns></returns>
        [SerializeField] private ItemBoxSelectItemImageView _itemBoxSelectItemImageView;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.LongAsahimoPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // 麻紐(短)を３つ入手しているか
            if ((_presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO1_ID) == ItemConstant.ITEM_GET || _presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO1_ID) == ItemConstant.ITEM_HAVE)
                    && (_presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO2_ID) == ItemConstant.ITEM_GET || _presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO2_ID) == ItemConstant.ITEM_HAVE)
                    && (_presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO3_ID) == ItemConstant.ITEM_GET || _presenter.GetItemStatus(ItemConstant.ITEM_ASAHIMO3_ID) == ItemConstant.ITEM_HAVE))
            {
                // 麻紐(長)を入手
                _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_GET);
                // 麻紐(短)を消費
                _presenter.SetItemStatus(ItemConstant.ITEM_ASAHIMO1_ID, ItemConstant.ITEM_CONSUME);
                _presenter.SetItemStatus(ItemConstant.ITEM_ASAHIMO2_ID, ItemConstant.ITEM_CONSUME);
                _presenter.SetItemStatus(ItemConstant.ITEM_ASAHIMO3_ID, ItemConstant.ITEM_CONSUME);

                // 選択アイテム画像を更新
                _itemBoxSelectItemImageView.UpdateSelectItemImage();
            }
        }
    }
}