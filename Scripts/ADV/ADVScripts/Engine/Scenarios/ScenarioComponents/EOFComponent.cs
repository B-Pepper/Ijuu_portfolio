using System;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// EOF制御用のコンポーネント
    /// </summary>
    public class EOFComponent : ScenarioComponent
    {
        internal EOFComponent(string id, string[] args, string nextComponentID) : base(id, ComponentType.EOF, args, nextComponentID) { }
    }
}