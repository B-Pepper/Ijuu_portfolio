using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HarapekoADV.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// シナリオ終了時のコマンド実装クラス
    /// </summary>
    public class EndStrategy : CommandStrategy
    {

        /// <summary>
        /// 読み込んだコマンドを取得
        /// </summary>
        /// <param name="args">文字列またはコマンド</param>
        public void Initialise(string[] args)
        {

        }

        /// <summary>
        /// ADV終了処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            Debugger.Log("おわりだよ～");
            // presenter.Sound.PlayBGM(false, true);
            // if (presenter.Parent.activeSelf)
            // {
            //     presenter.Parent.SetActive(false);
            // }
            // Modelを終了状態にできるようにPresenterあたりとなんやかんやできるようにしたい
        }
    }
}