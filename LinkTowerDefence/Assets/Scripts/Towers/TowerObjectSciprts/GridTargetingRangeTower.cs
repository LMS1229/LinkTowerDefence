using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTargetingRangeTower : AttackTower
{
    private FixedTargetable gridTargeter;

    private int target_row, target_col;
    // Start is called before the first frame update
    void Start()
    {
        gridTargeter = TowerManager.gridTargetor;
        target_row = target_col = -1;
    }

    // Update is called once per frame
    void Update()
    {
        _attackCoolDown += Time.deltaTime;
        if (attackCoolDown >= attack_cooltime&&gridTargeter.IsTargetting())
        {
            Fire();
        }
    }
    public void SetTargettingGrid(int gridRow, int gridCol)
    {
        gridTargeter.SetTarget(this, gridRow, gridCol, range);
    }
}
