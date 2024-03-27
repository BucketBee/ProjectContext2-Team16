using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBuildings : MonoBehaviour
{ 
    [SerializeField]
    private Material[] _materials;
    [SerializeField]
    private ParticleSystem _particle;

    private MeshRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        if (_materials.Length != 0)
        {
            _renderer.sharedMaterial = _materials[0];
        }
    }
    public void Change()
    {
        if(_materials.Length != 0)
        {
            _renderer.sharedMaterial = _materials[1];
        }
      
        if(_particle != null )
        {
            _particle.Play();
        }
    }
    private void OnDisable()
    {
        if (_particle != null)
        {
            _particle.Stop();
        }
    }
}
