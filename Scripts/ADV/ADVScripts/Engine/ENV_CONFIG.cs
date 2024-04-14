using System.Collections.Generic;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;

namespace HarapekoADV
{
    /// <summary>
    /// 環境変数管理クラス
    /// </summary>
    public static class ENV_CONFIG
    {
        /// <summary>
        /// 画像のprefab用アドレス
        /// </summary>
        public const string IMG_PREFAB_ADDRESS = "Prefabs/Image";

        /// <summary>
        /// 音声のprefab用アドレス
        /// </summary>
        public const string SOUND_PREFAB_ADRESS = "Prefabs/SoundManager";

        /// <summary>
        /// コマンド名と列挙型を紐づけた辞書型
        /// </summary>
        private static Dictionary<string, CommandType> commandDictionary;

        /// <summary>
        /// コマンド名からコマンド種別を取得する
        /// </summary>
        /// <param name="key">コマンド文</param>
        /// <returns>コマンド種別</returns>
        public static CommandType GetCommandType(string key)
        {
            if (commandDictionary == null)
            {
                Initialise();
            }
            CommandType type = CommandType.ERR;
            if (commandDictionary.ContainsKey(key))
            {
                type = commandDictionary[key];
            }
            return type;
        }

        /// <summary>
        /// コンポーネント名と種別を紐づける辞書型
        /// </summary>
        private static Dictionary<string, ComponentType> componentDictionary;

        /// <summary>
        /// コンポーネント名からコンポーネント種別を判別する
        /// </summary>
        /// <param name="key">コンポーネント名</param>
        /// <returns>コンポーネント種別</returns>
        public static ComponentType GetComponentType(string key)
        {
            if (componentDictionary == null)
            {
                Initialise();
            }

            ComponentType type = ComponentType.BASE;

            if (componentDictionary.ContainsKey(key))
            {
                type = componentDictionary[key];
            }
            else if (key[0] == '@')
            {
                type = ComponentType.CMD;
            }
            return type;
        }

        /// <summary>
        /// コマンド、コンポーネントの初期登録
        /// </summary>
        private static void Initialise()
        {
            commandDictionary = new Dictionary<string, CommandType>();
            Add("TEXT", CommandType.TEXT);
            Add("END", CommandType.END);
            Add("ERR", CommandType.ERR);
            Add("CHARACTER_CHANGE", CommandType.CHARACTER_CHANGE);
            Add("BG_CHANGE", CommandType.BG_CHANGE);
            Add("SE_PLAY", CommandType.SE_PLAY);
            Add("SE_STOP", CommandType.SE_STOP);
            Add("BGM_PLAY", CommandType.BGM_PLAY);
            Add("BGM_CHANGE", CommandType.BGM_CHANGE);
            Add("BGM_STOP", CommandType.BGM_STOP);
            Add("NAME_CHANGE", CommandType.NAME_CHANGE);
            componentDictionary = new Dictionary<string, ComponentType>();
            Add("@[EOF]", ComponentType.EOF);
        }

        /// <summary>
        /// コマンド名とコマンド種別を紐づけて登録する
        /// </summary>
        /// <param name="key">コマンド名</param>
        /// <param name="value">コマンド種別</param>
        private static void Add(string key, CommandType value)
        {
            commandDictionary.Add(key, value);
        }

        /// <summary>
        /// コンポーネント名とコンポーネント種別を紐づけて登録する
        /// </summary>
        /// <param name="key">コンポーネント名</param>
        /// <param name="value">コンポーネント種別</param>
        private static void Add(string key, ComponentType value)
        {
            componentDictionary.Add(key, value);
        }

    }
}