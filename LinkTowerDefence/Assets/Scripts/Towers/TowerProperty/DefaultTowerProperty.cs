using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTowerProperty : TowerProperty {

    [SerializeField]
    protected float _coolDown;

    public float coolDown
    {
        get { return _coolDown; }
    }
}
