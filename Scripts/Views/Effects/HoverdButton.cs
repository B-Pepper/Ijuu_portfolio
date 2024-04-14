using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace MVP.Views
{
    /// <summary>
    /// 遷移ボタンホバーイン・アウト時の挙動
    /// </summary>
    public class HoverdButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        /// <summary>
        /// 何秒かけて再生するか
        /// </summary>
        [SerializeField] float _duration = 0.5f;

        /// <summary>
        /// 透明度
        /// </summary>
        [SerializeField] float _alphaVolume = 0.2f;

        /// <summary>
        /// 画像コンポーネント
        /// </summary>
        private Image _image;


        // Start is called before the first frame update
        void Awake()
        {
            _image = GetComponent<Image>();
        }

        /// <summary>
        /// マウスホバーインした時のイベント
        /// </summary>
        /// <param name="eventData">イベントデータ</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            hoverIn();
        }

        /// <summary>
        /// マウスホバーアウトした時のイベント
        /// </summary>
        /// <param name="eventData">イベントデータ</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            hoverOut();
        }

        /// <summary>
        /// マウスホバーインエフェクト
        /// </summary>
        private void hoverIn()
        {
            _image.DOFade(1f, _duration);
        }

        /// <summary>
        /// マウスホバーアウトエフェクト
        /// </summary>
        private void hoverOut()
        {
            _image.DOFade(_alphaVolume, _duration);
        }
    }
}