using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
     private float speed = 0.02f;
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
    
}
