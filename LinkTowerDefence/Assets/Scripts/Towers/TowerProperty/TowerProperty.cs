using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TowerProperty : ScriptableObject
{
    [SerializeField]
    protected int _buyCost;
    
    public int buyCost
    {
        get { return _buyCost; }
    }

    [SerializeField]
    protected TowerManager.TOWER_TYPE _towerType;

    public TowerManager.TOWER_TYPE towerType
    {
        get { return _towerType; }
    }
}
