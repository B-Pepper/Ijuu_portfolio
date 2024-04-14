using System;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// 基本の文字列表示のコンポーネント
    /// 引数の1つ目を反映する
    /// </summary>
    public class BaseComponent : ScenarioComponent
    {
        internal BaseComponent(string id, string[] args, string nextComponentID) : base(id, ComponentType.BASE, args, nextComponentID) { }


        public override string[] GetNext()
        {
            return _args;
        }
    }
}