using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialNpc : MonoBehaviour
{
    [SerializeField]
    private Material[] _materials;

    private SkinnedMeshRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    private void Start()
    {
        _renderer.sharedMaterial = _materials[0];
    }
    public void Changematrial()
    {

        if (_renderer.sharedMaterial = _materials[0])
        {
            _renderer.sharedMaterial = _materials[1];
        }
        else
        {
            _renderer.sharedMaterial = _materials[0];
        }
    }
}

