using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Models;

namespace MVP.Presenters
{
    /// <summary>
    /// ゲーム全体データのセーブロードPresenter
    /// </summary>
    public class GameDataSaverPresenter
    {
        /// <summary>
        /// modelのインスタンス
        /// </summary>
        private GameDataSaverModel _gameDataSaverModel;

        public GameDataSaverPresenter()
        {
            _gameDataSaverModel = new GameDataSaverModel();
        }

        /// <summary>
        /// ゲーム全体のデータのセーブ
        /// </summary>
        /// <returns></returns>
        public bool GameDataSave()
        {
            return _gameDataSaverModel.GameDataSave();
        }

        /// <summary>
        /// ゲーム全体のデータのロード
        /// </summary>
        /// <returns></returns>
        public bool GameDataLoad()
        {
            return _gameDataSaverModel.GameDataLoad();
        }
    }
}