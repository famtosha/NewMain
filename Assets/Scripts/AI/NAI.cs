using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAI : MonoBehaviour
{
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
    private float MoveSpeed = 15;
    private float FOV = 175;

    private float TimeLeftToCheck = 0;
    private float ChaseTimeLeft = 0;


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

    public void Update()
    {
        TimeLeftToCheck += Time.deltaTime;
        if (ChaseTimeLeft > 0) ChaseEnemy();

        if (TimeLeftToCheck >= CheckSpeed)
        {
            if (CanSeeTarget())
            {
                ChaseTimeLeft = ChaseTime;
                TimeLeftToCheck = 0;
            }
            else
            {
                ChaseTimeLeft -= 0.1f;
            }
        }
    }

    public bool CanSeeTarget()
    {      
        Vector2 TargetPosition = Target.transform.position; //позиция таргета
        Vector2 MyPosition = transform.position;            //собственная позиция
        Vector2 FOVCenter = transform.up;                   //центр зрения

        Vector2 TargetDirect = TargetPosition - MyPosition; //вектор к таргенту
        Vector2 FOVCenterDirection = FOVCenter;             //вектор к центра зрения
            
        float Angle = Vector2.Angle(TargetDirect, FOVCenterDirection); //угол между предыдущими двумя векторами 

        RaycastHit2D Hit = Physics2D.Raycast(MyPosition, TargetDirect, LookDist, ~(Ignore));
        
        if (Hit)
        {
            if (Hit.transform.gameObject == Target) //проверка нет ли стены перед ним и на дистанцию 
            {
                if (Angle < FOV / 2)            //проверка проверка на поподение в поле зрения 
                {
                    return true;
                }
            }
        }   
        return false;
    }
}
