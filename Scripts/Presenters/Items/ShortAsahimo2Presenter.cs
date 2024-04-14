using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Presenters
{
    /// <summary>
    /// 麻紐(短)のPresenter
    /// </summary>
    public class ShortAsahimo2Presenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.ShortAsahimo2Model _model;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShortAsahimo2Presenter()
        {
            _model = new MVP.Models.ShortAsahimo2Model();
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