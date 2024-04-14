using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// テストアイテムのView
    /// </summary>
    public class FirstKeyItemView : MonoBehaviour
    {

        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.FirstKeyItemPresenter _presenter;
        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.FirstKeyItemPresenter();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_GET);
        }
    }
}