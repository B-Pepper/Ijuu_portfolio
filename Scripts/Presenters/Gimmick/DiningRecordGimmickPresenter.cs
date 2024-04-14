using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// 台所のレコードのPresenter
    /// </summary>
    public class DiningRecordGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private DiningRecordGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DiningRecordGimmickPresenter()
        {
            _model = new DiningRecordGimmickModel();
            // セットアップ
            _model.InitGimmickInfo();
        }

        /// <summary>
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public int GetGimmickStatus(int gimmickId)
        {
            return _model.GetGimmickStatus(gimmickId);
        }
    }
}