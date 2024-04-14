using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Presenters
{
    /// <summary>
    /// 倉庫の扉ギミックのPresenter
    /// </summary>
    public class SoukoDoorGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private MVP.Models.SoukoDoorGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SoukoDoorGimmickPresenter()
        {
            _model = new MVP.Models.SoukoDoorGimmickModel();
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
        /// 暗証番号のゲッター
        /// </summary>
        /// <returns></returns>
        public string[] GetSoukoDoorGimmickNum()
        {
            return _model.GetSoukoDoorGimmickNum();
        }

        /// <summary>
        /// 入力された番号を格納する
        /// </summary>
        /// <param name="inputNum">格納する変数</param>
        /// <param name="buttonNum">入力された番号(ボタン)</param>
        /// <returns>格納成功時、配列の場所を返す</returns>
        public int StockInputNum(string[] inputNum, string buttonNum)
        {
            return _model.StockInputNum(inputNum, buttonNum);
        }

        /// <summary>
        /// 入力された暗証番号と正解番号を比較する
        /// </summary>
        /// <param name="trueNum">正解番号</param>
        /// <param name="inputNum">入力番号</param>
        /// <returns>解除時にtrue</returns>
        public bool checkUnlock(string[] trueNum, string[] inputNum)
        {
            return _model.checkUnlock(trueNum, inputNum);
        }

        /// <summary>
        /// 格納する配列をnullにする
        /// </summary>
        /// <param name="inputNum">入力された番号の配列</param>
        /// <returns>nullになった時true</returns>
        public bool initInputNum(string[] inputNum)
        {
            return _model.initInputNum(inputNum);
        }
    }
}