using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Presenters
{
    public class SoukoSafeGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.SoukoSafeGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SoukoSafeGimmickPresenter()
        {
            _model = new MVP.Models.SoukoSafeGimmickModel();
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
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns>ギミックステータス</returns>
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