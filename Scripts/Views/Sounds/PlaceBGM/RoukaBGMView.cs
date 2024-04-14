using UnityEngine;
using MVP.Sounds;
using DG.Tweening;
using MVP.Effects;

namespace MVP.Views
{
    /// <summary>
    /// 廊下BGM制御
    /// </summary>
    public class RoukaBGMView : MonoBehaviour
    {
        /// <summary>
        /// 場所によって音量を変えるための係数
        /// </summary>
        private const float _volumeRate = 0.6f;

        /// <summary>
        /// このシーンでのSnapShot
        /// </summary>
        private const SnapShotType _snapShotType = SnapShotType.Normal;


        void Start()
        {
            // シーン固有の音量率をConfigに設定
            SoundConfig.SetVolumeRate(_volumeRate);

            // ここからゲームを始めた場合
            if (!Config.GetIsPlayingNow())
            {
                // ゲーム開始フラグ設定
                Config.SetIsPlayingNow(true);
                SoundManageView.GetInstance().StopBGM();
                // 音量0からスタート
                SoundManageView.GetInstance().ExecFade(SoundType.BGM, 0f);
                // BGM再生
                SoundManageView.GetInstance().PlayBGM(1, true);
                // BGMフェードイン
                SoundManageView.GetInstance().ExecFade(SoundType.BGM, 1.0f, 1.0f)
                .OnComplete(() => {
                    // ここ必要なはずだけど何実装すべきか忘れた。
                });
            }
            // SnapShot切り替え
            SoundManageView.GetInstance().ExecChangeSnapShot(_snapShotType);
        }
    }
}