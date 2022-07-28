using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : Enermy
{
    public override void Move()
    {
        this.mRigidbody.velocity = Vector3.forward * mSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
