using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlayer : MonoBehaviour
{
    private Rigidbody rd;
    private int speed = 5;
    private bool isGround = true;

    public float sensitivity = 5f; // чувствительность мыши
    public float headMinY = -40f; // ограничение угла для головы
    public float headMaxY = 40f;
    public GameObject Eye;
    private float rotationY;

    public GameObject PlayerCamera;

    [System.Obsolete]
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.freezeRotation = true; //запред вращения и падения
        PlayerCamera.SetActive(true); //аетив или деактив
        Screen.lockCursor = true;
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 6;
        else
            speed = 3;

        //поворот камеры за курсором
        float rotationX = gameObject.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        transform.rotation = Quaternion.Euler(0, rotationX, 0);
        Eye.transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0);

        //if (Input.GetKey(KeyCode.Space) && isGround)
        //{
        //    rd.AddForce(new Vector3(0, 370f, 0f));
        //    isGround = false;
        //}

    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.transform.tag == "Ground" && other.contacts[0].normal == Vector3.up)
    //    {
    //        isGround = true;
    //    }
    //}
}
