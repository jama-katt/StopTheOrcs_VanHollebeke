using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("TowerHitBox"))
                {
                    TowerSpotScript temp = hit.transform.parent.GetComponent<TowerSpotScript>();
                    temp.onClick();
                }
            }

        }
    }
}
