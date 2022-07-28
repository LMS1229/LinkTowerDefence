using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerProperty", menuName = "Scriptable Object/SupportTowerProperty")]
public class SupportTowerProperty : DefaultTowerProperty
{
    [SerializeField]
    private TowerManager.SUPPORT_TYPE _supportType;
    public TowerManager.SUPPORT_TYPE supportType
    {
        get { return _supportType; }
    }

    [SerializeField]
    private TowerManager.SUPPORT_WAY _supportWay;
    public TowerManager.SUPPORT_WAY supportWay
    {
        get { return _supportWay; }
    }
}
