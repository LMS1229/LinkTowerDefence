using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager
{
    UIManager uiManager;
    
    public void SetUIManager(UIManager uiInstance)
    {
        Debug.Assert(uiInstance!= null);
        this.uiManager = uiInstance;
    }
}
