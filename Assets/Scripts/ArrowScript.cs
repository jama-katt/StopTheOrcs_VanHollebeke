using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 10f;
    float killme = 0f;
    void Update()
    {
        killme += Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * speed;
        if (killme > 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy1"))
        {
            EnemyScript temp = other.gameObject.GetComponent<EnemyScript>();
            temp.health -= 1;
            Destroy(gameObject);
        }
        else if (other.transform.CompareTag("Enemy2"))
        {
            EnemyScript temp = other.gameObject.GetComponent<EnemyScript>();
            temp.health -= 1;
            Destroy(gameObject);
        }
    }
}
