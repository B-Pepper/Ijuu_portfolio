using System;
using UnityEngine;
using UnityEngine.UI;
using HarapekoADV.Sounds;
using TMPro;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// コマンドの情報を保持、詳細の挙動を実行する
    /// </summary>
    public class Command
    {
        /// <summary>
        /// コマンドの種類 Enum/CommandType参照 
        /// </summary>
        private CommandType _commandType;
        public CommandType CommandType
        {
            get { return _commandType; }
        }
        public CommandStrategy _strategy;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="commandType">コマンドタイプ</param>
        /// <param name="strategy">ストラテジ</param>
        public Command(CommandType commandType, CommandStrategy strategy)
        {
            _commandType = commandType;
            _strategy = strategy;
        }

        /// <summary>
        /// ストラテジ毎の処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backgroundImage)
        {
            Debugger.Log("CMDTYPE : " + _commandType);
            _strategy.Act(text, charaName, characterImage, backgroundImage);
        }

        // 実行前に必要な変数などを用意できるようにしたい、StrategyでACTとそれを定義したInterfaceかな

    }
}