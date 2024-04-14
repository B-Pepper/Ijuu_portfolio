using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// 玄関ギミックを実行可能にするギミックのボタンView
    /// </summary>
    public class TapeGimmickButtonView : MonoBehaviour
    {
        [SerializeField] private TapeGimmickView _tapeGimmickView;

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            _tapeGimmickView.OnClick();
        }
    }
}
