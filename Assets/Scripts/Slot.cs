using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject Tooltip;
    public TextMeshProUGUI tooltipText;
    public RectTransform tpBG;

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

        if (item)
        {
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }


    public void ShowTooltip(string tooltipString)
    {

    }



    //USE INVENTORY
    public void OnPointerClick(PointerEventData eventData)
    {
        //click on slot 
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            //check item type

            //LIQUIDS
            if(thisItem.type == "water")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Drink(thisItem.waterUpvalue);
                
                Destroy(item);
            }

            //FOOD
            if (thisItem.type == "food")
            {
                PlayerStats playerStats = player.GetComponent<PlayerStats>();
                playerStats.Drink(thisItem.foodUpvalue);

                Destroy(item);
            }

            //WEAPONS
            if (thisItem.type == "pistol")
            {
                Shooting shooting = player.GetComponent<Shooting>();
                shooting.pistolEquipped = true;

                Destroy(item);
            }

            if (thisItem.type == "rifle")
            {
                Shooting shooting = player.GetComponent<Shooting>();
                shooting.rifleEquipped = true;
                Destroy(item);
            }
        }
    }
}
