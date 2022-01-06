using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float time = 0;
    private float _speed=0.1f;
    private bool _getTargetPos=true;

    private void Start()
    {
        _target = SearchEnemy.Nearest;
    }
    private void FixedUpdate()
    {
        TimeForDestroy();
        MoveToEnemy();
    }
    private void MoveToEnemy()
    {
        if (gameObject.activeSelf && _getTargetPos)
        {
            _target = SearchEnemy.Nearest;
            _getTargetPos = false;
        }
        if (transform.position != SearchEnemy.Nearest.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed);
        }
    }
    private void TimeForDestroy()
    {
        time += Time.deltaTime;
        if (time >= 10f)
        {
            gameObject.SetActive(false);
            _getTargetPos = true;
            time = 0;
        }
    }
}
