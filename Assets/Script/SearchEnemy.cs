using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour
{
    [SerializeField] private float _searchRange = 9;
    private GameObject[] _enemy;
    public GameObject _closest;
    public static Transform Nearest;
    private void Start()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void Update()
    {
        Nearest = FindClosestEnemy().transform;
        
    }
    public GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in _enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                _closest = go;
                distance = curDistance;
            }
        }
        return _closest;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(_searchRange, 0, _searchRange));
    }

}
