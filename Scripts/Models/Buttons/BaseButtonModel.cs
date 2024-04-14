namespace MVP.Models
{
    /// <summary>
    /// 基本的なボタンのModel
    /// </summary>
    public abstract class BaseButtonModel
    {
        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public abstract void OnClick();
    }
}