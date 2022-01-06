using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent our;
    [SerializeField] private Transform _main;
    [SerializeField] private Transform _player;

    //  [SerializeField] private TMP_Text _hp;
    //public float _numberHP;
    public float Distance = 3;
  //  public float speed = 2;
    void Start()
    {
        // _hp.text = _numberHP.ToString();
        our = GetComponent<NavMeshAgent>();
       // our.speed = speed;
    }

    /* public void SetHp(int hp)
     {
         _numberHP = hp;
     }*/

    void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) < Distance)
        {
            our.destination = _player.position;
        }
        else
            our.destination = _main.position;
    }
}