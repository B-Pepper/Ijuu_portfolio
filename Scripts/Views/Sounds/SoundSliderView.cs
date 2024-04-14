using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Sounds
{
    /// <summary>
    /// 音量調節バー
    /// </summary>
    public class SoundSliderView : MonoBehaviour
    {
        /// <summary>
        /// 対象のスライドバー
        /// </summary>
        [SerializeField] Slider _slider;
        /// <summary>
        /// サウンド種別
        /// </summary>
        [SerializeField] SoundType _soundType;
        /// <summary>
        /// presenter
        /// </summary>
        private SoundSliderPresenter _presenter;

        void Awake()
        {
            _presenter = new SoundSliderPresenter(_soundType);
            // バーの表示初期化
            _slider.value = _presenter.GetVolume();
        }

        void Update()
        {
            // 音量の更新
            _presenter.SetVolume(_slider.value);
        }
    }
}
