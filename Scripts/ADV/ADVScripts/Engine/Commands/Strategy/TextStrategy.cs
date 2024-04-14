using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// テキスト変更ストラテジ
    /// </summary>
    public class TextStrategy : CommandStrategy
    {
        /// <summary>
        /// 表示するテキスト
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
            text.text = "";
            if (_args == null)
            {
                Debugger.Log("セットするテキストがありません");
            }

            for (int i = 0; i < _args.Length; i++)
            {
                text.text += _args[i];
            }
        }
    }
}