using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rd;
    private float speed = 5f;

    [SerializeField] private CharacterController controller;

    public float sensitivity = 5f; // чувствительность мыши
    public float headMinY = -40f; // ограничение угла для головы
    public float headMaxY = 40f;
    public GameObject Eye;
    private float rotationY;

    public GameObject PlayerCamera;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rd = GetComponent<Rigidbody>();
        rd.freezeRotation = true; //запред вращения и падения
        Cursor.visible = false;
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveY;
        controller.Move(move * speed * Time.deltaTime);

        /*
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime * speed;
            */
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

   
    }

}