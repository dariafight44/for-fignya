using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   
     private float speed = 0.05f;
     public int damage = 500;
    void FixedUpdate()
    {
       Vector3 objectPosition = transform.position;
       objectPosition.y -= speed;
       transform.position = objectPosition;
       if(ScreenHelper.IsOnScreen(transform.position) == false)
       {
            Destroy(gameObject);

       }
    }
    void Update()
    {
        
    }
}
