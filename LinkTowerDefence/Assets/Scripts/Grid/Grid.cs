using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    bool isSelect;
    bool isWall;
    int _row, _col;
    public int placedRow
    {
        get { return _row; }
    }
    public int placedCol
    {
        get { return _col; }
    }

    public void SetPosition(int row, int col)
    {
        this._row = row;
        this._col = col;
        this.gameObject.transform.position=new Vector3(row, 0.0f, col);
       BoardManager.boardManager.SetGrid(row, col, this);
    }
    public void SetIsWall(bool flag)
    {
        this.isWall = flag;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (this.isWall == false)
        {
            if (other.tag.CompareTo("Enermy") == 0)
            {
                BoardManager.boardManager.PushEnermy(placedRow, placedCol, other.gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (this.isWall == false)
        {
            if (other.tag.CompareTo("Enermy") == 0)
            {
                BoardManager.boardManager.PopEnermy(placedRow, placedCol, other.gameObject);
            }
        }
    }

    public void Click()
    {
        if (isSelect)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            Tower placedTower = TowerManager.instance.GetTowerInBoard(placedRow, placedCol);
            if (placedTower != null)
            {
                //UI
            }
        }
        else {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        isSelect = !isSelect;
    }

    public void UnClick()
    {
        
    }
}
