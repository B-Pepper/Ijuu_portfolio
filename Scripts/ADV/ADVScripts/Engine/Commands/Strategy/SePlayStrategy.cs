using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MVP.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// SE再生コマンドの実装クラス
    /// </summary>
    public class SePlayStrategy : CommandStrategy
    {
        /// <summary>
        /// SEのID
        /// </summary>
        private int _id;

        /// <summary>
        /// 読み込んだコマンドを取得
        /// </summary>
        /// <param name="args">文字列またはコマンド</param>
        public void Initialise(string[] args)
        {
            try
            {
                _id = int.Parse(args[1]);
            }
            catch (System.Exception)
            {
                _id = 0;
                throw;
            }
        }

        /// <summary>
        /// SEを再生する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            SoundManageView.GetInstance().PlaySE(_id);
        }
    }
}