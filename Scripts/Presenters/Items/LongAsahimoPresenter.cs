using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MVP.Presenters
{
    /// <summary>
    /// 麻紐(長)のPresenter
    /// </summary>
    public class LongAsahimoPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.LongAsahimoModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LongAsahimoPresenter()
        {
            _model = new MVP.Models.LongAsahimoModel();
            // アイテム情報のセットアップ
            _model.InitItemInfo();
        }

        /// <summary>
        /// アイテムIDのゲッター
        /// </summary>
        /// <returns>アイテムID</returns>
        public int GetItemID()
        {
            return _model.GetItemID();
        }

        /// <summary>
        /// アイテムステータスのゲッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        public int GetItemStatus(int itemId)
        {
            return _model.GetItemStatus(itemId);
        }

        /// <summary>
        /// アイテムステータスのセッター
        /// </summary>
        /// <param name="itemId">アイテム番号</param>
        /// <param name="status">ステータス</param>
        public void SetItemStatus(int itemId, int status)
        {
            _model.SetItemStatus(itemId, status);
        }
    }
}