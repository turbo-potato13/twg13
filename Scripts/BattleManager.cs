using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public Camera cam;
    public GameObject ourTank;
    public GameObject ourBro;
    public GameObject ourRacoon;
    public GameObject ourCrot;
    public GameObject enemy;
    private float spawnTime = 1f;
    

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float time;
    // Update is called once per frame
    void Update()
    {
        if(time < spawnTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            SpawnEnemy();
        }
        findNewtime();
    }

    private void findNewtime()
    {
        spawnTime = 3 - gameManager.score / gameManager.scoreToWin;
    }

    private bool CheckMax()
    {
        if (gameManager.Units < (int)gameManager.MaxUnits)
            return true;
        return false;
    }

    public void SpawnEnemy()
    {
        Vector3 pos = cam.ViewportToWorldPoint(new Vector3(0.95f, Random.Range(0.25f, 0.3f), 1));

        GameObject ene = Instantiate(enemy, pos, enemy.transform.rotation);
        ene.GetComponent<Unit>().health += (int)(gameManager.score / gameManager.scoreToWin * 100);
        ene.GetComponent<Weapon>().Damage += (int)(gameManager.score / gameManager.scoreToWin * 100);
    }

    public void SpawnBro()
    {
      if (BuildManager.fabricCount > 0)
        if (CheckMax())
            if (MoneyManager.Money > 250f)
            {
                Vector3 pos = cam.ViewportToWorldPoint(new Vector3(0.05f, Random.Range(0.25f, 0.3f), 1));

                Instantiate(ourBro, pos, ourBro.transform.rotation);
                MoneyManager.Money -= 250f;
            }
    }
    public void SpawnRacoon()
    {
        if (BuildManager.fabricCount > 1)
            if (CheckMax())
            if (MoneyManager.Money > 500f)
            {
                Vector3 pos = cam.ViewportToWorldPoint(new Vector3(0.05f, Random.Range(0.25f, 0.3f), 1));

                Instantiate(ourRacoon, pos, ourRacoon.transform.rotation);
                MoneyManager.Money -= 500f;
            }
    }
    public void SpawnCrot()
    {
        if (BuildManager.fabricCount > 2)
            if (CheckMax())
            if (MoneyManager.Money > 750f)
            {
                Vector3 pos = cam.ViewportToWorldPoint(new Vector3(0.05f, Random.Range(0.25f, 0.3f), 1));

                Instantiate(ourCrot, pos, ourCrot.transform.rotation);
                MoneyManager.Money -= 750f;
            }
    }

    public void SpawnTank()
    {
        if (BuildManager.fabricCount > 3)
            if (CheckMax())
            if (MoneyManager.Money > 2000f)
            {
                Vector3 pos = cam.ViewportToWorldPoint(new Vector3(0.05f, Random.Range(0.25f, 0.3f), 1));
             
                Instantiate(ourTank, pos, ourTank.transform.rotation);
                MoneyManager.Money -= 2000f;
            }
    }
}
