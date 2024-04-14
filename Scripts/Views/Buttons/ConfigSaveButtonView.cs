using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVP.Views
{
    /// <summary>
    /// コンフィグ情報を保存するボタン
    /// </summary>
    public class ConfigSaveButtonView : MonoBehaviour
    {
        public void OnClick()
        {
            GameDataSaverView _gameDataSaverView = new GameDataSaverView();
            _gameDataSaverView.GameDataSave();
        }
    }
}