using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAI : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerDetect;

    public LayerMask Ignore;

    public GameObject Target;
    public GameObject Weapon;
    public Rigidbody2D RB;

    private float ChaseTime = 20;
    private float RotationTime = 5;
    private float ReactionDelay = 1;
    private float CheckSpeed = 0.1f;
    private float LookDist = 10;
    private float CompDist = 5;
    private float MoveSpeed = 3;
    private float FOV = 175;

    private float TimeLeftToCheck = 0;
    private float ChaseTimeLeft = 0;


    private void MoveToPos(Vector2 position, float timeOut = 10f)
    {
        timeOut += Time.deltaTime;
    }

    private void PlayerDetectHandler(GameObject sender)
    {
        if (sender != gameObject)
        {
            MoveToPos(sender.transform.position);
        }
    }

    public void LookAtTarget()
    {
        Vector2 TargetPosition = Target.transform.position;
        Vector2 MyPosition = transform.position;
        Vector2 TargetDirection = TargetPosition - MyPosition;

        transform.up = TargetDirection;
        Weapon.GetComponent<Item>().UseItem(out bool isused);
    }

    public void MoveToTarget()
    {
        Vector2 TargetPosition = Target.transform.position;
        Vector2 MyPosition = transform.position;
        if((ChaseTimeLeft > 0))
        {
            RB.AddForce((transform.up) * MoveSpeed);
        }
        else if(Vector2.Distance(TargetPosition, MyPosition) >= CompDist)
        {
            RB.AddForce((transform.up) * MoveSpeed);
        }       
    }

    public void ChaseEnemy()
    {
        if (!(ChaseTimeLeft < ChaseTime)) LookAtTarget();
        MoveToTarget();
    }

    private void Start()
    {
        OnPlayerDetect += PlayerDetectHandler;
    }

    //TimeLeftToCheck += Time.deltaTime;
    //    if (ChaseTimeLeft > 0) ChaseEnemy();
    //    if (TimeLeftToCheck >= CheckSpeed)
    //    {
    //        if (CanSeeTarget())
    //        {
    //            ChaseTimeLeft = ChaseTime;
    //            TimeLeftToCheck = 0;
    //        }
    //        else
    //        {
    //            ChaseTimeLeft -= 0.1f;
    //        }
    //    }

    public void Update()
    {

    }

    public bool CanSeeTarget()
    {      
        Vector2 TargetPosition = Target.transform.position; 
        Vector2 MyPosition = transform.position;           
        Vector2 FOVCenter = transform.up;                  

        Vector2 TargetDirect = TargetPosition - MyPosition; 
        Vector2 FOVCenterDirection = FOVCenter;           
            
        float Angle = Vector2.Angle(TargetDirect, FOVCenterDirection); 

        RaycastHit2D Hit = Physics2D.Raycast(MyPosition, TargetDirect, LookDist, ~(Ignore));
        
        if (Hit)
        {
            if (Hit.transform.gameObject == Target) 
            {
                if (Angle < FOV / 2)           
                {
                    return true;
                }
            }
        }   
        return false;
    }
}
