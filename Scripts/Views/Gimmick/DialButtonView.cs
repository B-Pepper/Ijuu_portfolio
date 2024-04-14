using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// ダイヤルボタンのView
    /// </summary>
    public class DialButtonView : MonoBehaviour
    {
        /// <summary>
        /// DiningGimmickViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private DiningGimmickView _diningGimmickView;

        /// <summary>
        /// BedRoomGimmickViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private BedRoomSafeGimmickView _bedroomSafeGimmickView;

        /// <summary>
        /// 最大のダイヤル番号
        /// </summary>
        [SerializeField] private int _maxDialDigits;
        /// <summary>
        /// ダイヤルの番号
        /// </summary>
        private int _dialNum;

        /// <summary>
        /// 起動するたびに数字と画像は初期化
        /// </summary>
        private void Awake() {
            _dialNum = 0;
            ChangeDialImage(_dialNum);
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="num">左からnum番目のダイヤル</param>
        public void OnClick(int num)
        {
            if (_dialNum == _maxDialDigits)
            {
                _dialNum = 0;
            }
            else 
            {
                _dialNum++;
            }
            Debug.Log($"dialNum:"+_dialNum);
            ChangeDialImage(_dialNum);
            if (_diningGimmickView != null)
            {
                _diningGimmickView.OnClick(num, _dialNum);
            }
            if (_bedroomSafeGimmickView != null)
            {
                _bedroomSafeGimmickView.OnClick(num, _dialNum);
            }
        }

        /// <summary>
        /// ダイヤル錠の画像を変更
        /// </summary>
        /// <param name="num">セットされる番号</param>
        public void ChangeDialImage(int num)
        {
            // ファイルパス未記載
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Buttons/dialNum_" + num.ToString());
            SoundManageView.GetInstance().PlaySE((int)SEType.GachaLight);
        }
    }
}
