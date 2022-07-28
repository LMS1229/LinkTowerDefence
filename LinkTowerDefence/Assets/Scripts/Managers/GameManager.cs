using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IngameManager
{
    public enum DIR
    {
        UP = 0,
        UP_RIGHT,
        RIGHT,
        DOWN_RIGHT,
        DOWN,
        DOWN_LEFT,
        LEFT,
        LEFT_UP,
        SIZE
    }
    private int mBoardRow;
    public int boardRow
    {
        get { return mBoardRow; }
    }

    private int mBoardCol;
    public int boardCol
    {
        get { return mBoardCol; }
    }

    static private GameManager _instance;
    static public GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    private int mPlayerGold;


    readonly private int[] mDeltaRow = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
    readonly private int[] mDeltaCol = new int[] { 0, 1, 1, 1, 0, -1, -1, -1 };

    private GameManager()
    {
        this.mPlayerGold = 0;
        this.mBoardCol = 16;
        this.mBoardRow = 9;
        Camera.main.transform.position = new Vector3(mBoardRow * 0.5f - 0.5f, 5.0f, mBoardCol * 0.5f - 0.5f);
        init();
    }


    public void IncreaseGold(int increasedGoldAmount)
    {
        this.mPlayerGold += increasedGoldAmount;
    }


    public int GetNextRow(int row, DIR dir)
    {
        return row + mDeltaRow[(int)dir];
    }

    public int GetNextCol(int col, DIR dir)
    {
        return col + mDeltaCol[(int)dir];
    }

    public GameManager.DIR GetReverseDIR(GameManager.DIR dir)
    {
        int i = (int)dir;
        return (GameManager.DIR)((i + 4) % (int)GameManager.DIR.SIZE);
    }


    public int AdjustRowValue(int row)
    {
        if (row < 0)
        {
            row = 0;
        }
        else if (row >= boardRow)
        {
            row = boardRow - 1;
        }
        return row;
    }

    public int AdjustColValue(int col)
    {
        if(col < 0)
        {
            col = 0;
        }
        else if (col>=boardCol)
        {
            col = boardCol - 1;
        }
        return col;
    }




    private void init()
    {

       
    }
    
}
