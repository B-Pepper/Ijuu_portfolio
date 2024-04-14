using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// ボタンのスライドフェードイン
    ///  配置場所へ移動ベクトルでエフェクト
    /// </summary>
    public class SlideFadeInButton : MonoBehaviour
    {
        /// <summary>
        /// Awake時にエフェクト再生するかのフラグ
        /// </summary>
        [SerializeField] bool _isAwake = false;

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
        /// 初期位置(現在位置へ移動してくるためこれがtargetになる)
        /// </summary>
        private Vector3 _targetPosition;

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

        /// <summary>
        /// 再生をしたか？
        /// </summary>
        private bool _isAnimated = false;
        
        
        void Awake()
        {
            // 各コンポーネント取得
            _button = GetComponent<Button>();
            // ボタン無効化
            _button.interactable = false;
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
            InitLocalPosition();
            InitAlpha();
            

            // 開始時に再生するか
            if (_isAwake)
            {
                ExecAnimation();
            }
        }

        void Update()
        {
            // スライド再生しておらず、ロゴアニメ再生終了していれば再生
            if(!_isAnimated && Config.GetIsDoneLogoAnime())
            {
                ExecAnimation();
            }
        }

        /// <summary>
        /// アニメーション実行
        /// </summary>
        public void ExecAnimation()
        {
            // 再生済みフラグ有効
            _isAnimated = true;

            Sequence sequence = DOTween.Sequence()
            .Append(_SlideIn())
            .Join(_FadeIn())
            .SetDelay(_delay)
            .OnComplete(() =>
            {
                // ボタン有効化
                _button.interactable = true;
            });

            sequence.Play();

        }

        /// <summary>
        /// スライド処理
        /// </summary>
        /// <returns>DOTweenエフェクト</returns>
        private Tween _SlideIn()
        {
            return _rectTransform.DOLocalMove(_targetPosition, _duration);
        }

        /// <summary>
        /// フェードイン処理
        /// </summary>
        /// <returns>DOTweenエフェクト</returns>
        private Tween _FadeIn()
        {
            return _image.DOFade(1f, _duration);
        }

        /// <summary>
        /// 初期位置移動(アニメ初期位置)
        /// </summary>
        private void InitLocalPosition()
        {
            // 初期位置を保存(現在位置へ移動してくるためこれがtargetになる)
            _targetPosition = _rectTransform.transform.localPosition;
            // 初期位置移動(アニメ初期位置)
            _rectTransform.anchoredPosition = _targetPosition + _transferVolume;
        }

        /// <summary>
        /// 透明度初期化
        /// </summary>
        private void InitAlpha()
        {

            Color currentColor = _image.color;
            currentColor.a = 0f;
            _image.color = currentColor;
        }
    }
}
