using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using TMPro;
using HarapekoADV.Sounds;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// 背景変更ストラテジ
    /// </summary>
    public class BackgroundChangeStrategy : CommandStrategy
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
        /// 背景を変更する
        /// </summary>
        /// <param name="text">テキスト</param>
        /// <param name="charaName">キャラ名</param>
        /// <param name="characterImage">立ち絵画像</param>
        /// <param name="backImage">背景画像</param>
        public void Act(TMP_Text text, TMP_Text charaName, Image characterImage, Image backImage)
        {
            LoadImage(backImage);
        }

        /// <summary>
        /// 画像をロード
        /// </summary>
        /// <param name="backImage">背景画像</param>
        /// <returns></returns>
        private async void LoadImage(Image backImage)
        {
            _sprite = await Addressables.LoadAssetAsync<Sprite>(_address).Task;
            Debug.Log("背景画像ロード完了");

            if (_sprite != null)
            {
                backImage.sprite = _sprite;
                Debug.Log("背景画像切り替え");
            } 
            else 
            {
                Debugger.Log("セットする背景画像がありません");
            }
        }

    }
}
