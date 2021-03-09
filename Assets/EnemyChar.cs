using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChar : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] GameObject itemToDrop = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            if(itemToDrop != null)
            {
                Instantiate(itemToDrop, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }

}
