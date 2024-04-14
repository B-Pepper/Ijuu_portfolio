using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// ダイナマイトが着火されるギミックのPresenter
    /// </summary>
    public class IgnitionDynamiteGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private IgnitionDynamiteGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IgnitionDynamiteGimmickPresenter()
        {
            _model = new IgnitionDynamiteGimmickModel();
            // セットアップ
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
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public int GetGimmickStatus(int gimmickId)
        {
            return _model.GetGimmickStatus(gimmickId);
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