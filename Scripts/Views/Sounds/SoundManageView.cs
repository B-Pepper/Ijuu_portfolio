using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using MVP.Effects;
using DG.Tweening;
using System;

namespace MVP.Sounds
{
    /// <summary>
    /// サウンド種別
    /// </summary>
    public enum SoundType
    {
        BGM = 0,
        SE = 1
    }
    
    /// <summary>
    /// 音楽管理するクラス
    /// </summary>
    public class SoundManageView : MonoBehaviour
    {
        /// <summary>
        /// BGMの要素番号
        /// </summary>
        private const int BGM_NUMBER = (int)SoundType.BGM;
        /// <summary>
        /// SEの要素番号
        /// </summary>
        private const int SE_NUMBER = (int)SoundType.SE;

        /// <summary>
        /// インスタンス格納フィールド変数
        /// </summary>
        private static SoundManageView _instance;

        /// <summary>
        /// audioMixer
        /// </summary>
        [SerializeField] AudioMixer _audioMixer;
        
        /// <summary>
        /// BGM格納用配列
        /// </summary>
        [SerializeField] AudioClip[] _allBGMs = null;

        /// <summary>
        /// SE格納用配列
        /// </summary>
        [SerializeField] AudioClip[] _allSEs = null;

        /// <summary>
        /// 音楽を鳴らすComponent
        /// </summary>
        [SerializeField] AudioSource[] _audioSources = null;


        /// <summary>
        /// 初期設定
        /// </summary>
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Configの値を適用
        /// </summary>
        private void Update()
        {
            // シーン音量率を加味した音量をConfigに適用
            SoundConfig.SetVolumeUseBGM(SoundConfig.GetVolumeBGM() * SoundConfig.GetVolumeRate());
            SoundConfig.SetVolumeUseSE(SoundConfig.GetVolumeSE());
            UpdateBGMVolume(SoundConfig.GetUseVolumeBGM());
            UpdateSEVolume(SoundConfig.GetUseVolumeSE());
        }

        /// <summary>
        /// インスタンスの取得
        /// </summary>
        /// <returns>インスタンス</returns>
        public static SoundManageView GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// IDに対応したBGMの再生(一度切り)
        /// </summary>
        /// <param name="id">設定したBGMのID</param>
        /// <param name="isLoop">ループ有効:true,無効:false</param>
        public void PlayBGM(int id, bool isLoop)
        {
            Debug.Log("BGM => PlayStart:"+id+",isLoop"+isLoop);
            _audioSources[BGM_NUMBER].loop = isLoop;
            _audioSources[BGM_NUMBER].clip = _allBGMs[id];
            _audioSources[BGM_NUMBER].Play();
        }

        /// <summary>
        /// IDに対応したSEの再生
        /// </summary>
        /// <param name="id">設定したSEのID</param>
        public void PlaySE(int id)
        {
            if(id != -1) {
                Debug.Log("SE => PlayStart:"+id);
                _audioSources[SE_NUMBER].PlayOneShot(_allSEs[id]);
            }
        }

        /// <summary>
        /// BGMの一時停止
        /// </summary>
        public void PauseBGM()
        {
            _audioSources[BGM_NUMBER].Pause();
        }

        /// <summary>
        /// SEの一時停止
        /// </summary>
        public void PauseSE()
        {
            _audioSources[SE_NUMBER].Pause();
        }

        /// <summary>
        /// BGMの停止
        /// </summary>
        public void StopBGM()
        {
            _audioSources[BGM_NUMBER].Stop();
        }

        /// <summary>
        /// IDに対応したSEの停止
        /// </summary>
        public void StopSE()
        {
            _audioSources[SE_NUMBER].Stop();
        }

        /// <summary>
        /// エフェクト実行メソッド
        /// </summary>
        /// <param name="soundType">サウンド種別</param>
        /// <param name="effectType">エフェクト種別</param>
        /// <param name="volume">音量</param>
        /// <param name="effectTime">エフェクト時間</param>
        public Tween ExecFade(SoundType soundType, float useVolume, float effectTime = 0.0f)
        {
            // エフェクト音量の方が設定音量よりも大きくなることを防ぐ処理
            float targetVolume = useVolume;
            switch (soundType)
            {
                case SoundType.BGM:
                    targetVolume = SoundConfig.GetUseVolumeBGM();
                break;
                case SoundType.SE:
                    targetVolume = SoundConfig.GetUseVolumeSE();
                break;
            }
            if (targetVolume > useVolume)
            {
                targetVolume = useVolume;
            }
            return AudioEffect.Fade(_audioSources[(int)soundType], effectTime, useVolume);
        }

        /// <summary>
        /// SnapShotを切り替え、エフェクトの具合を変化させる
        /// </summary>
        /// <param name="type">SnapShotType列挙型</param>
        public void ExecChangeSnapShot(SnapShotType type)
        {
            AudioEffect.ChangeSnapShot(_audioMixer, type);
        }

        /// <summary>
        /// BGM音量を更新
        /// </summary>
        /// <param name="volume">音量</param>
        private float UpdateBGMVolume(float volume)
        {
            //-80~0に変換
            float volValue = Mathf.Clamp(Mathf.Log10(volume / 5) * 20f, -80f, 0f);
            //audioMixerに代入
            _audioMixer.SetFloat("VolumeOfBGM", volValue);
            return volValue;
        }

        /// <summary>
        /// SE音量を更新
        /// </summary>
        /// <param name="volume">音量</param>
        private void UpdateSEVolume(float volume)
        {
            //-80~0に変換
            float volValue = Mathf.Clamp(Mathf.Log10(volume / 5) * 20f, -80f, 0f);
            //audioMixerに代入
            _audioMixer.SetFloat("VolumeOfSE", volValue);
        }

    }
}