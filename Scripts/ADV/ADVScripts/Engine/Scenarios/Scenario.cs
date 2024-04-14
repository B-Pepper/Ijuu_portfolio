using System.Collections.Generic;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// シナリオの構造体を管理する
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// ID, Component シーンコンポーネントとそのID
        /// </summary>
        private Dictionary<string, ScenarioComponent> _componentList;
        
        /// <summary>
        /// ID, flag 条件分岐のためのフラグとそのID
        /// </summary>
        private Dictionary<string, bool> _flagList;
        
        /// <summary>
        /// 最初のコンポーネントのID
        /// </summary>
        private string _firstID;

        /// <summary>
        /// 現在、再生中のComponent
        /// </summary>
        private ScenarioComponent _component;


        // コンストラクタ
        /// <summary>
        /// コンポーネントリストやフラグリストの初期化
        /// </summary>
        public Scenario()
        {
            _componentList = new Dictionary<string, ScenarioComponent>();
            _flagList = new Dictionary<string, bool>();
            _firstID = "";
            _component = null;
        }

        /// <summary>
        /// コンポーネントの追加
        /// </summary>
        /// <param name="scenarioComponent">追加するコンポーネント</param>
        public void Add(ScenarioComponent scenarioComponent)
        {
            string id = scenarioComponent.ComponentID;
            _componentList.Add(id, scenarioComponent);
        }

        /// <summary>
        /// フラグの追加
        /// </summary>
        /// <param name="id">コンポーネントID</param>
        /// <param name="value">フラグの値</param>
        public void Add(string id, bool value)
        {
            _flagList.Add(id, value);
        }

        /// <summary>
        /// 初期シーンの選択
        /// </summary>
        /// <param name="id">該当シナリオの最初のID</param>
        public void SetFirstID(string id)
        {
            if (_componentList.ContainsKey(id))
            {
                _firstID = id;
            }
        }

        /// <summary>
        /// 次の表示文字列あるいはコマンドを返す
        /// </summary>
        /// <returns>次のコマンド</returns>
        public Command GetNext()
        {
            Command command = null;
            // 初期コンポーネントが未設定であった場合に処理を中断する
            if (_firstID == null || _firstID == "")
            {
                Debugger.Log("undefined first node");
                return CommandsFactory.Create(CommandType.ERR, null);
            }

            // コンポーネントが空の場合、初期コンポーネントを設定する
            if (_component == null)
            {
                _component = _componentList[_firstID];
            }

            // 終点だった場合、終了コマンドを返す
            if (_component.ComponentType.Equals(ComponentType.EOF))
            {
                command = CommandsFactory.Create(CommandType.END, _component.GetNext());
            }
            // コンポーネントがコマンドだった場合
            else if (_component.ComponentType.Equals(ComponentType.CMD)) 
            {
                Debugger.Log("here");
                // componentのIDから指定のコマンドを生成して返却
                CommandComponent commandComponent = (CommandComponent)_component;
                Debugger.Log("TYPE' : " + commandComponent.Type);
                command = CommandsFactory.Create(commandComponent.Type, _component.GetNext());
            }
            else
            {
                Debugger.Log("Type : " + _component.ComponentType);
                // else コマンドでも終点でもない場合はテキスト読み込み
                command = CommandsFactory.Create(CommandType.TEXT, _component.GetNext());
            }

            if (_component.ComponentType != ComponentType.EOF)
            {
                string id = _component.GetNextComponentID();
                if (_componentList.ContainsKey(id))
                {
                    _component = _componentList[id];
                }
                else
                {
                    Debugger.Err("key not found : " + id);
                }
            }

            return command;
        }
    }
}