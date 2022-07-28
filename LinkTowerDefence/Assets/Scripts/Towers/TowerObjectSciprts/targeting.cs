
using UnityEngine;

public interface Dectectable
{   
    public GameObject Detect(Tower tower, int range);
    public bool IsDetectedObjectInRange(Tower tower, GameObject dectedObject);
}

class TargetingDectecter : Dectectable
{
    public GameObject Detect(Tower tower,int range)
    {
        int start_row = (tower.placedRow-range >= 0 ? tower.placedRow - range : 0);
        int start_col = (tower.placedCol - range >= 0 ? tower.placedCol - range : 0);
        int end_row = (tower.placedRow + range < GameManager.instance.boardRow ? tower.placedRow + range : GameManager.instance.boardRow - 1);
        int end_col = (tower.placedCol + range < GameManager.instance.boardCol ? tower.placedCol + range : GameManager.instance.boardCol - 1);

        GameObject go = null;
        int priority = -1;
        for (int i = start_row; i <= end_row; i++)
        {
            for (int j = start_col; j <= end_col; j++)
            {
                GameObject findObject = BoardManager.boardManager.GetEnermyObjectOrNULL(i, j);
                if (findObject!=null&&(priority==-1||priority<BoardManager.boardManager.GetPriorityInBoard(i,j)))
                {
                    go = findObject;
                    priority= BoardManager.boardManager.GetPriorityInBoard(i,j);
                }
            }
        }
        return go;
    }

    public bool IsDetectedObjectInRange(Tower tower, GameObject dectedObject)
    {
        throw new System.NotImplementedException();
    }
}


public interface FixedTargetable
{
   bool IsTargetable(Tower tower, int row, int col, int range);
   void SetTarget(Tower tower, int row, int col, int range);
   bool IsTargetting();
}

class GridTargeting : FixedTargetable
{
    int _targetRow, _targetCol;

    public void Init()
    {
        _targetRow = _targetCol = -1;
    }
    public bool IsTargetable(Tower tower, int targeted_row, int targeted_col, int range)
    {
        int start_row = (tower.placedRow - range > 0 ? tower.placedRow - range : 0);
        int start_col = (tower.placedCol - range > 0 ? tower.placedCol - range : 0);
        int end_row = (tower.placedRow + range < GameManager.instance.boardRow ? tower.placedRow + range : GameManager.instance.boardRow - 1);
        int end_col = (tower.placedCol + range < GameManager.instance.boardCol ? tower.placedCol + range : GameManager.instance.boardCol - 1);
        return start_row <= targeted_row && targeted_row <= end_row && start_col <= targeted_col && targeted_col <= end_col;
    }

    public bool IsTargetting()
    {
        return _targetRow < 0 || _targetCol < 0;
    }

    public void SetTarget(Tower tower, int row, int col, int range)
    {
        if(IsTargetable(tower, row, col, range))
        {
            _targetRow=row;
            _targetCol=col;
        }
    }
}
