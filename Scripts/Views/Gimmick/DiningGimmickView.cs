using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// ダイニングの金庫ギミックのView
    /// </summary>
    public class DiningGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private DiningGimmickPresenter _presenter;

        /// <summary>
        /// 入力されたダイヤル番号
        /// </summary>
        private string[] _inputNum;

        /// <summary>
        /// ダイアルボタンの親オブジェクト
        /// </summary>
        [SerializeField] private GameObject _handleWindow;

        /// <summary>
        /// ダイアルボタンパネル遷移ボタン
        /// </summary>
        [SerializeField] private Button _handleButton;

        /// <summary>
        /// 背景変更用画像パス
        /// </summary>
        [SerializeField] private string _backgroundImagePath;

        /// <summary>
        /// 変更対象の画像オブジェクト
        /// </summary>
        [SerializeField] private Image _backgroundImage;

        /// <summary>
        /// 画像変更するやつ
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// 遷移対象パネル
        /// </summary>
        [SerializeField] private GameObject _fromPanel;
        
        /// <summary>
        /// 遷移先パネル
        /// </summary>
        [SerializeField] private GameObject _toPanel;
        
        /// <summary>
        /// パネル右切り替えするやつ
        /// </summary>
        private ChangePanelView _changePanelView;

        [SerializeField] private GameObject _driverItem;

        // Start is called before the first frame update
        void Awake()
        {
            _changePanelView = new ChangePanelView(_fromPanel, _toPanel);
            _changeImageView = new ChangeImageView();
            _presenter = new DiningGimmickPresenter();
            _inputNum = new string[_presenter.GetDiningGimmickNum().Length];


            // ギミックがUNLOCKの時、操作不可にする。
            if (Config.GetGimmickStatus(GimmickConstant.GIMMICK_DINING_SAFE_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _InteractableButtons();
                _changeImageView.ChangeImage(_backgroundImage, _backgroundImagePath);
                _driverItem.SetActive(true);
            }
            if (Config.GetItemStatus(ItemConstant.ITEM_DRIVER_ID) > ItemConstant.ITEM_DEFAULT)
            {
                _driverItem.SetActive(false);
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="num">左からnum番目のダイヤル</param>
        /// <param name="dialNum">ダイヤル番号</param>
        public void OnClick(int num, int dialNum)
        {
            if (_presenter.StockInputNum(_inputNum, num, dialNum.ToString()) != null)
            {
                Debug.Log("配列を格納できませんでした。エラー");
            }

            if(_presenter.checkUnlock(_presenter.GetDiningGimmickNum(), _inputNum))
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                // ボタン無効化
                _InteractableButtons();
                // 正解のSE
                SoundManageView.GetInstance().PlaySE((int)SEType.Lock);
                // 各種画像変更
                _driverItem.SetActive(true);
                _changeImageView.ChangeImage(_backgroundImage, _backgroundImagePath);
                // パネル切り替え
                _changePanelView.Onclick();
            }
        }

        /// <summary>
        /// 子要素のボタンを無効化する
        /// </summary>
        private void _InteractableButtons()
        {
            foreach(Button button in _handleWindow.GetComponentsInChildren<Button>())
            {
                button.interactable = false;
            }
            _handleButton.interactable = false;
        }
    }
}