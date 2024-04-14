using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// コマンドエラー時の挙動実装クラス
    /// </summary>
    public class ErrorStrategy : CommandStrategy
    {
        /// <summary>
        /// コマンド文字列配列
        /// </summary>
        private string[] _args;

        /// <summary>
        /// 読み込んだコマンドを取得
        /// </summary>
        /// <param name="args">文字列またはコマンド</param>
        public void Initialise(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// 立ち絵を変更する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            Debugger.Err(_args[0]);
        }
    }
}