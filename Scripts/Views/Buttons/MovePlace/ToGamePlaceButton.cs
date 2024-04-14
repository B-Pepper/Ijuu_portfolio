using System;
using MVP.Sounds;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MVP.Views
{
    /// <summary>
    /// シーン切り替え後にフェードアウトし、効果音を再生する機能
    /// </summary>
    public class ToGamePlaceButtonView: MonoBehaviour
    {
        /// <summary>
        /// フェード対象パネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        /// <summary>
        /// 効果音の種類
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;

        /// <summary>
        /// エフェクト時間
        /// </summary>
        [SerializeField] private float _duration = 0.5f;



        void Awake()
        {
            _fadePanel.SetActive(true);
            Image image = _fadePanel.GetComponent<Image>();
            // 透明度を最大にしておく
            image.DOFade(1f, 0f);
            // フェードアウトし、効果音を再生後、シーン切り替え
            Sequence sequence = DOTween.Sequence()
            .AppendCallback(()=>PlaySE())
            .Join(FadeOut(image))
            .OnComplete(() =>{
                _fadePanel.SetActive(false);
            });
            sequence.Play();
        }

        /// <summary>
        /// 画像のフェードエフェクト
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Tween FadeOut(Image image)
        {
            return image.DOFade(0f, _duration).SetEase(Ease.InOutSine);
        }

        /// <summary>
        /// 移動時の効果音を設定している時、再生
        /// </summary>
        private void PlaySE()
        {
            if(_seId == SEType.None)
            {
                return;
            }
            SoundManageView.GetInstance().PlaySE((int)_seId);
        }
    }
}
