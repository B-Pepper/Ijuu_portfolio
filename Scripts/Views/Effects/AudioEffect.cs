using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;


namespace MVP.Effects
{
    /// <summary>
    /// SnapShotの種別
    /// </summary>
    public enum SnapShotType
    {
        Normal,
        Box
    }
    
    /// <summary>
    /// サウンド系のエフェクト管理クラス
    /// </summary>
    public class AudioEffect
    {
        /// <summary>
        /// 音源の音量をフェードさせる
        /// </summary>
        /// <param name="audioSource">音源</param>
        /// <param name="duration">フェード時間</param>
        public static Tween Fade(AudioSource audioSource, float duration, float targetVolume = 0.2f)
        {
            return audioSource.DOFade(targetVolume, duration).SetEase(Ease.InCubic);
        }

        /// <summary>
        /// SnapShotを切り替える
        /// </summary>
        /// <param name="audioMixer">対象のミキサ</param>
        /// <param name="toShot">切り替えるSnapShot種別</param>
        /// <param name="duration">切り替え時間</param>
        public static void ChangeSnapShot(AudioMixer audioMixer, SnapShotType toShot, float duration = 0.2f)
        {
            audioMixer.FindSnapshot(toShot.ToString()).TransitionTo(duration);
        }

    }
}