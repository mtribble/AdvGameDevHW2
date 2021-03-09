using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitControl : MonoBehaviour
{
    [SerializeField] string keyName = "";
    [SerializeField] string dest = "";



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entering exit area");
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            foreach(InventoryItem item in pc.inventory)
            {
                if(item.GetName() == keyName)
                {
                    SceneManager.LoadScene(dest);
                }
            }

        }
    }
}
