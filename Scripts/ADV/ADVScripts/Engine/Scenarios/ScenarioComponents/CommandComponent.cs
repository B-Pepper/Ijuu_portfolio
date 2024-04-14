using System;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// ADV View上になにかしらのコマンドを実行する
    /// 画像の移動とかフォントの変更とか
    /// 
    /// コマンドの特定までここでできるようになっておいても良いか
    /// </summary>
    public class CommandComponent : ScenarioComponent
    {
        /// <summary>
        /// コマンドの種別を保持する変数
        /// </summary>
        private CommandType _type;
        
        /// <summary>
        /// コマンドの種別を返すゲッター
        /// </summary>
        /// <value>コマンド種別</value>
        public CommandType Type { get { return _type; } }

        /// <summary>
        /// 各フィールドの初期化
        /// </summary>
        /// <param name="id">コンポーネントID</param>
        /// <param name="args">テキスト分割されたコンポーネントの引数</param>
        /// <param name="nextComponentID">次のコンポーネントID</param>
        /// <param name="type">コマンド種別</param>
        /// <returns></returns>
        internal CommandComponent(string id, string[] args, string nextComponentID, CommandType type) : base(id, ComponentType.CMD, args, nextComponentID)
        {
            _type = type;
        }


        /// <summary>
        /// 次のコマンドのコンポーネント引数を読み込む
        /// </summary>
        /// <returns></returns>
        public override string[] GetNext()
        {
            return base.GetNext();
        }
    }
}