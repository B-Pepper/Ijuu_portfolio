using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// 倉庫のボタンView
    /// </summary>
    public class SoukoButtonView : MonoBehaviour
    {
        /// <summary>
        /// SoukoDoorGimmickViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private SoukoDoorGimmickView _soukoDoorGimmickView;

        /// <summary>
        /// ボタン記号
        /// </summary>
        [SerializeField] private string _buttonSymbol;

        /// <summary>
        /// ボタン画像
        /// </summary>
        [SerializeField] private Image _buttonImage;

        /// <summary>
        /// 起動するたびに数字と画像は初期化
        /// </summary>
        private void Awake()
        {
            InitImage(_buttonSymbol);
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="button">buttonの種類</param>
        public void OnClick(string button)
        {
            _soukoDoorGimmickView.OnClick(button, _buttonImage);
        }

        /// <summary>
        /// ボタンの画像を変更
        /// </summary>
        /// <param name="button">buttonの種類</param>
        public void InitImage(string button)
        {
            // ファイルパス未記載
            // this.GetComponent<Image>().sprite = Resources.Load<Sprite>("" + button);
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/10_Souko/puzzleButton_" + button);
        }
    }
}