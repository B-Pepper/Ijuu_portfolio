using UnityEngine;
using MVP.Sounds;
using MVP.Effects;
using System.Collections;

namespace MVP.Views
{
    /// <summary>
    /// タイトルBGM制御
    /// </summary>
    public class TitleBGMView : MonoBehaviour
    {
        /// <summary>
        /// 場所によって音量を変えるための係数
        /// </summary>
        private const float volumeRate = 1.0f;

        /// <summary>
        /// このシーンでのSnapShot
        /// </summary>
        private const SnapShotType _snapShotType = SnapShotType.Normal;


        IEnumerator Start()
        {
            SoundManageView soundManageView = SoundManageView.GetInstance();
            // ADVの音声停止
            soundManageView.StopBGM();
            soundManageView.StopSE();
            // シーン固有の音量率をConfigに設定
            SoundConfig.SetVolumeRate(volumeRate);

            while (Config.GetIsOpenSettingWindow())
                yield return null;

            // ゲームを一周した場合
            if (Config.GetIsPlayingNow())
            {
                // ゲーム開始フラグ設定
                Config.SetIsPlayingNow(false);
                soundManageView.StopBGM();
                // 音量0からスタート
                soundManageView.ExecFade(SoundType.BGM, 0f);
                // タイトルBGM再生
                soundManageView.PlayBGM(0, true);
                // BGMフェードイン
                soundManageView.ExecFade(SoundType.BGM, 1.0f, 1.0f);
            }
            else
            {
                soundManageView.PlayBGM(0, true);
            }
            // SnapShot切り替え
            soundManageView.ExecChangeSnapShot(_snapShotType);
        }
    }
}