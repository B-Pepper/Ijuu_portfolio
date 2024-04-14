using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace HarapekoADV.Sounds
{
    /// <summary>
    /// 音楽管理するクラス
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        /// <summary>
        /// BGMの要素番号
        /// </summary>
        private const int BGM_NUMBER = 0;
        /// <summary>
        /// SEの要素番号
        /// </summary>
        private const int SE_NUMBER = 1;

        /// <summary>
        /// インスタンス格納フィールド変数
        /// </summary>
        private static SoundManager _instance;

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
        /// コルーチンのインスタンスを格納
        /// </summary>
        private Coroutine _bgmLoop = null;


        /// <summary>
        /// 初期設定
        /// </summary>
        private void Awake()
        {
            UpdateBGMVolume(ADVSoundConfig.GetVolumeBGM());
            UpdateSEVolume(ADVSoundConfig.GetVolumeSE());
            ADVSoundConfig.SetIsBGMLoop(true);

            _instance = this;
        }

        /// <summary>
        /// Configの値を適用
        /// </summary>
        private void Update()
        {
            UpdateBGMVolume(ADVSoundConfig.GetVolumeBGM());
            UpdateSEVolume(ADVSoundConfig.GetVolumeSE());
        }

        /// <summary>
        /// インスタンスの取得
        /// </summary>
        /// <returns>インスタンス</returns>
        public static SoundManager GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// IDに対応したBGMの再生
        /// </summary>
        /// <param name="id">設定したBGMのID</param>
        /// <param name="isLoop">ループの可否</param>
        public void PlayBGM(int id, bool isLoop)
        {
            Debugger.Log("BGM => PlayStart:"+id+",isLoop"+isLoop);

            if (isLoop && _bgmLoop == null)
            {
                _bgmLoop = StartCoroutine(LoopTime(id, GetBGM(id).length, isLoop));
            }
            else
            {
                _audioSources[BGM_NUMBER].PlayOneShot(_allBGMs[id]);
            }
        }

        /// <summary>
        /// IDに対応したSEの再生
        /// </summary>
        /// <param name="id">設定したSEのID</param>
        public void PlaySE(int id)
        {
            Debugger.Log("SE => PlayStart:"+id);
            _audioSources[SE_NUMBER].PlayOneShot(_allSEs[id]);
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
        /// IDに対応したBGMの停止
        /// </summary>
        /// <param name="id">設定したBGMのID</param>
        public void StopBGM(int id)
        {
            _audioSources[BGM_NUMBER].Stop();
            if (_bgmLoop != null)
            {
                StopCoroutine(_bgmLoop);
                _bgmLoop = null;
            }
        }

        /// <summary>
        /// IDに対応したSEの停止
        /// </summary>
        /// <param name="id">設定したSEのID</param>
        public void StopSE(int id)
        {
            _audioSources[SE_NUMBER].Stop();
        }

        /// <summary>
        /// IDに対応したBGMの取得
        /// </summary>
        /// <param name="id">設定したBGMのID</param>
        public AudioClip GetBGM(int id)
        {
            return _allBGMs[id];
        }

        /// <summary>
        /// IDに対応したSEの取得
        /// </summary>
        /// <param name="id">設定したSEのID</param>
        public AudioClip GetSE(int id)
        {
            return _allSEs[id];
        }

        // デリゲートを引数とした関数を利用しているため、三つに関数を分けています

        /// <summary>
        /// BGM音量を更新
        /// </summary>
        /// <param name="volume">音量</param>
        private void UpdateBGMVolume(float volume)
        {
            //-80~0に変換
            float volValue = Mathf.Clamp(Mathf.Log10(volume / 5) * 20f, -80f, 0f);
            //audioMixerに代入
            _audioMixer.SetFloat("BGM", volValue);
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
            _audioMixer.SetFloat("SE", volValue);
        }

        /// <summary>
        /// BGMループ処理
        /// </summary>
        /// <param name="id">曲の番号</param>
        /// <param name="time">曲の時間</param>
        /// <param name="loop">true:有効,false:無効</param>
        /// <returns></returns>
        private IEnumerator LoopTime(int id, float time, bool loop)
        {
            if (!loop)
            {
                StopBGM(id);
                yield break;
            }
            PlayBGM(id, loop);
            yield return new WaitForSeconds(time);
            if (loop)
            {
                _bgmLoop = StartCoroutine(LoopTime(id, time, loop));
            }
        }
    }
}