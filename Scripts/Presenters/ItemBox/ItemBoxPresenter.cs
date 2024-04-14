using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MVP.Models;

namespace MVP.Presenters
{
    public class ItemBoxPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private ItemBoxModel _model;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ItemBoxPresenter()
        {
            _model = new ItemBoxModel();
            // 選択アイテムステータス情報の初期化
            _model.InitSelectItem();
        }

        /// <summary>
        /// 選択アイテムステータス情報の初期化
        /// </summary>
        public void InitSelectItem()
        {
            _model.InitSelectItem();
        }
        
        /// <summary>
        /// アイテム所持しており、使用可能であるかの判定
        /// </summary>
        /// <param name="itemNum">アイテム番号</param>
        public bool IsExistItemBox(int itemNum)
        {
            return _model.IsExistItemBox(itemNum);
        }

        /// <summary>
        /// アイテムを所持しており、利用不可能であるかの判定
        /// </summary>
        /// <param name="itemNum"></param>
        /// <returns></returns>
        public bool IsExistCannotUseItem(int itemNum)
        {
            return _model.IsExistCannotUseItem(itemNum);
        }
    }
}
