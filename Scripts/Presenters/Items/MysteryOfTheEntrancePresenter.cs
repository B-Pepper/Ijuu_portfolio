using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Presenters
{
    /// <summary>
    /// 玄関の謎のPresenter
    /// </summary>
    public class MysteryOfTheEntrancePresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.MysteryOfTheEntranceModel _model;

        public MysteryOfTheEntrancePresenter()
        {
            _model = new MVP.Models.MysteryOfTheEntranceModel();
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