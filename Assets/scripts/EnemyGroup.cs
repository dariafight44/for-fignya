using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3; 
    public EnemyShip ship4;
    public bool isAlive = true;
    private System.Random generator = new System.Random();

    private float speed = 0.15f;
    private List <EnemyShip> Ships = new List<EnemyShip>();
    private bool isMovingLeft = true;
    // Start is called before the first frame update
    void Start()
    { 
        Ships.Add(ship1);
        Ships.Add(ship2);
        Ships.Add(ship3);
        Ships.Add(ship4);
        InvokeRepeating("WakeUpBitch",1.0f,1.0f);
         
    }   
    // Update is called once per frame
    void FixedUpdate()
    {
        Ships.RemoveAll(item => item == null);
        if (Ships.Count == 0)
        {
          isAlive = false;
          CancelInvoke();
          return;
        }
        if(isMovingLeft)
        {
          float minX = MinX();
          float stepX = minX - speed;
          if(stepX < -14)
          {
            isMovingLeft = false;
          }
          else
          {
            transform.position = new Vector3( 
            transform.position.x - speed,
            transform.position.y,
             0
            );
          }
        }
        else
        {
          float maxX = MaxX();
          float stepX = maxX + speed;
          if(stepX > 14)
          {
            isMovingLeft = true;
          }
          else
          {
             transform.position = new Vector3( 
             transform.position.x + speed,
             transform.position.y,
             0
            );
          }
        
        }
    }

    float MaxX()
    {
        int i = 0;
        float max = float.MinValue;
        while(i < Ships.Count)
        {
            if(Ships[i].transform.position.x > max)
            {
                max = Ships[i].transform.position.x;
            }
          i++;
        }
        
        return max;
    }
    float MinX()
    {
        int j = 0;
        float min = float.MaxValue;
        while(j < Ships.Count)
        {
            if(Ships[j].transform.position.x < min)
            {
                min = Ships[j].transform.position.x;
            }
          j++;
        }
        
        return min;

    }

    void WakeUpBitch()
    {
        int randomIndex = generator.Next(Ships.Count);
        Ships[randomIndex].Shoot();
      

        
    }

}

