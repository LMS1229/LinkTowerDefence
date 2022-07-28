using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingOneHitTower : AttackTower
{
    GameObject targetingEnermy;
    

    [SerializeField]
    int _range;

    Dectectable detecter;
    public int range
    {
        get { return _range; }
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
            if (detecter.IsDetectedObjectInRange(this,targetingEnermy))
            {
                while (attackCoolDown >= attack_cooltime)
                {                                      
                    Quaternion directionToEnermy = Quaternion.LookRotation(targetingEnermy.transform.position - this.transform.position);
                    this.transform.rotation = directionToEnermy;
                    this.animator.SetTrigger("Fire");
                    _attackCoolDown = 0;
                }
            }
        }
    }
}
