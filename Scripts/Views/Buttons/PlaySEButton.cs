using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// ボタンクリックでSE再生
    /// </summary>
    public class PlaySEButton : MonoBehaviour
    {
        /// <summary>
        /// ボタン押下時のSE
        /// </summary>
        [SerializeField] private SEType _seId = SEType.HandleUI;
        

        /// <summary>
        /// クリックでSE再生
        /// </summary>
        public void OnClick()
        {
            SoundManageView.GetInstance().PlaySE((int)_seId);
        }
    }
}
