using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void StartBullet(Vector2 startPosition, Vector2 endPosition, float moveSpeed = 10f)
    {
        StartCoroutine(move());
        IEnumerator move()
        {
            float _time = 0f;
            bool isComplete = false;
            moveSpeed /= Vector2.Distance(startPosition, endPosition);
            while (!isComplete)
            {               
                transform.position = Vector2.Lerp(startPosition, endPosition, _time);
                _time += Time.deltaTime * moveSpeed;
                if (_time >= 1) isComplete = true;
                yield return new WaitForFixedUpdate();
            }
            Destroy(gameObject);
        }
    }
}
