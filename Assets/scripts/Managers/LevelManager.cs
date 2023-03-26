using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioSource musicSource;
    private int maxGroupCount = 4;
    private int destroyedGroupCounts = 0;
    private EnemyGroupManager groupmanager;
    private EnemyGroup currentGroup;
    public void Start()
    {
        destroyedGroupCounts = 0;
        groupmanager  = GetComponent<EnemyGroupManager>();
        currentGroup = groupmanager.CreateEnemyGroup();
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

     public void Update()
    {
        if (currentGroup.isAlive == false)
        {
            Destroy(currentGroup);
            destroyedGroupCounts += 1;
            if(destroyedGroupCounts == maxGroupCount)
            {
                SceneManager.LoadSceneAsync(SceneID.winsceneID);
            }
            else
            {
                currentGroup = groupmanager.CreateEnemyGroup();
            }
            
        }
    }
}
