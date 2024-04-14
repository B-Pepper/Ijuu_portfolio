using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Presenters
{
    /// <summary>
    /// 倉庫の謎のPresenter
    /// </summary>
    public class MysteryOfSoukoPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.MysteryOfSoukoModel _model;

        public MysteryOfSoukoPresenter()
        {
            _model = new MVP.Models.MysteryOfSoukoModel();
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