using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void StartBullet(Vector2 startPosition, Vector2 endPosition, float MoveSpeed = 10f)
    {
        StartCoroutine(move());
        IEnumerator move()
        {
            float _time = 0f;
            while (_time < 1)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector2.Lerp(transform.position, endPosition, _time);
                _time += Time.deltaTime * MoveSpeed;
            }
            Destroy(gameObject);
        }
    }
}
