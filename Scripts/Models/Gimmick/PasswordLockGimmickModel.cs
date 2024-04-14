using UnityEngine;

namespace MVP.Models
{
    /// <summary>
    /// 暗証番号で解除するギミックのmodel
    /// </summary>
    public class PasswordLockGimmickModel
    {
        /// <summary>
        /// 入力された番号を格納する
        /// </summary>
        /// <param name="inputNum">格納する変数</param>
        /// <param name="buttonNum">入力された番号(ボタン)</param>
        /// <returns>格納成功時、配列の場所を返す</returns>
        public int StockInputNum(string[] inputNum, string buttonNum)
        {
            // 格納する変数の長さを越えて、入力されてもその値は格納されない
            for (int i = 0; i < inputNum.Length; i++)
            {
                if (inputNum[i] == null)
                {
                    inputNum[i] = buttonNum;
                    return i;
                }
            }
            return -1;
        }
        

        /// <summary>
        /// 入力された暗証番号と正解番号を比較する
        /// </summary>
        /// <param name="trueNum">正解番号</param>
        /// <param name="inputNum">入力番号</param>
        /// <returns>解除時にtrue</returns>
        public bool checkUnlock(string[] trueNum ,string[] inputNum)
        {
            // 番号の長さが違う時
            if (trueNum.Length != inputNum.Length)
            {
                return false;
            }

            // 正解時にカウントが加算
            int trueCount = 0;
            for (int i = 0; i < trueNum.Length; i++)
            {
                if (trueNum[i] == inputNum[i])
                {
                    trueCount++;
                    if (trueCount == trueNum.Length)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 格納する配列をnullにする
        /// </summary>
        /// <param name="inputNum">入力された番号の配列</param>
        /// <returns>nullになった時true</returns>
        public bool initInputNum(string[] inputNum)
        {
            for (int i = 0; i < inputNum.Length; i++)
            {
                inputNum[i] = null;
            }

            if (inputNum == null)
            {
                return true;
            }
            return false;
        }
    }
}