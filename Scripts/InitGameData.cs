using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVP.Presenters;

public class InitGameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ゲーム全体データのロード
        GameDataSaverPresenter gameDataSaverPresenter = new GameDataSaverPresenter();
        gameDataSaverPresenter.GameDataLoad();
    }
}
