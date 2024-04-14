using System;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// シナリオの構成要素　BASE基本, IF条件分岐, END終点, CMDコマンド
    /// </summary>
    public abstract class ScenarioComponent
    {
        /// <summary>
        /// ScenarioComponentのユニークID
        /// </summary>
        private string _componentId;

        /// <summary>
        /// ScenarioComponentのユニークID
        /// </summary>
        public string ComponentID
        {
            get { return _componentId; }
        }
        
        /// <summary>
        /// タイプ
        /// BASE, (IF), END, CMD
        /// </summary>
        private ComponentType _componentType;
        
        /// <summary>
        /// タイプ
        /// BASE, (IF), END, CMD
        /// </summary>
        public ComponentType ComponentType
        {
            get { return _componentType; }
        }
        
        /// <summary>
        /// テキスト、コマンドの引数
        /// </summary>
        protected string[] _args;

        /// <summary>
        /// 次のコンポーネントのID
        /// </summary>
        private string _nextComponentID;

        /// <summary>
        /// コンストラクタ
        /// 各種フィールドの初期化
        /// </summary>
        /// <param name="componentId">コンポーネントID</param>
        /// <param name="type">コンポーネント種別</param>
        /// <param name="args">本文、コマンド本体</param>
        /// <param name="nextComponentID">次のコンポーネントID</param>
        public ScenarioComponent(string componentId, ComponentType type, string[] args, string nextComponentID)
        {
            _componentId = componentId;
            _componentType = type;
            _args = args;
            _nextComponentID = nextComponentID;
        }

        /// <summary>
        /// 次のコマンドの引数を返す
        /// </summary>
        /// <returns></returns>
        public virtual string[] GetNext()
        {
            return _args;
        }

        /// <summary>
        /// 次のコンポーネントのIDを決定する
        /// </summary>
        /// <returns></returns>
        public string GetNextComponentID()
        {
            return _nextComponentID;
        }
    }
}
