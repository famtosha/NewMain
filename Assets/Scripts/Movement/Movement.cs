using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 1;
    public GameObject camera;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        Vector3 MoveDirection = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime);

        transform.Translate(MoveDirection);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
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
