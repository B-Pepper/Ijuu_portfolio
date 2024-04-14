using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HarapekoADV;
using System;

namespace MVP.Views
{
    /// <summary>
    /// CGクリック時拡大表示ボタン
    /// </summary>
    public class CgButtonView : MonoBehaviour
    {
        /// <summary>
        /// 拡大画像
        /// </summary>
        [SerializeField] GameObject _expansionImage;

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
        /// 画像を表示
        /// </summary>
        public void OnDisplayClick(int selectEnd)
        {
            if (isDisplayExpansionEnd(selectEnd) == selectEnd)
            {
                _expansionImage.SetActive(true);
            }
        }

        /// <summary>
        /// 画像を非表示
        /// </summary>
        public void OnHiddenClick()
        {
            _expansionImage.SetActive(false);
        }

        /// <summary>
        /// エンドを表示可能か
        /// </summary>
        /// <returns></returns>
        public int isDisplayExpansionEnd(int selectEnd)
        {
            switch (selectEnd)
                {
                    case END_NORMAL:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "NormalEndText")>= 0)
                        {
                            return END_NORMAL;
                        }
                        break;
                    case END_NORMAL2:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "NormalSoukoEndText")>= 0)
                        {
                            return END_NORMAL2;
                        }
                        break;
                    case END_SUICIDE:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "SuicideEndText")>= 0)
                        {
                            return END_SUICIDE; 
                        }
                        break;
                    case END_BOMB:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "BombEndText")>= 0)
                        {
                            return END_BOMB;
                        }
                        break;
                    case END_BOMB2:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "BombKitchenEndText")>= 0)
                        {
                            return END_BOMB2;
                        }
                        break;
                    case END_TRUE:
                        if (Array.IndexOf(ADVConfig.GetGoalScenario(), "TrueEndText")>= 0)
                        {
                            return END_TRUE;
                        }
                        break;
                }
            return -1;
        }
    }
}