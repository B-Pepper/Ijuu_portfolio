using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Presenters;
using MVP.Views;

namespace MVP.Views
{
    /// <summary>
    /// ゲーム全体データのセーブロードView
    /// </summary>
    public class GameDataSaverView
    {
        /// <summary>
        /// Presenterのインスタンス
        /// </summary>
        private GameDataSaverPresenter _gameDataSaverPresenter;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GameDataSaverView()
        {
            _gameDataSaverPresenter = new GameDataSaverPresenter();
        }

        /// <summary>
        /// ゲーム全体データのセーブ
        /// </summary>
        /// <returns></returns>
        public bool GameDataSave()
        {
            return _gameDataSaverPresenter.GameDataSave();
        }

        /// <summary>
        /// ゲーム全体データのロード
        /// </summary>
        /// <returns></returns>
        public bool GameDataLoad()
        {
            return _gameDataSaverPresenter.GameDataLoad();
        }
    }
}