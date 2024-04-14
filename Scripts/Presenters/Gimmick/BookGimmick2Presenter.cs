using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Presenters
{
    /// <summary>
    /// 本ギミックのPresenter
    /// </summary>
    public class BookGimmick2Presenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.BookGimmick2Model _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BookGimmick2Presenter()
        {
            _model = new MVP.Models.BookGimmick2Model();
            // アイテム情報のセットアップ
            _model.InitGimmickInfo();
        }

        /// <summary>
        /// ギミックIDのゲッター
        /// </summary>
        /// <returns></returns>
        public int GetGimmickID()
        {
            return _model.GetGimmickID();
        }

        /// <summary>
        /// ギミックステータスのセッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <param name="status">ステータス</param>
        public void SetGimmickStatus(int gimmickId, int status)
        {
            _model.SetGimmickStatus(gimmickId, status);
        }
    }
}