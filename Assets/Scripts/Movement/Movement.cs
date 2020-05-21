using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    private GameObject PlayerCamera;
    private Rigidbody2D PlayerRB;

    private void Start()
    {
        PlayerCamera = Camera.main.gameObject;
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        MoveCamera();
        Look();      
    }

    void MoveCamera()
    {
        PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, PlayerCamera.transform.position.z);
    }

    void Move()
    {
        Vector3 MoveDirection = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        PlayerRB.AddForce(MoveDirection);  
    }

    void Look()
    {
        var y = Input.mousePosition;
        y.z = 10;
        y = Camera.main.ScreenToWorldPoint(y);
        var dir = new Vector3(y.x - transform.position.x, y.y - transform.position.y);
        transform.up = dir;
    }
}
