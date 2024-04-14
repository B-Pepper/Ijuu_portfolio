using UnityEngine;
using DG.Tweening;

namespace MVP.Effects
{
    /// <summary>
    /// 対象をランダムに動かす
    /// </summary>
    public class RandomMovementView : MonoBehaviour
    {
        /// <summary>
        /// 対象パネル
        /// </summary>
        [SerializeField] private Transform _parentPanel;

        /// <summary>
        /// 最小値
        /// </summary>    
        [SerializeField] private float _minRange = 0f;
        
        /// <summary>
        /// 最大値
        /// </summary>
        [SerializeField] private float _maxRange = 4.0f;

        /// <summary>
        /// 何秒かけて動かすか
        /// </summary>
        [SerializeField] private float _duration = 1.0f;
        

        void Start()
        {
            MoveRandomly();
        }

        /// <summary>
        /// シーンの初期位置からランダムな方向に動かす
        /// </summary>
        void MoveRandomly()
        {
            // ランダムな方向と距離を生成
            Vector3 randomDirection = Random.insideUnitSphere;
            float randomDistance = Random.Range(_minRange, _maxRange); // 好みに合わせて調整

            // ランダムに生成した方向と距離でTweenを作成
            _parentPanel.DOLocalMove(_parentPanel.localPosition + randomDirection * randomDistance, _duration)
                .SetEase(Ease.Linear)
                .OnComplete(MoveRandomly); // Tweenが終了したら再びランダムに動かす
        }
    }
}