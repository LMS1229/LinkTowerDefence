using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : DefaultTower
{
    protected float attack_cooltime
    {
        get
        {
            if (uniqueEffectTowers.ContainsKey(TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_COOLDOWN))
            {
                return property.coolDown * uniqueEffectTowers[TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_COOLDOWN].Max.uniqueEffectMagnification; ;
            }
            return property.coolDown;
        }
    }
    public int range
    {
        get { return default_range; }
    }

    public float attackCoolDown
    {
        get { return _attackCoolDown; }
    }

    private float addDamage;
    protected float damage
    {
        get
        {
            if (uniqueEffectTowers[TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_MUL] == null ||
                uniqueEffectTowers[TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_MUL].Count == 0)
            {
                return (property.damage + addDamage);
            }
            else
            {
                return (property.damage + addDamage) * uniqueEffectTowers[TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_MUL].Max.uniqueEffectMagnification;
            }

        }
    }
    [SerializeField]
    protected int default_range;

    [SerializeField]
    protected float _attackCoolDown;

    [SerializeField]
    private AttackTowerProperty property;

    void Start()
    {
        uniqueEffectTowers = new Dictionary<TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE, SortedSet<PowerTower>>();
        noUniquePowerTowerSet = new SortedSet<PowerTower>();
    }
 


    // Update is called once per frame
    void Update()
    {

    }

    protected void Fire()
    {
        this.animator.SetTrigger("Fire");
        _attackCoolDown = 0;
    }

    protected override bool checkVaildUniqueEffect(TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE type)
    {
        switch (type)
        {
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_MUL:
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.RANGE_UP:
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_COOLDOWN:
                return true;
        }
        return false;
    }

    protected override bool checkVaildNonUniqueEffect(TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE type)
    {
        switch (type)
        {
            case TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_UP:
                return true;
        }
        return false;
    }

    protected override void applyNonUniqueEffect(PowerTower powerTower)
    {
        if (checkVaildNonUniqueEffect(powerTower.nonUniqueEffectType))
        {
            addDamage += powerTower.nonUniqueEffectValue;
        }
    }

    protected override void removeNonUniqueEffect(PowerTower powerTower)
    {
        if (checkVaildNonUniqueEffect(powerTower.nonUniqueEffectType))
        {
            addDamage -= powerTower.nonUniqueEffectValue;
        }
    }
}