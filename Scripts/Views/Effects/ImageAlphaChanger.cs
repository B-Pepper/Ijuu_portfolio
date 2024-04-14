using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MVP.Views
{
    /// <summary>
    /// 任意の画像コンポーネントの透明度を変更
    /// </summary>
    public static class ImageAlphaChanger
    {

        /// <summary>
        /// 何秒かけて再生するか
        /// </summary>
        private static float _duration = 0.1f;

        /// <summary>
        /// 透明定数
        /// </summary>
        private static float _fromAlphaVolume = 0f;

        /// <summary>
        /// 目標透明度
        /// </summary>
        private static float _toAlphaVolume = 0.9f;


        /// <summary>
        /// フェードインエフェクト
        /// </summary>
        public static void FadeIn(Image image)
        {
            image.DOFade(_toAlphaVolume, _duration);
        }

        /// <summary>
        /// フェードアウトエフェクト
        /// </summary>
        public static void FadeOut(Image image)
        {
            image.DOFade(_fromAlphaVolume, _duration);
        }
    }
}