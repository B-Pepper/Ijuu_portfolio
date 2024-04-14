using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HarapekoADV
{
    /// <summary>
    /// ADVスキップ処理
    /// </summary>
    public class SkipButtonView : MonoBehaviour
    {
        [SerializeField] private ADVView _advView;

        public void OnClick()
        {
            _advView.NotifyADVFinish();
        }
    }
}