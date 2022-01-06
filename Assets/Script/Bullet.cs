using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time = 0;
    private float _speed=0.1f;
    private Transform _target;
    private bool _getTargetPos=true;

    private void Start()
    {
        _target = SearchEnemy.Nearest;
    }
    private void FixedUpdate()
    {
        if(gameObject.activeSelf&&_getTargetPos)
        {
            _target = SearchEnemy.Nearest;
            _getTargetPos = false;
        }

        if (transform.position != SearchEnemy.Nearest.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        }
        time += Time.deltaTime;
        if(time>=10f)
        {
            gameObject.SetActive(false);
            _getTargetPos = true;
            time = 0;
        }
    }
}
