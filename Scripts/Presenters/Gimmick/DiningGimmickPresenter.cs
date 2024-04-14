using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// ダイニングの金庫ギミックのPresenter
    /// </summary>
    public class DiningGimmickPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private DiningGimmickModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DiningGimmickPresenter()
        {
            _model = new DiningGimmickModel();
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
        /// 暗証番号のゲッター
        /// </summary>
        /// <returns></returns>
        public string[] GetDiningGimmickNum()
        {
            return _model.GetDiningGimmickNum();
        }

        /// <summary>
        /// ダイヤルの番号を配列に格納するメソッド
        /// </summary>
        /// <param name="inputNum">格納する数字の文字列</param>
        /// <param name="element">要素の番号</param>
        /// <param name="buttonNum">入力された番号</param>
        /// <returns>格納成功時、配列の場所を返す</returns>
        public string[] StockInputNum(string[] inputNum, int element, string buttonNum)
        {
            return _model.StockInputNum(inputNum, element, buttonNum);
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
    }
}