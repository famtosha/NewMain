using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [Range(0,2)] public int MoveType = 0;
    private GameObject PlayerCamera;
    private Rigidbody2D PlayerRB;

    private void Start()
    {
        GameMan.instance.Player = this.gameObject;
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
        Vector2 MoveDirection = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
                  
        switch (MoveType)
        {
            case 0:
                PlayerRB.AddForce(MoveDirection, ForceMode2D.Impulse);
                break;
            case 1:
                PlayerRB.MovePosition((Vector2)PlayerRB.transform.position + MoveDirection);
                break;
            case 2:
                PlayerRB.velocity = MoveDirection;
                break;
        }
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
