using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    private float _inspirationMeter;
    private int _inspirationAmountNpcs;

    private List<GameObject> _npcs = new List<GameObject>();
    private void Start()
    {
        
    }
    private void SpawnNpcs()
    {
      
    }
    private int CalculateInspiredNpcs()
    {
        return _inspirationAmountNpcs = (int)(_npcs.Count * (_inspirationMeter/100));
    }

    private void ChangeTexturesNpcs()
    {
        int i = 0;
        while(i < CalculateInspiredNpcs())
        {
            
            i++;
        }
    }
    
}
