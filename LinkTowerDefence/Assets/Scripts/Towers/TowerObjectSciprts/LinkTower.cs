using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTower : Tower
{
    protected int linkLevel;
    protected bool[] markingLinkMark;

    public override void Install()
    {
        for(GameManager.DIR dir = GameManager.DIR.UP; dir < GameManager.DIR.SIZE; ++dir)
        {
            if (markingLinkMark[(int)dir])
            {
                int nrow = GameManager.instance.GetNextRow(placedRow, dir);
                int ncol= GameManager.instance.GetNextCol(placedCol, dir);
                Tower nearTower = TowerManager.instance.GetTowerInBoard(nrow, ncol);
                if (nearTower != null)
                {
                    nearTower.AddLinkedTower(this, dir);
                    this.linkingTowerList.Add(nearTower);
                }
            }
        }
    }
    public override void AddLinkedTower(Tower linkTower, GameManager.DIR dir)
    {
        GameManager.DIR reversDir = (GameManager.DIR)(((int)dir + 4) % (int)GameManager.DIR.SIZE);
        this.linkedTowerList.Add(linkTower);
        if (markingLinkMark[(int)reversDir])
        {
            this.linkingTowerList.Add(linkTower);
        }
    }
    public override void RemoveLinkedTower(Tower linkTower, GameManager.DIR dir)
    {
        GameManager.DIR reversDir = (GameManager.DIR)(((int)dir + 4) % (int)GameManager.DIR.SIZE);
        this.linkedTowerList.Add(linkTower);
        if (markingLinkMark[(int)reversDir])
        {
            this.linkingTowerList.Remove(linkTower);
        }
    }



    public bool HasLinkMarker(GameManager.DIR mark)
    {
        return this.markingLinkMark[(int)mark];
    }
}
