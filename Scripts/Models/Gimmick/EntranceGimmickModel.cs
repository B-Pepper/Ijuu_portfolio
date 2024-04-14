using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// 玄関ギミックのModel
    /// </summary>
    public class EntranceGimmickModel : BaseGimmickModel
    {
        /// <summary>
        /// 暗証番号で解除するギミックのクラスのインスタンス
        /// </summary>
        PasswordLockGimmickModel _passwordLockGimmickModel;

        /// <summary>
        /// ギミック番号
        /// </summary>
        private int _gimmickId = 1;
        
        /// <summary>
        /// 玄関ギミックの暗証番号
        /// </summary>
        private static string[] _entranceGimmickNum = {"*", "*", "*", "*"};

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EntranceGimmickModel()
        {
            _passwordLockGimmickModel = new PasswordLockGimmickModel();
        }

        /// <summary>
        /// ギミック情報を初期化
        /// </summary>
        public override void InitGimmickInfo()
        {
            _gimmickId = GimmickConstant.GIMMICK_ENTRANCE_ID;
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
        public string[] GetEntranceGimmickNum()
        {
            return _entranceGimmickNum;
        }

        /// <summary>
        /// 入力された番号を格納する
        /// </summary>
        /// <param name="inputNum">格納する変数</param>
        /// <param name="buttonNum">入力された番号(ボタン)</param>
        /// <returns>格納成功時、配列の場所を返す</returns>
        public int StockInputNum(string[] inputNum, string buttonNum)
        {
            return _passwordLockGimmickModel.StockInputNum(inputNum, buttonNum);
        }

        /// <summary>
        /// 入力された暗証番号と正解番号を比較する
        /// </summary>
        /// <param name="trueNum">正解番号</param>
        /// <param name="inputNum">入力番号</param>
        /// <returns>解除時にtrue</returns>
        public bool checkUnlock(string[] trueNum, string[] inputNum)
        {
            return _passwordLockGimmickModel.checkUnlock(trueNum, inputNum);
        }

        /// <summary>
        /// 格納する配列をnullにする
        /// </summary>
        /// <param name="inputNum">入力された番号の配列</param>
        /// <returns>nullになった時true</returns>
        public bool initInputNum(string[] inputNum)
        {
            return _passwordLockGimmickModel.initInputNum(inputNum);
        }
    }
}