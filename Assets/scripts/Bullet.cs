using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     private float speed = 0.2f;
     public int damage = 700;
    void FixedUpdate()
    {
       Vector3 objectPosition = transform.position;
       objectPosition.y += speed;
       transform.position = objectPosition;
       if(ScreenHelper.IsOnScreen(transform.position) == false)
       {
            Destroy(gameObject);

       }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
    GameObject otherObject = otherCollider.gameObject;
    EnemyShip enemyScript = otherObject.GetComponent<EnemyShip>();
     if(enemyScript != null)
     {
          enemyScript.health -= damage;
          Destroy(gameObject);
          if(enemyScript.health <=0)
          {
              enemyScript.DestroyEnemyShip();
          }
     }

    }
}
