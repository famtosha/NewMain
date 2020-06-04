using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 1;
    [SerializeField] [Range(0, 1)] private float CameraMovePower = 0.1f;
    private Transform PlayerTransform;
    private Transform PlayerCameraTransform;
    private Camera PlayerCameraCont;
    private Rigidbody2D PlayerRB;

    private void Start()
    {
        PlayerTransform = transform;
        GameMan.instance.Player = this.gameObject;
        PlayerCameraTransform = Camera.main.gameObject.transform;
        PlayerCameraCont = PlayerCameraTransform.gameObject.GetComponent<Camera>();
        PlayerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        MoveCamera();
        LookAtCursor();
    }
    void MoveCamera()
    {
        Vector2 PlayerPos = PlayerTransform.position;
        Vector2 MousePos = PlayerCameraCont.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Center = Vector2.LerpUnclamped(PlayerPos, MousePos, CameraMovePower);
        PlayerCameraTransform.position = new Vector3(Center.x, Center.y, PlayerCameraTransform.position.z);
    }

    void MovePlayer()
    {
        Vector2 MoveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        PlayerRB.MovePosition((Vector2)PlayerRB.transform.position + MoveDirection * Speed * Time.deltaTime);
    }

    void LookAtCursor()
    {
        var y = Input.mousePosition;
        y.z = 10;
        y = PlayerCameraCont.ScreenToWorldPoint(y);
        var dir = new Vector3(y.x - PlayerTransform.position.x, y.y - PlayerTransform.position.y);
        PlayerTransform.up = dir;
    }
}
