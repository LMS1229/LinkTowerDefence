using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkingTower : LinkTower
{
    [SerializeField]
    private LinkTowrProperty _property;
    public LinkTowrProperty property
    {
        get { return _property; }
    }

    public override TowerManager.TOWER_TYPE GetTowerType()
    {
        return property.towerType;
    }

    public override void Install()
    {
        base.Install();
        bool[][] visited = new bool[GameManager.instance.boardRow][];
        for(int i = 0; i < GameManager.instance.boardRow; i++)
        {
            visited[i] = new bool[GameManager.instance.boardCol];
        }
        SortedSet<Tower> linkedPowerTowerSet = GetLinkedTower(TowerManager.TOWER_TYPE.POWER_TOWER);
        SortedSet<Tower> attackTowerSet = GetLinkingTowers(TowerManager.TOWER_TYPE.ATTACK_TOWER);
        SortedSet<Tower> supprtTowerSet = GetLinkingTowers(TowerManager.TOWER_TYPE.SUPPORT_TOWER);

        foreach(Tower powerTower in linkedPowerTowerSet)
        {
            PowerTower flowTower = null;
            if (powerTower is PowerTower)
            {
                flowTower= (PowerTower)powerTower;
                foreach (Tower attackTower in attackTowerSet)
                {
                    AttackTower linkingAttackTower= (AttackTower)attackTower;
                    Debug.Assert(linkingAttackTower != null);
                    linkingAttackTower.AddPowerTower(flowTower);
                }
                foreach (Tower supprtTower in supprtTowerSet)
                {
                    SupportTower linkingSupportTower= (SupportTower)supprtTower;
                    Debug.Assert(linkingSupportTower != null);
                    linkingSupportTower.AddPowerTower(flowTower);
                }
            }
            else
            {
                Debug.Assert(powerTower is PowerTower);
            }
        }
    }
    private struct point
    {
        public int row, col;
    };

    private SortedSet<Tower> GetLinkingTowers(TowerManager.TOWER_TYPE findingTowerType)
    {
        SortedSet<Tower> linkingTowerSet = new SortedSet<Tower>();
        bool[][] visited = new bool[GameManager.instance.boardRow][];
        for (int i = 0; i < GameManager.instance.boardRow; i++)
        {
            visited[i] = new bool[GameManager.instance.boardCol];
        }
        Queue<point> queue = new Queue<point>();
        point p;
        p.row = this.placedRow;
        p.col = this.placedCol;
        visited[p.row][p.col] = true;
        queue.Enqueue(p);
        while (queue.Count > 0)
        {
            p = queue.Dequeue();
            Tower tower = TowerManager.instance.GetTowerInBoard(p.row, p.col);
            if (tower.GetTowerType() == findingTowerType)
            {
                linkingTowerSet.Add(tower);
            }
            if (tower.GetTowerType() == TowerManager.TOWER_TYPE.LINKING_TOWER)
            {
                for (int i = 0; i < (int)GameManager.DIR.SIZE; ++i)
                {
                    GameManager.DIR now_dir = (GameManager.DIR)i;
                    if (HasLinkMarker(now_dir))
                    {
                        int nearRow = GameManager.instance.GetNextRow(p.row, now_dir);
                        int nearCol = GameManager.instance.GetNextCol(p.col, now_dir);
                        if (visited[nearRow][nearCol])
                        {
                            continue;
                        }
                        Tower nearTower = TowerManager.instance.GetTowerInBoard(nearRow, nearCol);
                        if (nearTower != null)
                        {
                            point next_p;
                            next_p.row = nearRow;
                            next_p.col = nearCol;
                            visited[nearRow][nearCol] = true;
                            queue.Enqueue(next_p);
                        }
                    }
                }
            }
        }
        return linkingTowerSet;
    }
    private SortedSet<Tower> GetLinkedTower(TowerManager.TOWER_TYPE findingTowerType)
    {
        SortedSet<Tower> linkedTowerSet = new SortedSet<Tower>();
        bool[][] visited = new bool[GameManager.instance.boardRow][];
        for (int i = 0; i < GameManager.instance.boardRow; i++)
        {
            visited[i] = new bool[GameManager.instance.boardCol];
        }
        Queue<point> queue = new Queue<point>();
        point p;
        p.row = this.placedRow;
        p.col = this.placedCol;
        visited[p.row][p.col] = true;
        queue.Enqueue(p);
        while(queue.Count > 0)
        {
            p = queue.Dequeue();
            Tower tower = TowerManager.instance.GetTowerInBoard(p.row, p.col);
            if (tower.GetTowerType()==findingTowerType)
            {
                linkedTowerSet.Add(tower);
            }
            if (tower.GetTowerType() == TowerManager.TOWER_TYPE.LINKING_TOWER)
            {
                for (int i = 0; i < (int)GameManager.DIR.SIZE; ++i)
                {
                    GameManager.DIR now_dir = (GameManager.DIR)i;
                    int nearRow = GameManager.instance.GetNextRow(p.row, now_dir);
                    int nearCol = GameManager.instance.GetNextCol(p.col, now_dir);
                    if (visited[nearRow][nearCol])
                    {
                        continue;
                    }
                    Tower nearTower = TowerManager.instance.GetTowerInBoard(nearRow, nearCol);
                    if (nearTower != null)
                    {
                        if (nearTower is LinkTower)
                        {
                            LinkTower nearLnkTower = (LinkTower)nearTower;
                            if (nearLnkTower.HasLinkMarker(GameManager.instance.GetReverseDIR(now_dir)))
                            {
                                point next_p;
                                next_p.row = nearRow;
                                next_p.col = nearCol;
                                visited[nearRow][nearCol] = true;
                                queue.Enqueue(next_p);
                            }
                        }
                    }
                }
            }
        }
        return linkedTowerSet;
    }

}
