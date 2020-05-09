using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private LayerMask Ignore;
    private Weapon weapon;
    private float UpdateTime = 0.2f;
    private float TimeLeft;

    private void Start()
    {
        TimeLeft = UpdateTime;
        weapon = Weapon.GetComponent<Weapon>();
    }

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        if(TimeLeft <= 0)
        {
            TimeLeft = UpdateTime;

            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Player.transform.position - transform.position,30, ~Ignore);
            
            if(hit)
            {
                print(hit.transform.gameObject.name + " " + Player.name);
                if (hit.transform.gameObject.name == Player.name)
                {                  
                    LookAtPlayer();
                    weapon.UseItem(out bool shit);
                    RB.AddForce((Player.transform.position - gameObject.transform.position).normalized * 50);
                }
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red, 0.2f);
            }
        }
        
    }

    void LookAtPlayer()
    {
        var y = Player.transform.position;
        var dir = new Vector3(y.x - transform.position.x, y.y - transform.position.y);
        transform.up = dir;
    }
}
