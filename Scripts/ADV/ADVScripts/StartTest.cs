using HarapekoADV.Scenarios;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;


namespace HarapekoADV
{
    /// <summary>
    /// デバッグ用、後に削除
    /// </summary>
    public class StartTest : MonoBehaviour, ADVNotifier
    {
        /// <summary>
        /// ファイルパス
        /// </summary>
        [SerializeField] private string _source;


        /// <summary>
        /// 開始
        /// </summary>
        void Start()
        {
            ADVStart();
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        public async void ADVStart()
        {
            ScenarioAnalyser analyser = new ScenarioAnalyser();
            var neko = analyser.TextFileLoad(_source);
            TextAsset asset = null;
            while(await neko.MoveNextAsync())
            {
                // ここでなにかおきる
                asset = neko.Current;
            }
            Debug.Log("ファイルの中身: " + asset);
            Scenario scenario = analyser.Create();
            
            ADVPresenter adv = ADVPresenter.GetInstance();
        }


        /// <summary>
        /// ADV開始時通知メソッド
        /// </summary>
        public void NotifyADVStart()
        {
            Debugger.Log("Start");
        }

        /// <summary>
        /// ADV終了時通知メソッド
        /// </summary>
        public void NotifyADVFinish()
        {
            Debugger.Log("Finish");
        }
    }
}
