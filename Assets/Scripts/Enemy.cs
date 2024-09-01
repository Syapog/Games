using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float move_speed;
    public float rotation_speed;
    public Transform enemy;
    public NavMeshAgent agent;
    public GameObject BoomPrefab;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType <Player> ().transform;
    }

    void Update()
    {
        agent.SetDestination(player.position);
        var look_dir = player.position - enemy.position;
        look_dir.y = 0;
        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
        //enemy.position += enemy.forward * move_speed * Time.deltaTime;
    }

    public void Boom()
    {
        GameObject boom = Instantiate(BoomPrefab, transform.position, Quaternion.identity);
        Destroy(boom, 2f);
        Destroy(gameObject);
    }


}