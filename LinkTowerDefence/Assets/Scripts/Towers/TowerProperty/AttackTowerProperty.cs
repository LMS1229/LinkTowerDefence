using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerProperty", menuName = "Scriptable Object/AttackTowerProperty")]
public class AttackTowerProperty : DefaultTowerProperty
{
    [SerializeField]
    TowerManager.ATTACK_TYPE _attackType;

    [SerializeField]
    private int _damage;

    [SerializeField]
    TowerManager.ATTACK_WAY _attackWay;

    public TowerManager.ATTACK_TYPE attckType
    {
        get { return _attackType; }
    }

    public int damage
    {
        get { return _damage; }
    }

    public TowerManager.ATTACK_WAY attackWay
    {
        get { return _attackWay; }
    }
}
