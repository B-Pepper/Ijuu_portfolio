using UnityEngine;
using DG.Tweening;

public class ParallaxControlView : MonoBehaviour
{
    /// <summary>
    /// 対象パネル
    /// </summary>
    [SerializeField] private Transform _backgroundPanel;

    /// <summary>
    /// 最大X移動量
    /// </summary>
    [SerializeField] private float _maxX = 80f;

    /// <summary>
    /// 最大Y移動量
    /// </summary>
    [SerializeField] private float _maxY = 45f;

    /// <summary>
    /// パララックスにかける時間
    /// </summary>
    [SerializeField] private float _duration = 1f;

    /// <summary>
    /// マウス位置
    /// </summary>
    private Vector3 _mousePosition;

    /// <summary>
    /// マウス位置と反転した方向に動かすかどうか
    /// </summary>
    [SerializeField] private bool _isInversion = false;




    void Awake()
    {
        _mousePosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }


    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        ExecParallax();        
    }

    /// <summary>
    /// マウスポインタ位置に応じたパララックスエフェクトの実行
    /// </summary>
    private void ExecParallax()
    {
        // 目標ベクトルの算出
        Vector3 targetPosition = CalculateParallax();
        // 目標ベクトルに移動
        _backgroundPanel.DOLocalMove(targetPosition, _duration)
        .SetEase(Ease.OutQuint);
    }

    /// <summary>
    /// マウス位置を起点としたパララックスの計算
    /// </summary>
    /// <returns>パララックス位置</returns>
    private Vector3 CalculateParallax()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 offset = _mousePosition - screenCenter;
        // 逆ベクトルフラグを確認
        if(_isInversion)
        {
            offset *= -1;
        }
        // ベクトルのスカラ制限まで移動できるベクトルを返す
        return new Vector3(
            Mathf.Clamp(offset.x / screenCenter.x * _maxX, -_maxX, _maxX),
            Mathf.Clamp(offset.y / screenCenter.y * _maxY, -_maxY, _maxY),
            0
        );
    }
}
