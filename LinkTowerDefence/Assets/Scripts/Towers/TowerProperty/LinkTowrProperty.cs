using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTowrProperty : TowerProperty
{
    [SerializeField]
    private int _upgradeCost;
    public int upgradeCost
    {
        get { return _upgradeCost; }
    }
}
