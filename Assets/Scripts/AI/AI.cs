﻿using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{
    public static event Action<GameObject> OnPlayerDetect;

    [SerializeField] private GameObject Target = null;
    [SerializeField] private GameObject weapon = null;
    [SerializeField] private Behaviour behaviourNow = Behaviour.Idle;
    [SerializeField] private LayerMask Ignore = 0;
    [SerializeField] [Range(0, 360)] private float FOV = 180;
    [SerializeField] private float LookDist = 10;
    [SerializeField] private float Speed = 5f;
    [SerializeField] private bool ShowGizmo = false;
    private Target target = null;
    private Rigidbody2D Rigidbody2D = null;
    private bool IsBusy = true;
    private float NextCommand = 3;
    private float NextCommandLeft = 0;

    private enum Behaviour
    {
        Idle,
        Chase,
        Search
    }

    private void OnDrawGizmos()
    {
        if (ShowGizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, LookDist);
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 3);
        }
    }

    private void Start()
    {
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Target = GameMan.instance.Player;
        NextCommandLeft = NextCommand;
        target = gameObject.GetComponent<Target>();
        OnPlayerDetect += PlayerDetectHandler;
        target.OnDeath += DeathHandler;
    }

    private void DeathHandler()
    {
        OnPlayerDetect -= PlayerDetectHandler;
    }


    private void Update()
    {
        if (CanSeeTarget(Target))
        {
            if (behaviourNow != Behaviour.Chase)
            {
                OnPlayerDetect(gameObject);
                behaviourNow = Behaviour.Chase;
                StopAllCoroutines();
                ChaseTarget();
            }
        }
        else
        {
            if (behaviourNow == Behaviour.Chase)
            {
                MoveToPostion(Target.transform.position);
                behaviourNow = Behaviour.Search;
            }
            else
            {
                if (behaviourNow != Behaviour.Search)
                {
                    behaviourNow = Behaviour.Idle;
                }
            }
        }

        NextCommandLeft += Time.deltaTime;
        if (NextCommand < NextCommandLeft)
        {
            NextCommandLeft = 0;
            switch (behaviourNow)
            {
                case Behaviour.Idle:
                    MoveToPostion((Vector2)transform.position + new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)));
                    break;
            }
        }
    }

    public void PlayerDetectHandler(GameObject sender)
    {
        try
        {
            if (sender != gameObject)
            {
                behaviourNow = Behaviour.Search;
                MoveToPostion(sender.transform.position);
            }
        }
        catch
        {

        }

    }

    public bool CanSeeTarget(GameObject target)
    {
        Vector2 TargetPosition = target.transform.position;
        Vector2 MyPosition = transform.position;
        Vector2 FOVCenter = transform.up;

        Vector2 TargetDirect = TargetPosition - MyPosition;
        Vector2 FOVCenterDirection = FOVCenter;

        float Angle = Vector2.Angle(TargetDirect, FOVCenterDirection);

        if (Angle < FOV / 2)
        {
            RaycastHit2D Hit = Physics2D.Raycast(MyPosition, TargetDirect, LookDist, ~(Ignore));
            if (Hit)
            {
                if (Hit.transform.gameObject == target)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void LookAtPoint(Vector3 point)
    {
        Vector2 MyPosition = transform.position;
        Vector2 TargetDirection = (Vector2)point - MyPosition;
        transform.up = TargetDirection;
    }

    IEnumerator CMoveToPos(Vector2 pos)
    {
        IsBusy = true;
        while (IsBusy)
        {
            Rigidbody2D.AddForce((pos - (Vector2)transform.position).normalized * Speed);
            LookAtPoint(pos);
            float distanse = Vector2.Distance(transform.position, pos);
            if (distanse < 0.1f)
            {
                IsBusy = false;
                if (behaviourNow == Behaviour.Search)
                {
                    behaviourNow = Behaviour.Idle;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator CChaseTarget()
    {
        while (behaviourNow == Behaviour.Chase)
        {
            LookAtPoint(Target.transform.position);
            weapon.GetComponent<Item>().UseItem(out bool isused);
            Rigidbody2D.AddForce(((Vector2)Target.transform.position - (Vector2)transform.position).normalized * Speed);
            Debug.DrawLine(transform.position, Target.transform.position);
            float distanse = Vector2.Distance(transform.position, (Vector2)Target.transform.position);
            if (distanse < 0.1f)
            {
                IsBusy = false;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void MoveToPostion(Vector2 position)
    {
        Debug.DrawLine(transform.position, position, Color.green, 1);
        StartCoroutine(CMoveToPos(position));
    }

    private void ChaseTarget()
    {
        Debug.DrawLine(transform.position, Target.transform.position, Color.green, 1);
        StartCoroutine(CChaseTarget());
    }
}
