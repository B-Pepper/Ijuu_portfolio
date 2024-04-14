using UnityEngine;
using UnityEngine.UI;
using MVP.Models;

namespace MVP.Presenters
{
    public class ToiletGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private ToiletGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ToiletGimmickPresenter()
        {
            _model = new ToiletGimmickModel();
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