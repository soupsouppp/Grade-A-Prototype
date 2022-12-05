using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;

    public GameObject Choice1;
    public GameObject Choice2;

    public int choiceMade;

    public void Dialog1()
    {
        Text.text = "Student Name: Xena \nGrade: 11 \nSignning in to the female dorm at 7:47PM.";
        choiceMade = 1;
    }

    public void Dialog2()
    {
        Text.text = "See you next time.";
        choiceMade = 2;
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Text = TextBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text = TextBox.GetComponentInChildren<TextMeshProUGUI>();

        if (choiceMade >= 1)
        {
            Choice1.SetActive(false);
            Choice2.SetActive(false);
            
        }
    }
}
