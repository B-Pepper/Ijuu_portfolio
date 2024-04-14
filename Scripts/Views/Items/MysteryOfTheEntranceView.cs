using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// 玄関の謎のView
    /// </summary>
    public class MysteryOfTheEntranceView : MonoBehaviour
    {
        /// <summary>
        /// アイテム画像
        /// </summary>
        [SerializeField] GameObject _itemImage;

        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.MysteryOfTheEntrancePresenter _presenter;
        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.MysteryOfTheEntrancePresenter();
            if (Config.GetItemStatus(_presenter.GetItemID()) > ItemConstant.ITEM_DEFAULT)
            {
                _itemImage.SetActive(false);
                return;
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // アイテムのステータスを設定
            _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_CANT_USE);
            // アイテムの画像を非表示にする
            Debug.Log("itemImage => FALSE");
            _itemImage.SetActive(false);
        }
    }
}