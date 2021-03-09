using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIControl : MonoBehaviour
{
    bool isPaused;
    PlayerController pc;
    [SerializeField] Transform invPanel;
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        invPanel.gameObject.SetActive(true);

        tmp = invPanel.Find("Text").GetComponent<TextMeshProUGUI>();
        invPanel.gameObject.SetActive(false);
        if (tmp == null)
        {
            Debug.Log("Panic");
            Debug.Log(invPanel.Find("Text"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
            {
                invPanel.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                invPanel.gameObject.SetActive(true);
                string invText = "";
                int c = 1;
                foreach(InventoryItem item in pc.inventory){
                    invText += c.ToString() + "." + item.GetName();
                }
                tmp.text = invText;
            }
        }
    }
}
