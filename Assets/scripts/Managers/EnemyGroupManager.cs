using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    public GameObject firstGroupOriginal;
     public EnemyGroup CreateEnemyGroup() 
     {
       GameObject newGroupObject = Instantiate(firstGroupOriginal);
       EnemyGroup groupObject = newGroupObject.GetComponent<EnemyGroup>();
       return groupObject;
     }
}
