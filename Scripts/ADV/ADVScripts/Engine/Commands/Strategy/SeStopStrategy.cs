using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MVP.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// SE停止コマンドの実装クラス
    /// </summary>
    public class SeStopStrategy : CommandStrategy
    {
        /// <summary>
        /// 読み込んだコマンドを取得
        /// </summary>
        /// <param name="args">文字列またはコマンド</param>
        public void Initialise(string[] args)
        {
        }

        /// <summary>
        /// SEを停止する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            SoundManageView.GetInstance().StopSE();
        }
    }
}