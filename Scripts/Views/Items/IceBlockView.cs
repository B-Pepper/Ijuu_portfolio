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
        }
    }
}