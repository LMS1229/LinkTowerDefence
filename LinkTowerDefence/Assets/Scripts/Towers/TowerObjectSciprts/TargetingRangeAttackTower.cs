using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingRangeAttackTower : AttackTower
{
    GameObject targetingEnermy;

    Dectectable detecter;

    protected override bool checkVaildNonUniqueEffect(TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE type)
    {
        switch (type)
        {
            case TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_UP:
                return true;
        }
        return false;
    }

    protected override bool checkVaildUniqueEffect(TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE type)
    {
        switch (type)
        {
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_DAMAGE_MUL:
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.ATTACK_COOLDOWN:
            case TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE.RANGE_UP:
                return true;
        }
        return false;
    }

    void Start()
    {
        detecter = TowerManager.targetingDectector;
        animator = GetComponent<Animator>();
        _attackCoolDown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _attackCoolDown += Time.deltaTime;
        if (targetingEnermy == null)
        {
            targetingEnermy = detecter.Detect(this, range);
        }
        if (targetingEnermy != null)
        {
            if (detecter.IsDetectedObjectInRange(this, targetingEnermy))
            {
                if (attackCoolDown >= attack_cooltime)
                {
                    Quaternion directionToEnermy = Quaternion.LookRotation(targetingEnermy.transform.position - this.transform.position);
                    this.transform.rotation = directionToEnermy;
                    Fire();
                }
            }
        }
    }
}
