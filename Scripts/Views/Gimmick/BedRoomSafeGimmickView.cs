using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Sounds;

namespace MVP.Views
{
    /// <summary>
    /// 寝室金庫ギミックのView
    /// </summary>
    public class BedRoomSafeGimmickView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.BedRoomSafeGimmickPresenter _presenter;

        /// <summary>
        /// 入力された暗証番号
        /// </summary>
        private string[] _inputNum;

        /// <summary>
        /// パネル変更ボタン
        /// </summary>
        [SerializeField] ChangePanelButtonView _changePanelButtonView;

        /// <summary>
        /// 効果音の種類
        /// </summary>
        [SerializeField] private SEType _seId = SEType.None;

        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MVP.Presenters.BedRoomSafeGimmickPresenter();
            _inputNum = new string[_presenter.GetBedRoomSafeGimmickNum().Length];
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        /// <param name="num">左からnum番目のダイヤル</param>
        /// <param name="dialNum">ダイヤル番号</param>
        public void OnClick(int num, int dialNum)
        {
            if(_presenter.StockInputNum(_inputNum, num, dialNum.ToString()) != null)
            {
                Debug.Log("配列を格納できませんでした。エラー");
            }

            // ダイヤルが正解
            if(_presenter.checkUnlock(_presenter.GetBedRoomSafeGimmickNum(), _inputNum))
            {
                // ダイアル開錠音
                SoundManageView.GetInstance().PlaySE((int)_seId);
                Debug.Log("ダイヤル解除！！！");
            }
        }

        /// <summary>
        /// 鍵穴をクリック時
        /// </summary>
        public void OnKeyClick()
        {
            // ダイヤルが正解
            if(_presenter.checkUnlock(_presenter.GetBedRoomSafeGimmickNum(), Config.GetBedroomSafeDialNum()))
            {
                // 鍵で解除
                if(Config.GetItemStatus(ItemConstant.ITEM_KEYINICE_ID) == ItemConstant.ITEM_HAVE)
                {
                    // ギミックステータスのステータスを設定
                    _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                    // 寝室のステータスを変更
                    Config.SetBedroomStatus(GimmickConstant.BEDROOM_STATUS_SAFE_UNLOCK);
                    // 正解のSE
                    SoundManageView.GetInstance().PlaySE((int)_seId);
                    // パネル切り替え
                    _changePanelButtonView.Onclick();
                }
            }
        }
    }
}