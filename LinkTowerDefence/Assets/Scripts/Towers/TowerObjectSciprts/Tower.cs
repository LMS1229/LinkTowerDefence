using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    protected SortedSet<Tower> linkingTowerList, linkedTowerList;
    protected int _placedRow, _placedCol;
    protected Animator animator;
    public int placedRow
    {
        get { return _placedRow; }
    }

    public int placedCol
    {
        get { return _placedCol; }
    }

    public virtual void Install()
    {
        animator.SetTrigger("Install");
    }

    virtual public TowerManager.TOWER_TYPE GetTowerType()
    {
        return TowerManager.TOWER_TYPE.NONE;
    }
    abstract public void AddLinkedTower(Tower linkTower, GameManager.DIR dir);
    abstract public void RemoveLinkedTower(Tower linkTower, GameManager.DIR dir);
}
