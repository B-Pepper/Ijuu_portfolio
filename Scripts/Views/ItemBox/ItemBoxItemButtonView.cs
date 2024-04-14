using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// アイテムボックスのアイテムボタンクリック時の処理
    /// </summary>
    public class ItemBoxItemButtonView : MonoBehaviour
    {
        /// <summary>
        /// ItemBoxViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private MVP.Views.ItemBoxView _itemBoxView;

        /// <summary>
        /// アイテム番号(ItemConstant参照)
        /// </summary>
        [SerializeField] private int _itemNum;

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            _itemBoxView.OnClick(_itemNum);
        }
    }
}