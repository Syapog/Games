using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURRET : MonoBehaviour
{
    public float ShootRate = 2f;
    public GameObject bullet;
    public Transform ShootPoint;
    Transform player;
    float shootTimer = 0f;

    private void Start()
    {
        player = FindObjectOfType<ZDOROVIE>().GetComponent<Transform>();

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,player.position) <= 10f)
        {
            transform.LookAt(player);
            if (shootTimer < ShootRate)
                shootTimer += Time.deltaTime;
            else
            {
                shootTimer = 0f;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject pulia = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
        Destroy(pulia, 3f);
    }
}
