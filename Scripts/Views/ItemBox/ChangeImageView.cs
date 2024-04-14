using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// 指定された画像を変更する
    /// </summary>
    public class ChangeImageView
    {
        /// <summary>
        /// 画像を変更する
        /// </summary>
        /// <param name="originalImage">変更先の画像</param>
        /// <param name="imagePath">変更する画像パス</param>
        public void ChangeImage(Image originalImage, string imagePath)
        {
            originalImage.sprite = Resources.Load<Sprite>(imagePath);
        }
    }
}
