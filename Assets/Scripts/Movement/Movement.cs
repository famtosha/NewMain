using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static event Action OnPlayerMove;

    [SerializeField] [Range(0, 1)] private float cameraMovePower = 0.1f;
    private PlayerStats playerStats;
    private Transform playerTransform;
    private Transform playerCameraTransform;
    private Camera playerCameraCont;
    private Rigidbody2D playerRB;

    private void Start()
    {
        playerTransform = transform;
        GameMan.instance.Player = gameObject;
        playerCameraTransform = Camera.main.gameObject.transform;
        playerCameraCont = playerCameraTransform.gameObject.GetComponent<Camera>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerStats = gameObject.GetComponent<Stats>().playerStats;
    }

    private void Update()
    {
        MovePlayer();
        MoveCamera();
        LookAtCursor();
    }
    void MoveCamera()
    {
        var playerPos = playerTransform.position;
        var mousePos = playerCameraCont.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.T))
        {
            cameraMovePower = 0.3f;
        }
        else
        {
            cameraMovePower = 0f;
        }
        var center = Vector2.LerpUnclamped(playerPos, mousePos, cameraMovePower);
        playerCameraTransform.position = new Vector3(center.x, center.y, playerCameraTransform.position.z);
    }

    void MovePlayer()
    {
        var moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRB.MovePosition((Vector2)playerRB.transform.position + moveDirection * playerStats.MovementSpeed * Time.deltaTime);

        if (moveDirection != Vector2.zero)
        {
            OnPlayerMove?.Invoke();
        }
    }

    void LookAtCursor()
    {
        var mousePostion = Input.mousePosition;
        mousePostion.z = 10;
        mousePostion = playerCameraCont.ScreenToWorldPoint(mousePostion);
        var lookDirection = new Vector3(mousePostion.x - playerTransform.position.x, mousePostion.y - playerTransform.position.y);
        playerTransform.up = lookDirection;
    }
}
