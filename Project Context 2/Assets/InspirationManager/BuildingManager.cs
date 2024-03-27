using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _buildings = new List<GameObject>();

    private int _inspirationAmountBuildings;

    private int CalculateInspiredBuildings()
    {
        return _inspirationAmountBuildings = (int)(_buildings.Count * (InspirationManager._inspirationMeter / 100));
    }
    private void Start()
    {
        int i = 0;
        while (i < CalculateInspiredBuildings())
        {
            Debug.Log(CalculateInspiredBuildings());
            ChangeBuildings changeMaterialBuildings = _buildings[i].GetComponent<ChangeBuildings>();
            if (changeMaterialBuildings == null)
                return;

            changeMaterialBuildings.Change();
            i++;
        }
    }

}
