using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager
{

    static private BoardManager _instance;

    static public BoardManager boardManager
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BoardManager();
            }
            return _instance;
        }
    }

    private SortedSet<GameObject>[][] mSetOfEnermyInBoard;
    private Grid[][] mGridMatrix;
    private int[][] mPriorityTargetingAtGrid;
    private bool[][] mIsLoadGrid;

    private BoardManager()
    {
        init();
    }
    public GameObject GetEnermyObjectOrNULL(int row, int col)
    {
        if (mSetOfEnermyInBoard[row][col].Count == 0)
        {
            return null;
        }
        else
        {
            return mSetOfEnermyInBoard[row][col].Min;
        }
    }

    public bool IsPlacedEnermy(int row, int col, GameObject enermy)
    {
        return mSetOfEnermyInBoard[row][col].Contains(enermy);
    }
    public void SetGrid(int i, int j, Grid grid)
    {
        mGridMatrix[i][j] = grid;
    }

    public Grid GetGrid(int i, int j)
    {
        return mGridMatrix[i][j];
    }
    public void PushEnermy(int row, int col, GameObject enermy)
    {
        this.mSetOfEnermyInBoard[row][col].Add(enermy);
    }
    public void PopEnermy(int row, int col, GameObject enermy)
    {
        this.mSetOfEnermyInBoard[row][col].Remove(enermy);
    }
    public int GetPriorityInBoard(int row, int col)
    {

        if (IsInBound(row, col) == false || mIsLoadGrid[row][col] == false)
        {
            return -1;
        }
        else
        {
            return mPriorityTargetingAtGrid[row][col];
        }
    }

    private void init()
    {
        this.mSetOfEnermyInBoard = new SortedSet<GameObject>[GameManager.instance.boardRow][];
        this.mGridMatrix = new Grid[GameManager.instance.boardRow][];
        this.mIsLoadGrid = new bool[GameManager.instance.boardRow][];
        this.mPriorityTargetingAtGrid = new int[GameManager.instance.boardRow][];

        for (int i = 0; i < GameManager.instance.boardRow; i++)
        {
            this.mSetOfEnermyInBoard[i] = new SortedSet<GameObject>[GameManager.instance.boardCol];
            this.mIsLoadGrid[i] = new bool[GameManager.instance.boardCol];
            this.mGridMatrix[i] = new Grid[GameManager.instance.boardCol];
            this.mPriorityTargetingAtGrid[i] = new int[GameManager.instance.boardCol];
            for (int j = 0; j < GameManager.instance.boardCol; j++)
            {
                mSetOfEnermyInBoard[i][j] = new SortedSet<GameObject>();
                mIsLoadGrid[i][j] = false;
                mPriorityTargetingAtGrid[i][j] = -1;
            }
        }
    }
    private bool IsInBound(int row, int col)
    {
        return row >= 0 && row <= GameManager.instance.boardRow && col >= 0 && col <= GameManager.instance.boardCol;
    }
}
