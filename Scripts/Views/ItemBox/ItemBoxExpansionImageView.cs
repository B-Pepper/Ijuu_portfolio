using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// 拡大画像の表示/非表示
    /// </summary>
    public class ItemBoxExpansionImageView : MonoBehaviour
    {
        /// <summary>
        /// 拡大画像
        /// </summary>
        [SerializeField] GameObject _expansionImage;

        /// <summary>
        /// 画像を表示
        /// </summary>
        public void OnDisplayClick()
        {
            _expansionImage.SetActive(true);
        }

        /// <summary>
        /// 画像を非表示
        /// </summary>
        public void OnHiddenClick()
        {
            _expansionImage.SetActive(false);
        }
    }
}
