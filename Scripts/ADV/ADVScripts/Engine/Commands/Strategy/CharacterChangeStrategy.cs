using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;
using HarapekoADV.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// 立ち絵変更ストラテジ
    /// </summary>
    public class CharacterChangeStrategy : CommandStrategy
    {
        /// <summary>
        /// ファイルパス
        /// </summary>
        private string _address;

        /// <summary>
        /// 変更する画像
        /// </summary>
        private Sprite _sprite;

        /// <summary>
        /// 読み込んだコマンドを取得
        /// </summary>
        /// <param name="args">文字列またはコマンド</param>
        public void Initialise(string[] args)
        {
            // 変更する画像のパスを取得
            _address = args[1];
        }

        /// <summary>
        /// 立ち絵を変更する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            if (_address == "none" || _address == "None" || _address == "")
            {
                _address = "None";
            }
            LoadImage(characterImage);
        }

        /// <summary>
        /// 画像をロード
        /// </summary>
        /// <param name="characterImage">キャラ立ち絵</param>
        private async void LoadImage(Image characterImage)
        {
            _sprite = await Addressables.LoadAssetAsync<Sprite>(_address).Task;
            Debug.Log("キャラ立ち絵ロード完了");

            if (_sprite != null)
            {
                characterImage.sprite = _sprite;
            }
            else 
            {
                Debugger.Log("セットする立ち絵画像がありません");
            }
        }
    }
}