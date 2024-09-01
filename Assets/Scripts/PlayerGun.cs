using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    
    public GameObject bullet;
    public float ShootRate = 0.1f;
    float shootTimer = 0f;
    public Transform ShootPoint;


    private void Start()
    {
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && shootTimer >= ShootRate)
        {
            shootTimer = 0f;
            Shoot();
        }

        shootTimer += Time.deltaTime;
        
    }

    private void Shoot()
    {
        GameObject pulia = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
        Destroy(pulia, 3f);
    }
}
