using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// 確認画面表示/非表示機能
    /// </summary>
    public class MoveConfirmationButtonView : MonoBehaviour
    {
        /// <summary>
        /// 確認パネル
        /// </summary>
        [SerializeField] GameObject _confirmationPanel;

        /// <summary>
        /// クリック時にパネル表示
        /// </summary>
        public void OnDisplay()
        {
            _confirmationPanel.SetActive(true);
        }

        /// <summary>
        /// クリック時にパネル非表示
        /// </summary>
        public void OnHidden()
        {
            _confirmationPanel.SetActive(false);
        }
    }
}