using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enermy : MonoBehaviour
{
    protected Rigidbody mRigidbody;
    [SerializeField]
    protected int mHp;
    protected GameManager.DIR mNowMovingDir;
    protected int mTurningCount;
    protected float mSpeed;
    void Start()
    {
        this.transform.position = EnermyManager.instance.respawnPoint;
        this.mNowMovingDir = EnermyManager.instance.respawnDir;
        mTurningCount = 0;
    }

    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        if (CheckGoalTurningPoint())
        {
            GameManager.DIR nextDir= EnermyManager.instance.getTurningDir(mTurningCount);
            this.transform.position = EnermyManager.instance.getTurningPoint(mTurningCount);
            ++mTurningCount;
            
            mNowMovingDir = nextDir;
        }
    }
    abstract public void Move();
    private bool CheckGoalTurningPoint()
    {
        if (mTurningCount < EnermyManager.instance.turningPointCount)
        {
            Vector3 nowGoalPoint = EnermyManager.instance.getTurningPoint(mTurningCount);
            switch (mNowMovingDir)
            {
                case GameManager.DIR.UP:
                    return transform.position.x <= nowGoalPoint.x;
                case GameManager.DIR.DOWN:
                    return transform.position.x >= nowGoalPoint.x;
                case GameManager.DIR.RIGHT:
                    return transform.position.z >= nowGoalPoint.z;
                case GameManager.DIR.LEFT:
                    return transform.position.z <= nowGoalPoint.z;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}
