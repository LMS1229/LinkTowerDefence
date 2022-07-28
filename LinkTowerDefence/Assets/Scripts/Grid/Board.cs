using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject gridCell;

    private void Awake()
    {
        for(int i = 0; i < GameManager.instance.boardRow; ++i)
        {
            for(int j=0;j<GameManager.instance.boardCol; ++j)
            {
                GameObject gridObject=GameObject.Instantiate(gridCell);
                if (i == 0 && j == 0)
                {
                    gridObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                gridObject.GetComponent<Grid>().SetPosition(i, j);
                gridObject.GetComponent<Grid>().SetIsWall(false);
                gridObject.transform.parent = this.transform;
            }
        }
    }
}
