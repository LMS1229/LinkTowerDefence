using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyManager
{
    public int turningPointCount
    {
        get { return mTurningPoint.Length; }
    }
    [SerializeField]
    private Vector3 mRespawnPoint;
    public Vector3 respawnPoint
    {
        get { return mRespawnPoint; }
    }
    [SerializeField]
    private GameManager.DIR mRespawnDir;
    public GameManager.DIR respawnDir
    {
        get { return mRespawnDir; }
    }
    static private EnermyManager _instance;
    static public EnermyManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new EnermyManager();
            }
            return _instance;
        }
    }




    private GameManager.DIR[] mTurningDirection;
    public GameManager.DIR getTurningDir(int turnCount)
    {
        return mTurningDirection[turnCount];
    }
    private Vector3[] mTurningPoint;
    public Vector3 getTurningPoint(int turnCount)
    {
        return mTurningPoint[turnCount]; ;
    }

    private EnermyManager()
    {

    }
 

}
