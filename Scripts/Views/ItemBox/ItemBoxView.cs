using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// アイテムボックス管理クラスのView
    /// </summary>
    public class ItemBoxView : MonoBehaviour
    {
        /// <summary>
        /// presenterのインスタンス
        /// </summary>
        private ItemBoxPresenter _presenter;

        /// <summary>
        /// 画像変更クラスのインスタンス
        /// </summary>
        private ChangeImageView _changeImageView;

        /// <summary>
        /// アイテムボックス内に表示するGameObject
        /// </summary>
        [SerializeField] private GameObject[] _itemsInItemBox;
        
        /// <summary>
        /// 選択アイテム画像
        /// </summary>
        [SerializeField] private GameObject _selectItemImage;

        /// <summary>
        /// 選択アイテム表示ボタン
        /// </summary>
        [SerializeField] private GameObject _selectItemImageButton;

        /// <summary>
        /// 拡大画像
        /// </summary>
        [SerializeField] private GameObject _expansionImage;
        
        /// <summary>
        /// 選択アイテム説明文
        /// </summary>
        [SerializeField] private TMP_Text _displayText;

        /// <summary>
        /// デフォルト画像
        /// </summary>
        [SerializeField] private Sprite _defaultImage;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            _presenter = new ItemBoxPresenter();
        }

        /// <summary>
        /// 選択アイテムステータス情報の初期化
        /// </summary>
        private void InitSelectItem()
        {
            _presenter.InitSelectItem();
        }

        /// <summary>
        /// 起動時に実行
        /// </summary>
        private void OnEnable()
        {
            UpdateItemBox();
        }

        /// <summary>
        /// アイテムボックスのアイテムをクリックした時
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        public void OnClick(int itemNum)
        {
            // 選択アイテムステータスを初期化
            InitSelectItem();
            // 画像をセット
            SetSelectItemImage(itemNum);
            // テキストをセット
            DisplayText(itemNum);
            // ITEM_GETの時
            if (IsExistItemBox(itemNum))
            {
                // ステータスをセット
                Config.SetItemStatus(itemNum, ItemConstant.ITEM_HAVE);
            }
        }

        /// <summary>
        /// アイテムボックスを更新
        /// </summary>
        private void UpdateItemBox()
        {
            // 選択アイテムステータスを初期化
            InitSelectItem();
            
            int[] allItemStatus = Config.GetAllItemStatus();
            for (int i = 0; i < allItemStatus.Length; i++)
            {
                if (allItemStatus[i] == ItemConstant.ITEM_GET
                || allItemStatus[i] == ItemConstant.ITEM_CANT_USE
                || allItemStatus[i] == ItemConstant.ITEM_HAVE)
                {
                    Debug.Log(Config.GetItemName(i) + ":" + Config.GetItemStatus(i));
                    OnDisplayItemImage(i);
                }
                else
                {
                    OffDisplayItemImage(i);
                }
            }
            for (int i = 0; i < allItemStatus.Length; i++)
            {
                if (allItemStatus[i] == ItemConstant.ITEM_HAVE)
                {
                    SetSelectItemImage(i);
                    DisplayText(i);
                }
                else
                {
                    InitSelectItemImage();
                    InitText();
                }
            }
            Debug.Log("アイテムボックス更新完了");
        }

        /// <summary>
        /// アイテムの画像を選択アイテム画像にセットする
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        private void SetSelectItemImage(int itemNum)
        {
            _selectItemImage.GetComponent<Image>().sprite = _itemsInItemBox[itemNum].GetComponent<Image>().sprite;
            _selectItemImageButton.GetComponent<Image>().sprite = _itemsInItemBox[itemNum].GetComponent<Image>().sprite;
            _expansionImage.GetComponent<Image>().sprite = _itemsInItemBox[itemNum].GetComponent<Image>().sprite;
        }

        /// <summary>
        /// 選択アイテム画像初期化
        /// </summary>
        private void InitSelectItemImage()
        {
            _selectItemImage.GetComponent<Image>().sprite = _defaultImage;
            _selectItemImageButton.GetComponent<Image>().sprite = _defaultImage;
            _expansionImage.GetComponent<Image>().sprite = _defaultImage;
        }

        /// <summary>
        /// 指定の画像を表示
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        private void OnDisplayItemImage(int itemNum)
        {
            _itemsInItemBox[itemNum].SetActive(true);
        }

        /// <summary>
        /// 指定の画像を非表示
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        private void OffDisplayItemImage(int itemNum)
        {
            Debug.Log("アイテム番号：" + itemNum);
            _itemsInItemBox[itemNum].SetActive(false);
        }

        /// <summary>
        /// テキストを表示する
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        private void DisplayText(int itemNum)
        {
            _displayText.text = Config.GetItemExplain(itemNum);
        }

        /// <summary>
        /// テキストを初期化
        /// </summary>
        private void InitText()
        {
            _displayText.text = "";
        }

        /// <summary>
        /// アイテム所持しており、使用可能であるかの判定
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        private bool IsExistItemBox(int itemNum)
        {
            return _presenter.IsExistItemBox(itemNum);
        }

        /// <summary>
        /// アイテムを所持しており、利用不可能であるかの判定
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        /// <returns></returns>
        private bool IsExistCannotUseItem(int itemNum)
        {
            return _presenter.IsExistCannotUseItem(itemNum);
        }

        /// <summary>
        /// マップテキストのゲッター(map用)
        /// </summary>
        /// <returns>マップテキスト</returns>
        public string GetMapText()
        {
            return _displayText.text;
        }

        /// <summary>
        /// マップテキストのセッター(map用)
        /// </summary>
        /// <param name="setText">セットテキスト</param>
        public void SetMapText(string setText)
        {
            _displayText.text = setText;
        }

        /// <summary>
        /// マップ画像のゲッター(map用)
        /// </summary>
        /// <returns>マップ画像</returns>
        public Image GetMapImage()
        {
            return _selectItemImage.GetComponent<Image>();
        }

        /// <summary>
        /// マップ画像のセッター(map用)
        /// </summary>
        /// <param name="setImage">セット画像</param>
        public void SetMapImage(Sprite setImage)
        {
            _selectItemImage.GetComponent<Image>().sprite = setImage;
        }

        /// <summary>
        /// 拡大画像のセッター(map用)
        /// </summary>
        /// <param name="setImage">セット画像</param>
        public void SetExpansionImage(Sprite setImage)
        {
            _expansionImage.GetComponent<Image>().sprite = setImage;
        }
    }
}