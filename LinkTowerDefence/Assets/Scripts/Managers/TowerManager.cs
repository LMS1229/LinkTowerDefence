using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : IngameManager
{
    public enum TOWER_TYPE
    {
        ATTACK_TOWER=0,
        SUPPORT_TOWER=1,
        POWER_TOWER=2,
        LINKING_TOWER=3,
        NONE
    }

    public enum ATTACK_WAY
    {
        RECOGNITION=0,
        TARGETING,
    }

    public enum ATTACK_TYPE
    {
        DEFAULT,
        PERFORATOR,
        RANGE,
    }
    public enum SUPPORT_WAY
    {
        ACTIVE,
        PASSIVE,
    }
    public enum SUPPORT_TYPE
    {
        DEBUFF,
        BUFF,
    }

    public enum POWER_TOWER_EFFECT_WAY
    {
        NOT_UNIQUE,
        UNIQUE,
    }

    public enum POWER_TOWER_NON_UNIQUE_EFFECT_TYPE
    {
        ATTACK_DAMAGE_UP,
        BUFF_UP,
        DEBUFF_UP,
        NONE,
    }

    public enum POWER_TOWER_UNIQUE_EFFECT_TYPE
    {
        ATTACK_DAMAGE_MUL,
        RANGE_UP,
        ATTACK_COOLDOWN,
        BUFF_UP_MUL,
        DEBUFF_UP_MUL,
        NONE,
    }

    bool[][] mIsIntalledTowerPosition;
    bool[][] mLinkingRoute;
    Tower[][] mBoardStateAboutTower;

    

    static private TowerManager _instance;
    static public TowerManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TowerManager();
            }
            return _instance;
        }
    }

    static private Dectectable _targetingDectector = null;

    static public Dectectable targetingDectector
    {
        get
        {
            if (_targetingDectector == null)
            {
                _targetingDectector = new TargetingDectecter();
            }
            return _targetingDectector;
        }
    }
    static private FixedTargetable _gridTargetor = null;
    static public FixedTargetable gridTargetor
    {
        get
        {
            if (_gridTargetor == null)
            {
                _gridTargetor = new GridTargeting();
            }
            return _gridTargetor;
        }
    }

    private TowerManager()
    {
        this.mLinkingRoute = new bool[GameManager.instance.boardRow][];
        this.mIsIntalledTowerPosition = new bool[GameManager.instance.boardRow][];
        for (int i = 0; i < GameManager.instance.boardRow; i++)
        {
            this.mLinkingRoute[i] = new bool[GameManager.instance.boardCol];
            this.mIsIntalledTowerPosition[i] = new bool[GameManager.instance.boardCol];
        }
    }


 
    public Tower GetTowerInBoard(int row, int col)
    {
        if(0<=row && row < GameManager.instance.boardRow&&0<=col&&col < GameManager.instance.boardCol)
        {
            return mBoardStateAboutTower[row][col];
        }
        return null;
    }
    public bool InstallTower(int row, int col, Tower installedTower)
    {
        if (mIsIntalledTowerPosition[row][col])
        {
            return false;
        }
        this.mBoardStateAboutTower[row][col]=installedTower;
        return mIsIntalledTowerPosition[row][col] = true;
    }

    //TODO:
    // (row, col) 가 포함되어 있는 경로 반환
    public bool[][] GetLinkingRoute(int row, int col)
    {

        return mLinkingRoute;
    }
}
