using System.Collections;
using System.Collections.Generic;
using MVP.Sounds;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// パネル切り替えボタンのView
    /// </summary>
    public class ChangePanelButtonView : MonoBehaviour
    {
        /// <summary>
        /// 自パネル
        /// </summary>
        [SerializeField] GameObject _fromPanel;

        /// <summary>
        /// 遷移パネル
        /// </summary>
        [SerializeField] GameObject _toPanel;

        /// <summary>
        /// SEのタイプID
        /// </summary>
        [SerializeField] SEType _seId = SEType.None;

        /// <summary>
        /// パネル変更用のやつ
        /// </summary>
        private ChangePanelView _changePanelView;
        
        
        // Start is called before the first frame update
        void Awake()
        {
            _changePanelView = new ChangePanelView(_fromPanel, _toPanel, _seId);
        }

        /// <summary>
        /// クリック時にパネル切り替え
        /// </summary>
        public void Onclick()
        {
            _changePanelView.Onclick();
        }
    }
}