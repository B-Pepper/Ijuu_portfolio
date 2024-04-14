using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;

namespace MVP.Views
{
    /// <summary>
    /// 治療薬のView
    /// </summary>
    public class MedicineView : MonoBehaviour
    {
        /// <summary>
        /// アイテム画像
        /// </summary>
        [SerializeField] GameObject _itemImage;
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MedicinePresenter _presenter;
        // Start is called before the first frame update
        void Awake()
        {
            _presenter = new MedicinePresenter();
            if (Config.GetItemStatus(_presenter.GetItemID()) > ItemConstant.ITEM_DEFAULT)
            {
                _itemImage.SetActive(false);
                return;
            }
            if (Config.GetGimmickStatus(GimmickConstant.GIMMICK_SOUKO_SAFE_ID) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _itemImage.SetActive(true);                
            }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // アイテムのステータスを設定
            _presenter.SetItemStatus(_presenter.GetItemID(), ItemConstant.ITEM_GET);
            // アイテムの画像を非表示にする
            Debug.Log("itemImage => FALSE");
            _itemImage.SetActive(false);
        }
    }
}