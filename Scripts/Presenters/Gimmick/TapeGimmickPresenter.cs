using UnityEngine;
using UnityEngine.UI;

namespace MVP.Presenters
{
    /// <summary>
    /// 玄関ギミックを実行可能にするギミックのPresenter
    /// </summary>
    public class TapeGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.TapeGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TapeGimmickPresenter()
        {
            _model = new MVP.Models.TapeGimmickModel();
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