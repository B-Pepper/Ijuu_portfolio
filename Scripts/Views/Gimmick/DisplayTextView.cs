using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// テキスト表示に関するクラスのView
    /// </summary>
    public class DisplayTextView : MonoBehaviour
    {
        /// <summary>
        /// テキストを表示するゲームオブジェクト
        /// </summary>
        [SerializeField] private TMP_Text _displayText;

        private int _addCount = 0;

        /// <summary>
        /// 入力された番号を画面に表示
        /// </summary>
        public bool DisplayText(int num, string inputText, int maxTextLength)
        {
            if (_addCount < maxTextLength)
            {
                _displayText.text += inputText;
                _addCount++;
            }

            if (_displayText.text != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// テキストを初期化
        /// </summary>
        /// <returns></returns>
        public void InitText()
        {
            _displayText.text = "";
            _addCount = 0;
        }
    }
}
