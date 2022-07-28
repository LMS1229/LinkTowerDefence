using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultTower : Tower
{
    // Start is called before the first frame update
    protected Dictionary<TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE, SortedSet<PowerTower>> uniqueEffectTowers;
    protected SortedSet<PowerTower> noUniquePowerTowerSet;
    public override void AddLinkedTower(Tower linkTower, GameManager.DIR dir)
    {
        GameManager.DIR reversDir = (GameManager.DIR)(((int)dir + 4) % (int)GameManager.DIR.SIZE);
        LinkTower tower=linkTower as LinkTower;
        Debug.Assert(tower != null);
        linkedTowerList.Add(tower);
        
    }
    public override void RemoveLinkedTower(Tower linkTower, GameManager.DIR dir)
    {
        GameManager.DIR reversDir = (GameManager.DIR)(((int)dir + 4) % (int)GameManager.DIR.SIZE);
        LinkTower tower = linkTower as LinkTower;
        Debug.Assert(tower != null);
        linkedTowerList.Remove(tower);
    }
    abstract protected bool checkVaildUniqueEffect(TowerManager.POWER_TOWER_UNIQUE_EFFECT_TYPE type);
    abstract protected bool checkVaildNonUniqueEffect(TowerManager.POWER_TOWER_NON_UNIQUE_EFFECT_TYPE type);

    public void AddPowerTower(PowerTower powerTower)
    {
        Debug.Assert(powerTower != null);
        if (checkVaildNonUniqueEffect(powerTower.nonUniqueEffectType))
        {
            noUniquePowerTowerSet.Add(powerTower);
            applyNonUniqueEffect(powerTower);
        }
        if (checkVaildUniqueEffect(powerTower.uniqueEffectType))
        {
            if (uniqueEffectTowers.ContainsKey(powerTower.uniqueEffectType) == false)
            {
                uniqueEffectTowers[(powerTower.uniqueEffectType)] = new SortedSet<PowerTower>(new PowerTowerCompaerer());
            }
            uniqueEffectTowers[powerTower.uniqueEffectType].Add(powerTower);
        }
    }
    public void RemovePowerTower(PowerTower powerTower)
    {
        Debug.Assert(powerTower != null);
        if (checkVaildNonUniqueEffect(powerTower.nonUniqueEffectType))
        {
            removeNonUniqueEffect(powerTower);
        }
        if (checkVaildUniqueEffect(powerTower.uniqueEffectType))
        {
            if (uniqueEffectTowers.ContainsKey(powerTower.uniqueEffectType))
            {
                uniqueEffectTowers[powerTower.uniqueEffectType].Remove(powerTower);
            }
        }
    }
    abstract protected void applyNonUniqueEffect(PowerTower powerTower);
    abstract protected void removeNonUniqueEffect(PowerTower powerTower);

    class PowerTowerCompaerer : IComparer<PowerTower>
    {
        int IComparer<PowerTower>.Compare(PowerTower x, PowerTower y)
        {
            if (x.uniqueEffectMagnification < y.uniqueEffectMagnification)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
