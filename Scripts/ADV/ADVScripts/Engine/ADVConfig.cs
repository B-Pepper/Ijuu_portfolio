using System;
using HarapekoADV.Scenarios;

namespace HarapekoADV
{
    /// <summary>
    /// エンド種別
    /// </summary>
    public enum EndTextType
    {
        NormalEndText,
        NormalSoukoEndText,
        TrueEndText,
        SuicideEndText,
        BombEndText,
        BombKitchenEndText
    }
        
    /// <summary>
    /// ADVシーンに置ける変数管理クラス
    /// </summary>
    public class ADVConfig
    {
        /// <summary>
        /// 読みこむAddressableタグ
        /// </summary>
        private static EndTextType _scenarioName = EndTextType.NormalEndText;
        
        /// <summary>
        /// クリアしたENDを格納
        /// </summary>
        private static string[] _goalScenarios = new string[6];

        /// <summary>
        /// 現在のADVのStatus
        /// </summary>
        private static LoadStatus _currentLoadStatus = LoadStatus.Loading; 

        /// <summary>
        /// シナリオの名前のセッター
        /// </summary>
        /// <param name="scenarioName">Adressableタグ列挙型</param>
        public static void SetScenarioName(EndTextType scenarioName)
        {
            _scenarioName = scenarioName;
        }

        /// <summary>
        /// シナリオの名前のゲッター
        /// </summary>
        /// <returns>Adressableタグ</returns>
        public static string GetScenarioName()
        {
            return _scenarioName.ToString();
        }

        /// <summary>
        /// クリアしたENDを配列に格納
        /// </summary>
        /// <param name="clearScenario">クリアしたENDの名前</param>
        public static void SetGoalScenario(string clearScenario)
        {
            // 配列の空いている要素に格納
            for(int i = 0; i < _goalScenarios.Length; i++)
            {
                if (_goalScenarios[i] == null)
                {
                    _goalScenarios[i] = clearScenario;
                    break;
                }
                else if (_goalScenarios[i] == clearScenario)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// クリアしたENDの配列を返す
        /// </summary>
        /// <returns>goalScenarios</returns>
        public static string[] GetGoalScenario()
        {
            return _goalScenarios;
        }

        /// <summary>
        /// ADVロード状況をセットする
        /// </summary>
        /// <param name="nextStatus"></param>
        public static void SetLoadStatus(LoadStatus nextStatus)
        {
            _currentLoadStatus = nextStatus;
        }
        
        /// <summary>
        /// ADVロード状況を取得
        /// </summary>
        /// <returns>ロード状況</returns>
        public static LoadStatus GetLoadStatus()
        {
            return _currentLoadStatus;
        }
    }
}