using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpotScript : MonoBehaviour
{
    public AudioSource arrowSound;
    public AudioSource cannonSound;
    public AudioSource placeSound;
    public AudioSource destroySound;

    public int MAX_LEVEL = 3;
    public int TOWER1_PRICE = 100;
    public int TOWER2_PRICE = 200;
    public int REPAIR_PRICE = 50;
    public int UPGRADE1_PRICE = 75;
    public int UPGRADE2_PRICE = 150;
    public int DESTROY_PRICE = 10;
    public float TOWER1_CD = 0.3f;
    public float TOWER2_CD = 1f;
    public float TOWER1_DIST = 3f;
    public float TOWER2_DIST = 6f;

    public GameObject arrow;
    public GameObject cannonball;

    public GameObject tower1Model;
    public GameObject tower2Model;
    public Transform towerSpot;
    public MeshRenderer towerBaseMesh;
    GameObject currentModel;

    public Material lvl1;
    public Material lvl2;
    public Material lvl3;
    public Material floor;

    public Transform enemyHolder;

    float counting = 0f;

    public ErrorTextScript errorText;
    public float health = 100;
    public ToolSelector toolSelector;
    int towerType = 0;
    int currentLevel = 0;

    bool cooldown = false;

   // bool targeting = false;

    Transform target;

    void Update()
    {
        if (!cooldown)
        {

            if (towerType == 1)
            {
                foreach(Transform child in enemyHolder)
                {
                    float dist = Vector3.Distance(child.position, transform.position);
                    Debug.Log(dist);
                    if (dist <= TOWER1_DIST)
                    {
                        target = child;
                    }
                }   
                if (target != null)
                {
                    Vector3 tempvector = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    Vector3 direction = (target.position - tempvector).normalized;
                    GameObject temp = Instantiate(arrow, tempvector, Quaternion.LookRotation(direction));
                    cooldown = true;
                    arrowSound.Play();
                }
            }
            else if (towerType == 2)
            {
                foreach (Transform child in enemyHolder)
                {
                    float dist = Vector3.Distance(child.position, transform.position);
                    Debug.Log(dist);
                    if (dist <= TOWER2_DIST)
                    {
                        target = child;
                    }
                }
                if (target != null)
                {
                    Vector3 tempvector = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    Vector3 direction = (target.position - tempvector).normalized;
                    GameObject temp = Instantiate(cannonball, tempvector, Quaternion.LookRotation(direction));
                    cooldown = true;
                    cannonSound.Play();
                }


            }
        }
        else
        {
            if (towerType == 1)
            {
                counting += Time.deltaTime;
                if (counting >= TOWER1_CD)
                {
                    counting = 0;
                    cooldown = false;
                }
            }
            else if (towerType == 2)
            {
                counting += Time.deltaTime;
                if (counting >= TOWER2_CD)
                {
                    counting = 0;
                    cooldown = false;
                }
            }
        }

    }
        public void onClick()
        {
            //Debug.Log("?");
            int tool = toolSelector.toolSelected;
            if (tool != 0)
            {
                switch (tool)
                {
                    case 1:
                        if (towerType == 0 && toolSelector.currency >= TOWER1_PRICE)
                        {
                            PlaceTower(tool);
                            toolSelector.currency -= TOWER1_PRICE;
                        }
                        break;
                    case 2:
                        if (towerType == 0 && toolSelector.currency >= TOWER2_PRICE)
                        {
                            PlaceTower(tool);
                            toolSelector.currency -= TOWER2_PRICE;
                        }
                        break;
                    case 3:
                        if (towerType != 0 && health < 100 && toolSelector.currency >= REPAIR_PRICE)
                        {
                            RepairTower();
                            toolSelector.currency -= REPAIR_PRICE;
                        }
                        break;
                    case 4:
                        if (towerType != 0)
                        {
                            UpgradeTower();
                        }
                        break;
                    case 5:
                        if (towerType != 0)
                        {
                            DestroyTower();
                            toolSelector.currency += DESTROY_PRICE;
                        }
                        break;
                }
            }
        }
        void PlaceTower(int type)
        {
            towerType = type;
            if (type == 1)
            {
                currentModel = Instantiate(tower1Model, towerSpot.position, Quaternion.identity, towerSpot);
            }
            else if (type == 2)
            {
                currentModel = Instantiate(tower2Model, towerSpot.position, Quaternion.identity, towerSpot);
            }
            currentLevel = 1;
            towerBaseMesh.material = lvl1;
            placeSound.Play();
        }

        void RepairTower()
        {

        }

        void UpgradeTower()
        {
            if (currentLevel < MAX_LEVEL)
            {
                if (towerType == 1)
                {
                    if (toolSelector.currency >= currentLevel * UPGRADE1_PRICE)
                    {
                        placeSound.Play();
                        toolSelector.currency -= currentLevel * UPGRADE1_PRICE;
                        currentLevel++;
                        if (currentLevel == 2)
                        {
                            towerBaseMesh.material = lvl2;
                            TOWER1_CD = 0.25f;
                            TOWER1_DIST = 3.5f;
                        }
                        else
                        {
                            towerBaseMesh.material = lvl3;
                            TOWER1_CD = 0.15f;
                            TOWER1_DIST = 4f;
                        }
                    }
                }
                else if (towerType == 2)
                {
                    if (toolSelector.currency >= currentLevel * UPGRADE2_PRICE)
                    {
                        placeSound.Play();
                        toolSelector.currency -= currentLevel * UPGRADE2_PRICE;
                        currentLevel++;
                        if (currentLevel == 2)
                        {
                            towerBaseMesh.material = lvl2;
                            TOWER2_CD = 0.85f;
                            TOWER2_DIST = 8f;
                        }
                        else
                        {
                            towerBaseMesh.material = lvl3;
                            TOWER2_CD = 0.7f;
                            TOWER2_DIST = 10f;
                        }
                    }
                }
            }
        }

        void DestroyTower()
        {
            destroySound.Play();
            towerBaseMesh.material = floor;
            Destroy(currentModel);
            towerType = 0;
            currentLevel = 0;
            health = 100;
        }
}
