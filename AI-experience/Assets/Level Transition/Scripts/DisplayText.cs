using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class DisplayText : MonoBehaviour {

    public Text frame1;
    public Text frame2;
    public Text frame3;
    public Text frame4;
    public Text frame5;
    public Text frame6;

    void Start()
    {
        string nextLvl;

        if (GlobalVariables.nextLevel== null)
        {
            nextLvl = "Level 08";
        }
        else
        {
            nextLvl = GlobalVariables.nextLevel.ToString();
        }

        frame1.text = TextTransitionLvl8.text1;
        frame2.text = TextTransitionLvl8.text2;
        frame3.text = TextTransitionLvl8.text3;
        frame4.text = TextTransitionLvl8.text4;
        frame5.text = TextTransitionLvl8.text5;
        frame6.text = TextTransitionLvl8.text6;      

    }




}
