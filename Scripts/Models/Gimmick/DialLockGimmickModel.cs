using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Models
{
    public class DialLockGimmickModel
    {
        /// <summary>
        /// ダイヤルの番号を配列に格納するメソッド
        /// </summary>
        /// <param name="inputNum">格納する数字の文字列</param>
        /// <param name="element">要素の番号</param>
        /// <param name="buttonNum">入力された番号</param>
        /// <returns>格納成功時、配列の場所を返す</returns>
        public string[] StockInputNum(string[] inputNum, int element, string buttonNum)
        {
            inputNum[element] = buttonNum;
            return inputNum;
        }
        
        /// <summary>
        /// ダイヤルの番号を正解の番号と比較するメソッド
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
    }
}