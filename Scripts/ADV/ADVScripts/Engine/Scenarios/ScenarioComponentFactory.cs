using HarapekoADV.Commands;


namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// シナリオコンポーネントを作成するFactoryクラス
    /// </summary>
    public class ScenarioComponentFactory
    {
        /// <summary>
        /// 読み込んだシナリオのタイプによって
        /// 本文とコマンド挙動を分割し、
        /// シナリオコンポーネント作成
        /// </summary>
        /// <param name="id">シナリオコンポーネントID</param>
        /// <param name="type">コンポーネントタイプ</param>
        /// <param name="args">コンポーネント配列</param>
        /// <param name="nextComponentID">次のコンポーネントID</param>
        /// <returns></returns>
        public static ScenarioComponent Create(string id, ComponentType type, string[] args, string nextComponentID)
        {
            ScenarioComponent component = null;

            switch (type)
            {
                case ComponentType.BASE:
                    component = new BaseComponent(id, args, nextComponentID);
                    break;
                case ComponentType.CMD:
                    CommandType commandType;
                    commandType = ENV_CONFIG.GetCommandType(args[0]);
                    component = new CommandComponent(id, args, nextComponentID, commandType);
                    break;
                case ComponentType.EOF:
                    component = new EOFComponent(id, args, nextComponentID);
                    break;
            }

            return component;
        }
    }
}