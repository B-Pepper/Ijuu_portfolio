using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Threading.Tasks;
using TMPro;

namespace MVP.Views
{
    /// <summary>
    /// ダイアログを表示するView
    /// </summary>
    public class DialogView : MonoBehaviour
    {
        /// <summary>
        /// インスタンス格納フィールド変数
        /// </summary>
        private static DialogView _instance;

        /// <summary>
        /// テキストボックス
        /// </summary>
        [SerializeField] private GameObject _textBox;

        /// <summary>
        /// ダイアログのテキスト表示
        /// </summary>
        [SerializeField] private TMP_Text _dialogText;

        /// <summary>
        /// ダイアログの画像表示
        /// </summary>
        [SerializeField] private Image _dialogImage;

        /// <summary>
        /// 次に変更する画像
        /// </summary>
        private Sprite _loadImageSprite;

        /// <summary>
        /// テキストの加工前の一行を入れる変数
        /// </summary>
        public string[] _textMessage;

        /// <summary>
        /// テキストの複数列を入れる2次元は配列 
        /// 1つ目の配列に 画像パス
        /// 2つ目の配列に 表示テキスト
        /// </summary>
        public string[,] _textWords;

        /// <summary>
        /// テキスト内の行数を取得する変数
        /// </summary>
        private int _rowLength;

        /// <summary>
        /// テキスト内の列数を取得する変数
        /// </summary>
        private int _columnLength;

        /// <summary>
        /// 現在表示する行
        /// 2行目からを初期値とする
        /// </summary>
        private int _currentRow = 1;

        /// <summary>
        /// 初期設定
        /// </summary>
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// インスタンスの取得
        /// </summary>
        /// <returns>インスタンス</returns>
        public static DialogView GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// 画面クリック時
        /// </summary>
        public void OnClick()
        {
            // ダイアログを開いている場合
            if(Config.GetIsOpenDialog())
            {
                // 最大行以下の場合
                if (_currentRow < _rowLength)
                {
                    SetDialogImage(_textWords[_currentRow, 0]);
                    SetDialogText(_textWords[_currentRow, 1]);
                    _currentRow++;
                }
                // 最大行の場合
                if (_currentRow == _rowLength)
                {
                    // ダイアログを非表示
                    DisActiveDialog();
                }
            }
        }

        /// <summary>
        /// ダイアログを表示
        /// 基本的に外から呼び出す
        /// </summary>
        public void ActiveDialog(string textFilePath)
        {
            // フラグ設定
            Config.SetIsOpenDialog(true);
            // テキストファイルを読み込み
            LoadTextFile(textFilePath);
            // テキストボックスを表示
            _textBox.SetActive(true);
            // 最初の行を表示
            SetDialogImage(_textWords[0, 0]);
            SetDialogText(_textWords[0, 1]);
        }

        /// <summary>
        /// ダイアログを非表示
        /// </summary>
        public void DisActiveDialog()
        {
            // フラグ設定
            Config.SetIsOpenDialog(false);
            // テキストボックスを非表示
            _textBox.SetActive(false);
            // ダイアログの画像を非表示
            _dialogImage.sprite = null;
            // ダイアログのテキストを非表示
            _dialogText.text = "";
        }

        /// <summary>
        /// テキストを更新
        /// </summary>
        /// <param name="text">表示テキスト</param>
        public void SetDialogText(string text)
        {
            _dialogText.text = text;
        }

        /// <summary>
        /// 画像を変更
        /// </summary>
        /// <param name="loadImagePath">変更画像のパス</param>
        /// <returns></returns>
        private async void SetDialogImage(string loadImagePath)
        {
            _loadImageSprite = await Addressables.LoadAssetAsync<Sprite>(loadImagePath).Task;
            Debug.Log("ダイアログ画像ロード完了");

            if (_loadImageSprite != null)
            {
                _dialogImage.sprite = _loadImageSprite;
                Debug.Log("ダイアログ画像切り替え");
            } 
            else 
            {
                Debug.Log("セットするダイアログ画像がありません");
            }
        }

        /// <summary>
        /// テキストを読み込み
        /// _textWords[0, 0] : 画像パス
        /// _textWords[0, 1] : 表示テキスト
        /// </summary>
        /// <param name="loadTextFilePath">読み込むテキストファイルのパス</param>
        /// <returns>表示するテキスト</returns>
        private async void LoadTextFile(string loadTextFilePath)
        {
            //テキストファイルのデータを取得するインスタンスを作成
            TextAsset textasset = new TextAsset();
            //Resourcesフォルダから対象テキストを取得
            textasset = await Addressables.LoadAssetAsync<TextAsset>(loadTextFilePath).Task;
            //テキスト全体をstring型で入れる変数を用意して入れる
            string TextLines = textasset.text;
            //Splitで一行づつを代入した1次配列を作成、フィールドに格納
            _textMessage = TextLines.Split('\n');

            //行数と列数を取得
            _columnLength = _textMessage[0].Split('\t').Length;
            _rowLength = _textMessage.Length;

            //2次配列を定義
            _textWords = new string[_rowLength, _columnLength];

            for(int i = 0; i < _rowLength; i++)
            {
                //textMessageをタブ文字ごとに分けたものを一時的にtempWordsに代入
                string[] _tempWords = _textMessage[i].Split('\t');

                for (int n = 0; n < _columnLength; n++)
                {
                    //2次配列textWordsにタブ文字ごとに分けたtempWordsを代入していく
                    _textWords[i, n] = _tempWords[n];
                    Debug.Log(i + "行目 " + n + "列目 " + _textWords[i, n]);
                }
            }
        }
    }
}