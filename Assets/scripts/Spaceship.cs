using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    private AudioSource karoche;
    private static int MAX_HEALTH = 1000; 
    private float speed = 0.1f;
    private int hitCount = 0;
    private int health = MAX_HEALTH;
    public GameObject bulletOriginal;
    public GameObject hp1;
    public GameObject hp2;
    public AudioClip shoot; 
    private List <GameObject> hpList = new List<GameObject>();

    void Start()
    {
        hpList.Add(hp1);
        hpList.Add(hp2);
        karoche = GetComponent<AudioSource>();
    }
    



    
    void Update()
    {
        bool keyUp = Input.GetKeyUp(KeyCode.Space);
        if (keyUp)
        {
            GameObject bulletclone;
            bulletclone = Instantiate(bulletOriginal);
            bulletclone.transform.position = transform.position;
            karoche.PlayOneShot(shoot);
        }
    }

    void FixedUpdate()
    {
        bool keyUp = Input.GetKey(KeyCode.Q);
        if (keyUp) 
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x -= speed;
            transform.position = objectPosition;
        }
        bool keyDown = Input.GetKey(KeyCode.E);
        if (keyDown) 
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x += speed;
            transform.position = objectPosition;
        
        }   
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
       EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
       if (bulletScript != null)
       {
            health -= bulletScript.damage;
           OnHit();
            Destroy(otherObject);
            print(health);
            if (health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneID.losesceneID);
                Destroy(gameObject);
            }
       }
       HealthBonus bonusScript = otherObject.GetComponent<HealthBonus>();
       if(bonusScript != null)
       {
            Destroy(otherObject);
            RestoreHealth();
       }
    }

    void RestoreHealth()
    {
        print("collecting health");
        health = MAX_HEALTH;
        hitCount = 0;
        foreach(GameObject currentItem in hpList)
        {
            currentItem.SetActive(true);
        }
    }

    void OnHit()
    {
        hpList[hitCount].SetActive(false);
        hitCount += 1;
    }
}

