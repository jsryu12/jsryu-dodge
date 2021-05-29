using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    public Text lifeText;

    public GameObject level;
    public GameObject bulletSpawnerPrefab;
    private Vector3[] bulletSpawnerPos = new Vector3[4];
    int spawnCounter = 0;

    private float surviveTime;
    private bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;

        bulletSpawnerPos[0].x = -8f;
        bulletSpawnerPos[0].y = 1f;
        bulletSpawnerPos[0].z = 8f;

        bulletSpawnerPos[1].x = 8f;
        bulletSpawnerPos[1].y = 1f;
        bulletSpawnerPos[1].z = 8f;

        bulletSpawnerPos[2].x = 8f;
        bulletSpawnerPos[2].y = 1f;
        bulletSpawnerPos[2].z = -8f;

        bulletSpawnerPos[3].x = -8f;
        bulletSpawnerPos[3].y = 1f;
        bulletSpawnerPos[3].z = -8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;

            //if (surviveTime < 5f && spawnCounter == 0)
            //{

            //}

            if (surviveTime < 5f && spawnCounter == 0)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawnerPos[spawnCounter], Quaternion.identity);
                bulletspawner.transform.parent = level.transform;
                bulletspawner.transform.localPosition = bulletSpawnerPos[spawnCounter];
                level.GetComponent<Rotator>().rotationspeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime < 10f && spawnCounter == 1)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawnerPos[spawnCounter], Quaternion.identity);
                bulletspawner.transform.parent = level.transform;
                bulletspawner.transform.localPosition = bulletSpawnerPos[spawnCounter];
                level.GetComponent<Rotator>().rotationspeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawnerPos[spawnCounter], Quaternion.identity);
                bulletspawner.transform.parent = level.transform;
                bulletspawner.transform.localPosition = bulletSpawnerPos[spawnCounter];
                level.GetComponent<Rotator>().rotationspeed += 15f;
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawnerPos[spawnCounter], Quaternion.identity);
                bulletspawner.transform.parent = level.transform;
                bulletspawner.transform.localPosition = bulletSpawnerPos[spawnCounter];
                level.GetComponent<Rotator>().rotationspeed += 15f;
                spawnCounter++;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                
            }
        }
    }
    public void DisplayLife(int nLife)
    {
        lifeText.text = "";
        for (int n=0; n<nLife; n++)
            lifeText.text += "♥";
    }
    
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time :" + (int)bestTime;
    }
}
