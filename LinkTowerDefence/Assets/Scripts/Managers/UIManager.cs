using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] TowerObjectForUI;    //[tower_type][level]

    [SerializeField]
    private Canvas canvas;

    private static UIManager _instance = null;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
    }
    private UIManager()
    {

    }
    private Grid previousClickedGrid;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitObject;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hitObject);
            if (hitObject.collider.gameObject.tag.CompareTo("Grid") == 0)
            {
                //클릭한 오브젝트 그리드 색 변경
                int gridRow = (int)hitObject.collider.gameObject.transform.position.x;
                int gridCol = (int)hitObject.collider.gameObject.transform.position.z;
                Grid nowClickGrid = BoardManager.boardManager.GetGrid(gridRow, gridCol);
                nowClickGrid.Click();
            }
        }
    }
    static public void SetUIManagerAtIngameManager(IngameManager ingameManager)
    {
        Debug.Assert(ingameManager != null);
        if (_instance == null)
        {
            _instance = new UIManager();
        }
        ingameManager.SetUIManager(_instance);
    }

    public void ShowTowerInfomation(Tower tower)
    {
        int towerType = (int)tower.GetTowerType();
        if (towerType != (int)TowerManager.TOWER_TYPE.NONE)
        {
            GameObject towerUI = canvas.transform.GetChild(0).gameObject;
            towerUI.SetActive(true);
            TowerObjectForUI[towerType].transform.SetParent(towerUI.transform);
            TowerObjectForUI[towerType].transform.localPosition = Vector3.zero;
            TowerObjectForUI[towerType].transform.localEulerAngles = new Vector3(0, 225, 0);

        }
    }
    /*
    private string GetTowerValueType(TowerManager.TOWER_TYPE towerType)
    {
        switch (towerType){
            case TowerManager.TOWER_TYPE.ATTACK_TOWER:
                return "데미지:";
            case TowerManager.TOWER_TYPE.SUPPORT_TOWER:
                return "버프력: ";
            case TowerManager.TOWER_TYPE.LINKING_TOWER:
                return "링크 수":
            case T

        }
    }
    */
}
