using System;

namespace HarapekoADV.Commands
{
    /// <summary>
    /// コマンドクラスの子クラスであるストラテジ系インスタンスを生成
    /// </summary>
    public class CommandsFactory
    {
        /// <summary>
        /// コマンド種別ごとにストラテジを生成保持、コマンドを生成
        /// </summary>
        /// <param name="commandType">コマンドタイプ</param>
        /// <param name="args">文字列、コマンド</param>
        /// <returns></returns>
        public static Command Create(CommandType commandType, string[] args)
        {
            Command command = null;
            CommandStrategy strategy = null;

            switch (commandType)
            {
                case CommandType.TEXT:
                    strategy = new TextStrategy();
                    break;
                case CommandType.END:
                    strategy = new EndStrategy();
                    break;
                case CommandType.ERR:
                    strategy = new ErrorStrategy();
                    break;
                case CommandType.CHARACTER_CHANGE:
                    strategy = new CharacterChangeStrategy();
                    break;
                case CommandType.BG_CHANGE:
                    strategy = new BackgroundChangeStrategy();
                    break;
                case CommandType.BGM_PLAY:
                    strategy = new BgmPlayStrategy();
                    break;
                case CommandType.BGM_CHANGE:
                    strategy = new BgmChangeStrategy();
                    break;
                case CommandType.BGM_STOP:
                    strategy = new BgmStopStrategy();
                    break;
                case CommandType.SE_PLAY:
                    strategy = new SePlayStrategy();
                    break;
                case CommandType.SE_STOP:
                    strategy = new SeStopStrategy();
                    break;
                case CommandType.NAME_CHANGE:
                    strategy = new NameChangeStrategy();
                    break;
            }

            if (strategy != null)
            {
                strategy.Initialise(args);
                command = new Command(commandType, strategy);
            }

            return command;
        }
    }
}