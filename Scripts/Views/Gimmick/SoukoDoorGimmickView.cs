using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 倉庫の扉ギミックのView
    /// </summary>
    public class SoukoDoorGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private SoukoDoorGimmickPresenter _presenter;

        /// <summary>
        /// 画像変更を行う処理のインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 入力された暗証番号
        /// </summary>
        private string[] _inputNum;

        /// <summary>
        /// すべての倉庫ボタンの画像
        /// </summary>
        [SerializeField] private Image[] _soukoButtonImages;

        /// <summary>
        /// 倉庫ボタン画像のパス
        /// </summary>
        [SerializeField] private string _soukoButtonImagePath;

        /// <summary>
        /// ダイナマイトアイテム
        /// </summary>
        [SerializeField] private GameObject _dynamiteItem;


        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new SoukoDoorGimmickPresenter();
            _changeImageView = new ChangeImageView();
            _inputNum = new string[_presenter.GetSoukoDoorGimmickNum().Length];
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _LightAllOnButtons(_soukoButtonImages);
            }
            if (Config.GetItemStatus(ItemConstant.ITEM_DYNAMITE_ID) > ItemConstant.ITEM_DEFAULT)
            {
                _dynamiteItem.SetActive(false);
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="buttonNum">入力されたボタン</param>
        public void OnClick(string buttonNum, Image buttonImage)
        {
            if (_presenter.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK)
            {
                _HandleButton(buttonNum, buttonImage);
                _HandleCheck();
            }
            


            for (int i = 0; i < _inputNum.Length; i++)
            {
                Debug.Log(i+1+"番目の値:" + _inputNum[i]);
            }
        }

        /// <summary>
        /// ボタン入力回数によって表示を変える
        /// </summary>
        private void _HandleButton(string buttonNum, Image buttonImage)
        {
            // 4回目入力時に表示を消す
            if (_inputNum[_inputNum.Length-1] != null)
            {
                // 格納されている配列を初期化
                _presenter.initInputNum(_inputNum);
                _LightAllOffButtons(_soukoButtonImages);
            }
            // 1-3回目入力時
            else
            {
                int inputNumElement = _presenter.StockInputNum(_inputNum, buttonNum);
                // 押されたボタンを点灯させる
                _LightOnButton(buttonImage);
                SoundManageView.GetInstance().PlaySE((int)SEType.Tap);
            }
        }


        /// <summary>
        /// 入力をチェックして必要に応じてステータス変更
        /// </summary>
        private void _HandleCheck()
        {
            if(_presenter.checkUnlock(_presenter.GetSoukoDoorGimmickNum(), _inputNum))
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                _LightAllOnButtons(_soukoButtonImages);
                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)SEType.Lock);
            }
        }

        /// <summary>
        /// ボタンを点灯
        /// </summary>
        /// <param name="inputButton">押されたボタン</param>
        /// <param name="buttonImage">変更するボタン画像</param>
        private void _LightOnButton(Image buttonImage)
        {
            // 画像をフェードインさせる
            ImageAlphaChanger.FadeIn(buttonImage);
            Debug.Log("ボタン点灯");
            Debug.Log("点灯ボタン画像  :"+buttonImage);
        }

        /// <summary>
        /// ボタンを消灯
        /// </summary>
        /// <param name="inputButton">押されたボタン</param>
        /// <param name="buttonImage">変更するボタン画像</param>
        private void _LightOffButton(Image buttonImage)
        {
            // 画像をフェードアウトさせる
            ImageAlphaChanger.FadeOut(buttonImage);
            Debug.Log("ボタン消灯");
            Debug.Log("消灯ボタン画像  :"+buttonImage);
        }

        /// <summary>
        /// 渡された画像全てONにする
        /// </summary>
        /// <param name="buttonImages">ボタン画像配列</param>
        private void _LightAllOnButtons(Image[] buttonImages)
        {
            for (int i = 0;i < buttonImages.Length;i++)
            {
                // 押されたボタンを点灯させる
                _LightOnButton(buttonImages[i]);
            }
        }

        /// <summary>
        /// 渡された画像全てOFFにする
        /// </summary>
        /// <param name="buttonImages">ボタン画像配列</param>
        private void _LightAllOffButtons(Image[] buttonImages)
        {
            for (int i = 0;i < buttonImages.Length;i++)
            {
                // 押されたボタンを消灯させる
                _LightOffButton(buttonImages[i]);
            }
        }
    }
}