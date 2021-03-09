using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    PlayerMotor motor;
    public GameObject projectile;
    public List<InventoryItem> inventory = new List<InventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if(hit.transform.gameObject.tag == "Item")
                {
                    GameItem item = hit.transform.gameObject.GetComponent<GameItem>();
                    StartCoroutine(motor.PickUpItem(item));
                }
                else
                {
                    Shoot(hit.point);
                }
                
            }
            
        }
    }


    void Shoot(Vector3 target)
    {
        motor.Stop();
        transform.LookAt(target);
        Instantiate(projectile, (transform.position + Vector3.up * 0.5f) + (transform.forward * .75f),
            Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f));
    }

}
