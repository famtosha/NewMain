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
            moveSpeed /= Vector2.Distance(startPosition, endPosition);
            while (_time < 1)
            {
                yield return new WaitForFixedUpdate();
                transform.position = Vector2.Lerp(startPosition, endPosition, _time);
                _time += Time.deltaTime * moveSpeed;
            }
            Destroy(gameObject);
        }
    }
}
