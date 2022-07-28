using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerProperty", menuName = "Scriptable Object/PowerTowerProperty")]
public class PowerTowerProperty : LinkTowrProperty
{
    [SerializeField]
    private TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE _nonUniqueEffect;
    public TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE nonUniqueEffect
    {
        get { return _nonUniqueEffect; }
    }

    [SerializeField]
    private TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE _uniqueEffect;

    public TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE uniqueEffect
    {
        get { return _uniqueEffect; }
    }
}
