using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAtEnemies : MonoBehaviour
{

    [SerializeField] private float _timeForShooting = 2;
    [SerializeField] private Transform _pointForBullet;
    [SerializeField] private GameObject _bullet;

    private float _startPositionX;
    private float _startPositionZ;
    private bool _justStay = true;


    private void Start()
    {
        _timeForShooting = 1;
        _startPositionX = transform.position.x;
        _startPositionZ = transform.position.z;
    }
    private void FixedUpdate()
    {
        if (transform.position.x == _startPositionX && transform.position.z == _startPositionZ)
        {
            if (_justStay)
            {
                StartCoroutine(Shooting());
                _justStay = false;
            }
        }
        else
        {
            _startPositionX = transform.position.x;
            _startPositionZ = transform.position.z;
            _justStay = true;
        }
    }
    IEnumerator Shooting()
    {
        GameObject bullet = BulletObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = _pointForBullet.position;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(_timeForShooting);
        _justStay = true;


    }
}
