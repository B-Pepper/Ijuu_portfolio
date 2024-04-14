using MVP.Sounds;
using UnityEngine;
using UnityEngine.UI;
using MVP.Presenters;
using MVP.Sounds;
using DG.Tweening;
using HarapekoADV;


namespace MVP.Views
{
    /// <summary>
    /// フェードインし、効果音を再生後、シーン切り替えする機能
    /// </summary>
    public class FromGamePlaceView: MonoBehaviour
    {
        /// <summary>
        /// シーン変更用のview
        /// </summary>
        ChangeSceneView _changeSceneView;

        /// <summary>
        /// ADVのシーン番号
        /// </summary>
        private const int _advNumber = 11;

        // Start is called before the first frame update
        public FromGamePlaceView()
        {
            _changeSceneView = new ChangeSceneView();
        }
        
        /// <summary>
        /// クリック時にエフェクトを再生したあと移動
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        /// <param name="fadePanel">フェード用パネル</param>
        /// <param name="seId">SEのID番号</param>
        /// <param name="duration">エフェクト時間(初期0.5f)</param>
        /// <param name="isNotLoad">ロード時遷移はfalse(初期true)</param>
        public void OnClick(int sceneNumber, GameObject fadePanel, SEType seId = SEType.None, float duration = 0.5f, bool isNotLoad = true)
        {
            int sceneNum = sceneNumber;
            // アサヒモ着火かつロード時遷移以外
            if(Config.GetGimmickStatus(GimmickConstant.GIMMICK_BEDROOM_IGNITION_ID) == GimmickConstant.GIMMICK_UNLOCK
            && isNotLoad)
            {
                // 移動カウント増加
                Config.IncreamentCountStepNum();
                int countNum = Config.GetCountStepNum();
                // 移動カウントが寝室へ最短(2)のとき、爆破エンド
                if (countNum == 2)
                {
                    // 寝室の時、爆死エンド
                    if(sceneNum == 5)
                    {
                        ADVConfig.SetScenarioName(EndTextType.BombEndText);
                        sceneNum = _advNumber;
                    }
                    else // 寝室以外の時、外で爆発
                    {
                        // SE
                        SoundManageView.GetInstance().PlaySE((int)SEType.BoomDirect);
                        // 寝室ステータス変更
                        Config.SetBedroomStatus(4);
                    }
                }
            }
            // シーン遷移実行
            ExecMove(sceneNum, fadePanel, seId, duration);

        }

        /// <summary>
        /// シーン移動の実行
        /// </summary>
        /// <param name="sceneNumber">シーン番号</param>
        /// <param name="fadePanel">フェードパネルオブジェクト</param>
        /// <param name="seId">SE番号</param>
        /// <param name="duration">エフェクト時間</param>
        private void ExecMove(int sceneNumber, GameObject fadePanel, SEType seId, float duration)
        {
            // フェードアウトしてシーン移動
            fadePanel.SetActive(true);
            Image image = fadePanel.GetComponent<Image>();
            // 透明度を透明にしておく
            image.DOFade(0f, 0f);
            // フェードインし、効果音を再生後、シーン切り替え
            Sequence sequence = DOTween.Sequence()
            .AppendCallback(()=>PlaySE(seId))
            .Join(FadeIn(image, duration))
            .OnComplete(() =>
            {
                _changeSceneView.OnClick(sceneNumber);
            });
            sequence.Play();
        }

        /// <summary>
        /// 画像のフェードエフェクト
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Tween FadeIn(Image image, float duration)
        {
            return image.DOFade(1f, duration).SetEase(Ease.InSine);
        }

        /// <summary>
        /// 移動時の効果音を設定している時、再生
        /// </summary>
        private void PlaySE(SEType seId)
        {
            if(seId == SEType.None)
            {
                return;
            }
            SoundManageView.GetInstance().PlaySE((int)seId);
        }
    }
}