using System;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Views;
using TMPro;

namespace MVP.Views
{
    /// <summary>
    /// ダイナマイト着火時に残り移動回数を表示するView
    /// </summary>
    public class RemainingStepsView : MonoBehaviour
    {
        /// <summary>
        /// Viewのインスタンス
        /// </summary>
        private static RemainingStepsView _instance;

        /// <summary>
        /// 残り移動回数
        /// </summary>
        private int _remainStepsNum = 0;

        /// <summary>
        /// 残り移動回数テキスト
        /// </summary>
        [SerializeField] private TMP_Text _remainStepsText;

        // /// <summary>
        // /// 初期設定
        // /// </summary>
        // private void Awake()
        // {
        //     if (_instance == null)
        //     {
        //         _instance = this;
        //         DontDestroyOnLoad(gameObject);
        //     }
        //     else
        //     {
        //         Destroy(gameObject);
        //     }
        // }

        // /// <summary>
        // /// インスタンスの取得
        // /// </summary>
        // /// <returns>インスタンス</returns>
        // public static RemainingStepsView GetInstance()
        // {
        //     return _instance;
        // }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            _remainStepsNum = GimmickConstant.REMAIN_STEPS_NUM;
            DisplayNum(_remainStepsNum);
        }

        /// <summary>
        /// 呼び出される都度、移動回数を-1
        /// </summary>
        public void MoveCounter()
        {
            if (_remainStepsNum == 0)
            {
                Debug.Log("残り移動回数: 0");
                HiddenNum();
            }
            else
            {
                _remainStepsNum--;
                DisplayNum(_remainStepsNum);
            }
        }

        /// <summary>
        /// 残り移動回数を更新
        /// </summary>
        private void DisplayNum(int stepsNum)
        {
            _remainStepsText.text = stepsNum.ToString();
        }

        /// <summary>
        /// 残り移動回数を非表示
        /// </summary>
        private void HiddenNum()
        {
            // カウント非表示
            _remainStepsText.text = "";
        }

        /// <summary>
        /// 残り移動回数のゲッター
        /// </summary>
        /// <returns>残り移動回数</returns>
        private int GetRemainStepsNum()
        {
            return _remainStepsNum;
        }
    }
}