using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public void ClickGrid(int row, int col)
    {
        Grid nowClickGrid = BoardManager.boardManager.GetGrid(row, col);
        nowClickGrid.Click();
    }
}
