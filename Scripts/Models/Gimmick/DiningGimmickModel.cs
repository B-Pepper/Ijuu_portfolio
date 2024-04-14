using UnityEngine;
using MVP.Models;

namespace MVP.Models
{
    public class DiningGimmickModel : BaseGimmickModel
    {
        /// <summary>
        /// 暗証番号で解除するギミックのクラスのインスタンス
        /// </summary>
        DialLockGimmickModel _dialLockGimmickModel;

        /// <summary>
        /// ギミック番号
        /// </summary>
        private int _gimmickId = 9;
        
        /// <summary>
        /// 玄関ギミックの暗証番号
        /// </summary>
        private static string[] _diningGimmickNum = {"7", "9", "6", "3", "1"};

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DiningGimmickModel()
        {
            _dialLockGimmickModel = new DialLockGimmickModel();
        }

        /// <summary>
        /// ギミック情報を初期化
        /// </summary>
        public override void InitGimmickInfo()
        {
            _gimmickId = GimmickConstant.GIMMICK_DINING_SAFE_ID;
            Debug.Log("gimmickId: "+ _gimmickId);
        }

        /// <summary>
        /// ギミック番号のゲッター
        /// </summary>
        /// <returns></returns>
        public override int GetGimmickID()
        {
            return _gimmickId;
        }

        /// <summary>
        /// 全ギミックステータスのゲッター
        /// </summary>
        /// <returns></returns>
        public override int[] GetAllGimmickStatus()
        {
            return Config.GetAllGimmickStatus();
        }

        /// <summary>
        /// ギミックステータスのゲッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <returns></returns>
        public override int GetGimmickStatus(int gimmickId)
        {
            return Config.GetGimmickStatus(gimmickId);
        }

        /// <summary>
        /// ギミックステータスのセッター
        /// </summary>
        /// <param name="gimmickId">ギミック番号</param>
        /// <param name="status">ステータス</param>
        public override void SetGimmickStatus(int gimmickId, int status)
        {
            Config.SetGimmickStatus(gimmickId, status);
        }
        
        /// <summary>
        /// 暗証番号のゲッター
        /// </summary>
        /// <returns></returns>
        public string[] GetDiningGimmickNum()
        {
            return _diningGimmickNum;
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
            return _dialLockGimmickModel.StockInputNum(inputNum, element, buttonNum);
        }

        /// <summary>
        /// 入力された暗証番号と正解番号を比較する
        /// </summary>
        /// <param name="trueNum">正解番号</param>
        /// <param name="inputNum">入力番号</param>
        /// <returns>解除時にtrue</returns>
        public bool checkUnlock(string[] trueNum, string[] inputNum)
        {
            return _dialLockGimmickModel.checkUnlock(trueNum, inputNum);
        }
    }
}