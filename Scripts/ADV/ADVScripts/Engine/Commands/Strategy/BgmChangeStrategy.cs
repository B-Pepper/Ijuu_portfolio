using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MVP.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// BGM変更コマンドの実装クラス
    /// </summary>
    public class BgmChangeStrategy : CommandStrategy
    {
        /// <summary>
        /// BGMのID
        /// </summary>
        private int _id;

        /// <summary>
        /// ループ判定
        /// </summary>
        private bool _isLoop;

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
            
            _isLoop = true;
            if (args.Length == 3) {
                if (args[2] == "TRUE" || args[2] == "True" || args[2] == "true")
                {
                    _isLoop = true;
                }
                else {
                    _isLoop = false;
                }
            }
        }

        /// <summary>
        /// BGMを変更する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            SoundManageView.GetInstance().StopBGM();
            SoundManageView.GetInstance().PlayBGM(_id, _isLoop);
        }
    }
}