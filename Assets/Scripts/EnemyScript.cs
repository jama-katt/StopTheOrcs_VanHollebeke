using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public AudioSource sound;

    public float health;
    public int money;

    public ToolSelector toolSelector;

    public float x, y, z;
    Vector3 goal;
    public NavMeshAgent navmesh;

    float timer = 0.1f;
    bool moving = false;

    void Start()
    {
        goal = new Vector3(x, y, z);
    }

    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (!moving)
        {
            moving = true;
            navmesh.SetDestination(goal);
        }
        if (health <= 0)
        {
            sound.Play();
            toolSelector.currency += money;
            Destroy(gameObject);
        }
    }
}
