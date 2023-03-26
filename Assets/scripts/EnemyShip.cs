using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{ 
    public AudioClip boom;
    public GameObject healthBonusOriginal;
    public int health = 7000;
    public GameObject bulletOriginal;
    public Animator spriteAnimator;
    private AudioSource soundSource;
    private System.Random randomGenerator = new System.Random();
    void Start() 
    {
        soundSource = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bulletOriginal);
        newBullet.transform.position = transform.position;
    }
    public void DestroyEnemyShip()
    {
        soundSource.PlayOneShot(boom);
        transform.parent = null;
        spriteAnimator.SetBool("IsDead", true);
    }
    public void OnDestroyAnimationEnd()
    {
       double hpPercent = randomGenerator.NextDouble();
       if(hpPercent > 0.5)
       {
            GameObject newHPBonus = Instantiate(healthBonusOriginal);
            newHPBonus.transform.position = transform.position;
       }
        
        Destroy(gameObject);
    }
    

    
}
