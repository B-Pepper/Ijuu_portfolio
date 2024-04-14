using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVP.Views
{
    /// <summary>
    /// アイテムボックスにて表示するマップの表示処理
    /// </summary>
    public class ItemBoxMapView : MonoBehaviour
    {
        /// <summary>
        /// ItemBoxViewのコンポーネントを格納
        /// </summary>
        [SerializeField] private MVP.Views.ItemBoxView _itemBoxView;

        [SerializeField] private Sprite[] _mapImage;

        /// <summary>
        /// クリック時のイベント処理
        /// </summary>
        public void OnClick()
        {
            // シーン番号によって、表示するマップを変更
            switch (Config.GetCurrentSceneNum())
            {
                case 0:
                    _itemBoxView.SetMapText(ItemConstant.MAP_GENKAN_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[0]);
                    _itemBoxView.SetExpansionImage(_mapImage[0]);
                    break;
                case 1:
                    _itemBoxView.SetMapText(ItemConstant.MAP_SYOSAI_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[1]);
                    _itemBoxView.SetExpansionImage(_mapImage[1]);
                    break;
                case 2:
                    _itemBoxView.SetMapText(ItemConstant.MAP_TOILET_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[2]);
                    _itemBoxView.SetExpansionImage(_mapImage[2]);
                    break;
                case 3:
                    _itemBoxView.SetMapText(ItemConstant.MAP_ROUKA_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[3]);
                    _itemBoxView.SetExpansionImage(_mapImage[3]);
                    break;
                case 4:
                    _itemBoxView.SetMapText(ItemConstant.MAP_BEDROOM_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[4]);
                    _itemBoxView.SetExpansionImage(_mapImage[4]);
                    break;
                case 5:
                    _itemBoxView.SetMapText(ItemConstant.MAP_BATHROOM_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[5]);
                    _itemBoxView.SetExpansionImage(_mapImage[5]);
                    break;
                case 6:
                    _itemBoxView.SetMapText(ItemConstant.MAP_KITCHEN_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[6]);
                    _itemBoxView.SetExpansionImage(_mapImage[6]);
                    break;
                case 7:
                    _itemBoxView.SetMapText(ItemConstant.MAP_LIVING_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[7]);
                    _itemBoxView.SetExpansionImage(_mapImage[7]);
                    break;
                case 8:
                    _itemBoxView.SetMapText(ItemConstant.MAP_DINING_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[8]);
                    _itemBoxView.SetExpansionImage(_mapImage[8]);
                    break;
                case 9:
                    _itemBoxView.SetMapText(ItemConstant.MAP_SOUKO_EXPLAIN);
                    _itemBoxView.SetMapImage(_mapImage[9]);
                    _itemBoxView.SetExpansionImage(_mapImage[9]);
                    break;
            }
        }
    }
}