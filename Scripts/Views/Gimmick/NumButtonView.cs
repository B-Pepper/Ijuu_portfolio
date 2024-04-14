using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// クリックされるボタン
    /// </summary>
    public class NumButtonView : MonoBehaviour
    {
        /// <summary>
        /// EntranceGimmickViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private MVP.Views.EntranceGimmickView _entranceGimmickView;

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="buttonNum">入力された暗証番号</param>
        public void OnClick(string buttonNum)
        {
            _entranceGimmickView.OnClick(buttonNum);
        }
    }
}