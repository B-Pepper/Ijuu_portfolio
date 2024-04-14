using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;


namespace MVP.Views
{
    /// <summary>
    /// 本ギミックのView
    /// </summary>
    public class BookGimmick1View : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private MVP.Presenters.BookGimmick1Presenter _presenter;

        /// <summary>
        /// 麻紐のViewをアタッチしたGameObject
        /// </summary>
        [SerializeField] GameObject _shortAsahimoView;

        /// <summary>
        /// 本のGameObject
        /// </summary>
        [SerializeField] GameObject _bookGimmickView;

        /// <summary>
        /// 変更する画像
        /// </summary>
        [SerializeField] Sprite _changeImage;

        /// <summary>
        /// 開いた本の中身
        /// </summary>
        [SerializeField] GameObject _openBook;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
             _presenter = new BookGimmick1Presenter();

             if (Config.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
             {
                _bookGimmickView.GetComponent<Image>().sprite = _changeImage;
             }
        }

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // ハサミが選択状態であるか
            if(Config.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_LOCK
                && Config.GetItemStatus(ItemConstant.ITEM_SCISSORS_ID) == ItemConstant.ITEM_HAVE)
            {
                // ギミックステータスのステータスを設定
                _presenter.SetGimmickStatus(_presenter.GetGimmickID(), GimmickConstant.GIMMICK_UNLOCK);
                // カットSE再生
                SoundManageView.GetInstance().PlaySE((int)SEType.ScissorsCutting);
                // 本の画像変更
                _bookGimmickView.GetComponent<Image>().sprite = _changeImage;
                // 麻紐を表示
                _shortAsahimoView.SetActive(true);
            }
            if (Config.GetGimmickStatus(_presenter.GetGimmickID()) == GimmickConstant.GIMMICK_UNLOCK)
            {
                _openBook.SetActive(true);
            }
        }
    }
}
