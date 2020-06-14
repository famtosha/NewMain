using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan instance = null;
    public GameObject Player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Player = gameObject;
    }
}
