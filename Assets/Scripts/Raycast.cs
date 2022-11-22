using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    //public bool inRange;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 8))
        {
            Inventory inventory = gameObject.GetComponentInParent<Inventory>();

            if (hit.transform.tag == "Item")
            {
                inventory.inRange = true;
                Debug.Log("Raycast in range");

            }
            else
            {
                inventory.inRange = false;
            }


            //if (hit.collider.gameObject.tag == "Item" && Input.GetKeyDown(KeyCode.E))
            //{

            //    inventory.itemPickedUp = hit.transform.gameObject;
            //    inventory.AddItem(inventory.itemPickedUp);
            //    Debug.Log("get item");
            //    //inventory.itemAdded = true;


      

            }
        }


    }


