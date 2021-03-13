using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public AudioSource hurtSound;

    public ToolSelector toolSelector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy1"))
        {
            toolSelector.score -= 10;
            Destroy(other.gameObject);
            hurtSound.Play();
        }
        else if (other.transform.CompareTag("Enemy2"))
        {
            toolSelector.score -= 50;
            Destroy(other.gameObject);
            hurtSound.Play();
        }
    }
}
