using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;
using HarapekoADV;

namespace MVP.Views
{
    /// <summary>
    /// 玄関ギミックのView
    /// </summary>
    public class EntranceGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private EntranceGimmickPresenter _presenter;
        /// <summary>
        /// 入力された暗証番号
        /// </summary>
        private string[] _inputNum;
        /// <summary>
        /// テキストのコンポーネントを格納する
        /// </summary>
        [SerializeField] private DisplayTextView _displayTextView;

        /// <summary>
        /// フェード用パネル
        /// </summary>
        [SerializeField] private GameObject _fadePanel;

        /// <summary>
        /// シーン遷移用
        /// </summary>
        private FromGamePlaceView _fromGamePlaceView;

        /// <summary>
        /// ADVシーン番号
        /// </summary>
        private const int _advSceneNum = 11;


        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new EntranceGimmickPresenter();
            _inputNum = new string[_presenter.GetEntranceGimmickNum().Length];
            _fromGamePlaceView = new FromGamePlaceView();
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="buttonNum">入力された暗証番号</param>
        public void OnClick(string buttonNum)
        {
            // テープギミックがUNLOCKされている場合
            if (_presenter.GetGimmickStatus(GimmickConstant.GIMMICK_ENTRANCE_TAPE_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                int inputNumElement = -1;
                if (buttonNum != "Enter")
                {
                    inputNumElement = _presenter.StockInputNum(_inputNum, buttonNum);
                }
                Debug.Log("1番目の値:" + _inputNum[0]);
                Debug.Log("2番目の値:" + _inputNum[1]);
                Debug.Log("3番目の値:" + _inputNum[2]);
                Debug.Log("4番目の値:" + _inputNum[3]);

                if (buttonNum == "Enter")
                {
                    if(_presenter.checkUnlock(_presenter.GetEntranceGimmickNum(), _inputNum))
                    {
                        // ギミックステータスのステータスを設定
                        _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                        // ノーマルエンド
                        ADVConfig.SetScenarioName(EndTextType.NormalEndText);
                        SoundManageView.GetInstance().PlaySE((int)SEType.Tap);
                        // TODO: ADVConfig.SetGoalScenario();
                        _fromGamePlaceView.OnClick(_advSceneNum, _fadePanel, SEType.Gacha, 2.0f);
                        return;
                    }
                    else
                    {
                        _presenter.initInputNum(_inputNum);
                        _displayTextView.InitText();
                        // 不正解のSEを鳴らす
                        SoundManageView.GetInstance().PlaySE((int)SEType.Error);
                    }
                }

                if (inputNumElement != -1)
                {
                    // 表示する数字を増やす
                    if (_displayTextView.DisplayText(inputNumElement, buttonNum, _inputNum.Length))
                    {
                        // SE再生
                        SoundManageView.GetInstance().PlaySE((int)SEType.TapMove);
                    }
                }
                else
                {
                    // SE再生
                    SoundManageView.GetInstance().PlaySE((int)SEType.Error);
                }
            } 
            else 
            {
                // SE再生(入力不可音)
                SoundManageView.GetInstance().PlaySE((int)SEType.GachaLight);
            }
        }
    }
}