using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool empty;
    private bool hovered;

    public GameObject item;
    public Sprite itemIcon;

    private GameObject player;

    
    void Start()
    {
        //empty = true;

        player = GameObject.FindWithTag("Player");
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        hovered = false;

    }


    void Update()
    {
        if (item)
        {
            empty = false;
            itemIcon = item.GetComponent<Item>().icon;
            this.GetComponent<Image>().sprite = itemIcon;
            Debug.Log("updating inventory");
        }
        else
        {
            empty = true;
            
            itemIcon = null;
            this.GetComponent<Image>().sprite = null;
            

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    //USE INVENTORY
    public void OnPointerClick(PointerEventData eventData)
    {
        //click on slot 
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            //check item type

            //pure water
            if(thisItem.type == "water")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Drink(thisItem.waterUpvalue);
                
                Destroy(item);
            }
        }
    }
}
