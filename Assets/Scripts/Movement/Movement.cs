using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 1;
    public GameObject PlayerCamera;
    public Rigidbody2D PlayerRB;

    void Update()
    {
        Move();
        Look();
        MoveCamera();
    }

    void MoveCamera()
    {
        PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, PlayerCamera.transform.position.z);
    }

    void Move()
    {
        Vector3 MoveDirection = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        PlayerRB.AddForce(MoveDirection);

        print(PlayerRB.velocity.magnitude);     
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
