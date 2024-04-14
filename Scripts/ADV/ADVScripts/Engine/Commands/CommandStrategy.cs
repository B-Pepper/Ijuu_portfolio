using UnityEngine.UI;
using HarapekoADV.Sounds;
using TMPro;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// ストラテジ系のインターフェース
    /// </summary>
    public interface CommandStrategy
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="args"></param>
        void Initialise(string[] args);

        /// <summary>
        /// ストラテジ毎の処理
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backgroundImage">背景画像</param>
        void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backgroundImage);
    }
}