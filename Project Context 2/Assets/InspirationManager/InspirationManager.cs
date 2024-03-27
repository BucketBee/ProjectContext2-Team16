using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspirationManager : MonoBehaviour
{
    static public float _inspirationMeter { get; private set; } = 20f;

    static public void ChangeInspirationMeter(float amount)
    {
            _inspirationMeter += amount;
        Debug.Log(_inspirationMeter);
    }
    private void Start()
    {
        _inspirationMeter = 20f;
    }
}
