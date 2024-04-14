using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HarapekoADV;
using TMPro;

namespace MVP.Views
{
    /// <summary>
    /// クリアエンドを表示する機能View
    /// </summary>
    public class EndCgView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _endCgObject;

        [SerializeField] private Sprite[] _endCgSprite;

        [SerializeField] private TMP_Text[] _endCgText;

        /// <summary>
        /// エンド番号
        /// </summary>
        private const int END_NORMAL = 0;
        private const int END_NORMAL2 = 1;
        private const int END_SUICIDE = 2;
        private const int END_BOMB = 3;
        private const int END_BOMB2 = 4;
        private const int END_TRUE = 5;
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            // クリアエンドを判定し、画像変更
            foreach (string end in ADVConfig.GetGoalScenario())
            {
                switch (end)
                {
                    case "NormalEndText":
                        _endCgObject[END_NORMAL].GetComponent<Image>().sprite = _endCgSprite[0];
                        _endCgText[END_NORMAL].text = "";
                        break;
                    case "NormalSoukoEndText":
                        _endCgObject[END_NORMAL2].GetComponent<Image>().sprite = _endCgSprite[1];
                        _endCgText[END_NORMAL2].text = "";
                        break;
                    case "SuicideEndText":
                        _endCgObject[END_SUICIDE].GetComponent<Image>().sprite = _endCgSprite[2];
                        _endCgText[END_SUICIDE].text = "";
                        break;
                    case "BombEndText":
                        _endCgObject[END_BOMB].GetComponent<Image>().sprite = _endCgSprite[3];
                        _endCgText[END_BOMB].text = "";
                        break;
                    case "BombKitchenEndText":
                        _endCgObject[END_BOMB2].GetComponent<Image>().sprite = _endCgSprite[4];
                        _endCgText[END_BOMB2].text = "";
                        break;
                    case "TrueEndText":
                        _endCgObject[END_TRUE].GetComponent<Image>().sprite = _endCgSprite[5];
                        _endCgText[END_TRUE].text = "";
                        break;
                }
            }
        }
    }
}