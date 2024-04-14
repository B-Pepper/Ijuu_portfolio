using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HarapekoADV.Scenarios
{
    public enum LoadStatus
    {
        Loading,
        Complete,
        End,
        Error
    }
    
    /// <summary>
    /// シナリオ本文を読解して
    /// 構造として持つScenarioにフォーマット化
    /// </summary>
    public class ScenarioAnalyser
    {
        /// <summary> 
        /// シナリオコンポーネント用のカウンタ
        /// </summary>
        private int _count;
        /// <summary>
        /// シナリオコンポーネントIDを格納する変数
        /// </summary>
        private List<string> _idList;

        /// <summary>
        /// 読み込むシナリオファイル
        /// </summary>
        private TextAsset scenarioFile;

        /// <summary>
        /// アドレスから任意のテキストデータを読み込み、
        /// コンポーネント化したシナリオデータを返す
        /// </summary>
        /// <param name="_address">シナリオのアドレス</param>
        /// <returns>コンポーネント化したシナリオデータ</returns>
        public Scenario Create()
        {
            Scenario scenario = new Scenario();
            _count = 0;
            _idList = new List<string>();

            string[] texts = DevideAsset(scenarioFile);
            
            foreach (string text in texts)
            {
                ScenarioComponent scenarioComponent = CreateComponent(text);
                scenario.Add(scenarioComponent);
            }
            scenario.SetFirstID("1");
            Debugger.Log("Load completed");

            return scenario;
        }

        public async IAsyncEnumerator<TextAsset> TextFileLoad(string _address)
        {
            scenarioFile = await AssetLoader.LoadAsync<TextAsset>(_address);
            yield return scenarioFile;
        }

        /// <summary>
        /// 1ライン分割済みシナリオテキストから
        /// コンポーネントの作成
        /// </summary>
        /// <param name="text">シナリオテキスト</param>
        /// <returns>コンポーネント</returns>
        private ScenarioComponent CreateComponent(string text)
        {
            ScenarioComponent component = null;
            _count += 1;
            string id = _count.ToString();
            while (_idList.Contains(id))
            {
                _count += 1;
                id = _count.ToString();
            }
            _idList.Add(id);

            // シナリオ終了のコンポーネント化
            if (text == "@[EOF]")
            {
                component = ScenarioComponentFactory.Create(id, ComponentType.EOF, new string[] { "EOF" }, "EOF");
                return component;
            }
            // コマンドのコンポーネント化
            if (text[0] == '@')
            {
                component = ScenarioComponentFactory.Create(id, ComponentType.CMD, SplitCommandText(text), (_count + 1).ToString());
                return component;
            }
            
            // シナリオ本文のコンポーネント化
            component = ScenarioComponentFactory.Create(id, ComponentType.BASE, new string[] { text }, (_count + 1).ToString());
            
            return component;
        }

        /// <summary>
        /// コマンド本文を分割し、配列に格納して返す
        /// </summary>
        /// <param name="text">コマンド分割対象テキスト</param>
        /// <returns>コマンド配列</returns>
        private string[] SplitCommandText(string text)
        {
            string command = "";
            List<string> options = new List<string>();
            foreach (char c in text)
            {
                if (c == '@')
                {
                    continue;
                }
                else if (c == '[' || c == ' ')
                {
                    continue;
                }
                else if (c == ']')
                {
                    options.Add(command);
                    break;
                }
                else if (c == ',')
                {
                    options.Add(command);
                    command = "";
                }
                else
                {
                    command += c;
                }
            }
            return options.ToArray();
        }

        /// <summary>
        /// シナリオ本文を改行で分割し、
        /// コンポーネント配列化する
        /// </summary>
        /// <param name="asset">テキスト素材</param>
        /// <returns>ライン分割されたテキストデータ</returns>
        private string[] DevideAsset(TextAsset asset)
        {
            string[] components = asset.text.Split('\n');
            var resultArray = components.Where(s => s.Length > 0).ToArray();
            return resultArray;
        }

    }
}