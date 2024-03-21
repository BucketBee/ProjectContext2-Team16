using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _npcs = new List<GameObject>();
    [SerializeField]
    private GameObject _npcPrefab;
    [SerializeField]
    private Vector3 _center;
    [SerializeField]
    private Vector3 _size;
    [SerializeField]
    private Transform _centrePoint;
    [SerializeField]
    private int amountOfNpcs;

   
    private int _inspirationAmountNpcs;

    private void Awake()
    {
        SpawnNpcs();
    }
    private void SpawnNpcs()
    {
        StartCoroutine(Spawning());
    }

    private int CalculateInspiredNpcs()
    {
        return _inspirationAmountNpcs = (int)(_npcs.Count * (InspirationManager._inspirationMeter / 100));
    }

    private void ChangeTexturesNpcs()
    {
        int i = 0;
        while (i < CalculateInspiredNpcs())
        {
            Debug.Log(CalculateInspiredNpcs());
            ChangeMaterialNpc changeMaterialNpc = _npcs[i].GetComponent<ChangeMaterialNpc>();
            if (changeMaterialNpc == null)
                return;

            changeMaterialNpc.Changematrial();
            i++;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(_center, _size);
    }
    IEnumerator Spawning()
    {
        int i = 0;
        while (i <= amountOfNpcs)
        {
            Vector3 pos;

            do
            {
                pos = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), _size.y, Random.Range(-_size.z / 2, _size.z / 2));
            }
            while (!NavMesh.SamplePosition(pos, out NavMeshHit _, 1.0f, NavMesh.AllAreas));

            GameObject instance = Instantiate(_npcPrefab, pos, Quaternion.identity);
            NPCAI npc = instance.GetComponent<NPCAI>();
            npc.centrePoint = _centrePoint;
            _npcs.Add(instance);
            i++;
            yield return new WaitForSeconds(.003f);
        }
        yield return new WaitForSeconds(.05f);
        ChangeTexturesNpcs();
    }
}
