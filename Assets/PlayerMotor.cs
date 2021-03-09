using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    float pickupDist = 1.5f;
    bool isPickingUp = false;
    List<InventoryItem> inventory;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        inventory = GetComponent<PlayerController>().inventory;
    }

    public void MoveToPoint(Vector3 point)
    {
        isPickingUp = false;
        agent.SetDestination(point);
    }
    public void Stop()
    {
        MoveToPoint(transform.position);
    }
    public bool isStopped()
    {
        return agent.velocity == Vector3.zero;
    }

    public IEnumerator PickUpItem(GameItem item)
    {
        Debug.Log("Picking up item");
        agent.SetDestination(item.gameObject.transform.position);
        isPickingUp = true;
        while (Vector3.Distance(item.transform.position, transform.position) > pickupDist && isPickingUp)
        {
            yield return new WaitForSeconds(0.01f);
        }
        if (isPickingUp)
        {
            InventoryItem newItem = new InventoryItem(item.GetName());
            inventory.Insert(0, newItem);
            Destroy(item.gameObject);
        }
    }

}
