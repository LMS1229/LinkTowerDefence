using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTower : LinkTower
{
    PowerTowerProperty property;
    // Start is called before the first frame update

    private float _mamagnification;
    private float _value;

    public float uniqueEffectMagnification
    {
        get { return _mamagnification; }
    }

    public float nonUniqueEffectValue
    {
        get { return _value; }
    }

    public TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE nonUniqueEffectType
    {
        get { return property.nonUniqueEffect; }
    }

    public TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE uniqueEffectType
    {
        get { return property.uniqueEffect; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {

    }


}
