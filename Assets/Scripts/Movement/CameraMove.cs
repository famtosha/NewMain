using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] private float CameraMin = 0;
    [SerializeField] private float CameraMax = 0;

    public bool IsInRoom = false;

    private Transform CameraPos = null;
    private Transform PlayerPos = null;
    private Camera Camera = null;

    private float _time = 0f;

    private void Start()
    {
        PlayerPos = GameMan.instance.Player.transform;
        CameraPos = gameObject.transform;
        Camera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (IsInRoom)
        {
            _time += 0.03f;
        }
        else
        {
            _time -= 0.03f;
        }

        _time = Mathf.Clamp(_time, 0, 1);

        Vector3 NewPos = new Vector3(CameraPos.position.x, CameraPos.position.y, CameraPos.position.z);
        CameraPos.position = NewPos;
        Camera.orthographicSize = Mathf.Lerp(CameraMax, CameraMin, _time * _time);
    }
}