using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// ボタンのスライドフェードイン
    ///  配置場所へ移動ベクトルでエフェクト
    /// </summary>
    public class SlideFadeOutButton : MonoBehaviour
    {
        /// <summary>
        /// Awake時にエフェクト再生するかのフラグ
        /// </summary>
        [SerializeField] bool _isAwake = true;

        /// <summary>
        /// 何秒かけて再生するか
        /// </summary>
        [SerializeField] float _duration = 0.5f;

        /// <summary>
        /// 何秒後に再生するか
        /// </summary>
        [SerializeField] float _delay = 0f;

        /// <summary>
        /// 移動ベクトル
        /// </summary>
        [SerializeField] Vector3 _transferVolume;
        
        /// <summary>
        /// ボタンコンポーネント
        /// </summary>
        private Button _button;
        
        /// <summary>
        /// 画像コンポーネント
        /// </summary>
        private Image _image;
        
        /// <summary>
        /// 場所、回転、大きさのコンポーネント
        /// </summary>
        private RectTransform _rectTransform;
        
        
        void Awake()
        {
            // 各コンポーネント取得
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();

            // 開始時に再生するか
            if (_isAwake)
            {
                ExecAnimation();
            }


        }

        public void ExecAnimation()
        {
            Color currentColor = _image.color;
            currentColor.a = 1f;
            _image.color = currentColor;

            Sequence sequence = DOTween.Sequence()
            .PrependCallback(() => {
                // ボタン無効化
                _button.interactable = false;
            })
            .Append(_SlideOut())
            .Join(_FadeOut())
            .SetDelay(_delay);

            sequence.Play();

        }

        /// <summary>
        /// スライド処理
        /// </summary>
        /// <returns>DOTweenエフェクト</returns>
        private Tween _SlideOut()
        {
            // 初期位置
            Vector3 startPosition = _rectTransform.transform.localPosition;
            // ボタンの移動位置を格納
            Vector3 targetPosition = startPosition + _transferVolume;

            return _rectTransform.DOLocalMove(targetPosition, _duration);
        }

        /// <summary>
        /// フェードイン処理
        /// </summary>
        /// <returns>DOTweenエフェクト</returns>
        private Tween _FadeOut()
        {
            return _image.DOFade(0f, _duration);
        }
    }
}
