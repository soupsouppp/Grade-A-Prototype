using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    public Image healthBar;
    public GameObject player;

    float lerpSpeed;
    Color hpMax = new Color(0.302f, 1f, 0.651f);
    Color hpMin = new Color(0.902f, 0.122f, 1f);

    void Start()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;

        fillHP();
        colorChange();

        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        //healthbar
        if (playerStat.health > playerStat.maxHP)
        {
            playerStat.health = playerStat.maxHP;
        }
    }

    private void fillHP()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStat.health / playerStat.maxHP, lerpSpeed);

    }

    void colorChange()
    {
        PlayerStats playerStat = player.GetComponent<PlayerStats>();
        Color hpBarColor = Color.Lerp(hpMin, hpMax, (playerStat.health / playerStat.maxHP));
        healthBar.color = hpBarColor;
    }
}

