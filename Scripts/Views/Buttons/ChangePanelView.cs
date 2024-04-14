using System.Collections;
using System.Collections.Generic;
using MVP.Sounds;
using UnityEngine;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// パネル切り替えボタンのView
    /// </summary>
    public class ChangePanelView
    {
        /// <summary>
        /// 自パネル
        /// </summary>
        private GameObject _fromPanel;
        /// <summary>
        /// 遷移パネル
        /// </summary>
        private GameObject _toPanel;
        /// <summary>
        /// SEのタイプID
        /// </summary>
        private SEType _seId = SEType.None;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fromPanel">遷移対象パネル</param>
        /// <param name="toPanel">遷移先パネル</param>
        /// <param name="seId">SE種別</param>
        public ChangePanelView(GameObject fromPanel, GameObject toPanel, SEType seId = SEType.None)
        {
            _fromPanel = fromPanel;
            _toPanel = toPanel;
            _seId = seId;
        }

        /// <summary>
        /// クリック時にパネル切り替え
        /// </summary>
        public void Onclick()
        {
            SoundManageView.GetInstance().PlaySE((int)_seId);
            _fromPanel.SetActive(false);
            _toPanel.SetActive(true);
        }
    }
}