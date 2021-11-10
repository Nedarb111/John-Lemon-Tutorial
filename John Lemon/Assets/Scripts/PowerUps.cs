using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameEnding item;
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Detected Player");
            item.keys += 1;
            Debug.Log(item.keys);
        }
    }
}
