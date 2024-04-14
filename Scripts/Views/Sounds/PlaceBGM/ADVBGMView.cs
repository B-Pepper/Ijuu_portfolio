using UnityEngine;
using MVP.Sounds;
using DG.Tweening;
using MVP.Effects;

namespace MVP.Views
{
    /// <summary>
    /// ADVBGM制御
    /// </summary>
    public class ADVBGMView : MonoBehaviour
    {
        /// <summary>
        /// 場所によって音量を変えるための係数
        /// </summary>
        private const float _volumeRate = 1.0f;

        /// <summary>
        /// このシーンでのSnapShot
        /// </summary>
        private const SnapShotType _snapShotType = SnapShotType.Normal;


        void Start()
        {
            // シーン固有の音量率をConfigに設定
            SoundConfig.SetVolumeRate(_volumeRate);
            SoundManageView.GetInstance().StopBGM();

            // ここからゲームを始めた場合
            if (!Config.GetIsPlayingNow())
            {
                // ゲーム開始フラグ設定
                Config.SetIsPlayingNow(true);
            }
            // SnapShot切り替え
            SoundManageView.GetInstance().ExecChangeSnapShot(_snapShotType);
        }
    }
}