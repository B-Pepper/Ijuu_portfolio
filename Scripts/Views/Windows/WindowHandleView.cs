using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// ウィンドウを操作するやつ
    /// </summary>
    public class WindowHandleView : MonoBehaviour
    {
        /// <summary>
        /// 対象ウィンドウ
        /// </summary>
        [SerializeField] GameObject[] _windowPanels;

        /// <summary>
        /// se種別
        /// </summary>
        [SerializeField] SEType _seId;

        /// <summary>
        /// 画像を表示
        /// </summary>
        public void OnDisplayClick(bool isPlay)
        {
            foreach (var windowPanel in _windowPanels)
            {
                windowPanel.SetActive(true);            
            }
            if (isPlay)
            {
                SoundManageView.GetInstance().PlaySE((int)_seId);
            }
            Config.SetIsOpenSettingWindow(true);
        }

        /// <summary>
        /// 画像を非表示
        /// </summary>
        public void OnHiddenClick(bool isPlay)
        {
            foreach (var windowPanel in _windowPanels)
            {
                windowPanel.SetActive(false);
            }
            if (isPlay)
            {
                SoundManageView.GetInstance().PlaySE((int)_seId);
            }
            Config.SetIsOpenSettingWindow(false);
        }
    }
}
