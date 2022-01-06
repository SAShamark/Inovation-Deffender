using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private float _rotationSpeed = 10;
    const int x = 0;
    private void Start()
    {

    }
    private void Update()
    {
        LookAtEnemy();
    }
    private void LookAtEnemy()
    {
        Vector3 direction = SearchEnemy.Nearest.position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);        
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
}
