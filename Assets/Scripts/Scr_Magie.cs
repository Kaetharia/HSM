using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Magie : MonoBehaviour
{

    public int xp;
    [Header("Room A")]
    public List<int> roomAPrices = new List<int>();
    public List<int> roomACooldown = new List<int>();
    public bool UpgradeToLv1 = false; 
    public bool UpgradeToLv2 = false;
    public bool UpgradeToLv3 = false;
    public bool UpgradeToLv4 = false;
    public int CurrentLvl = 0;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (xp >= roomAPrices[0] && CurrentLvl == 0)
        {
            
            UpgradeToLv1 = true;
        }
        else
        {
            UpgradeToLv1 = false;
        }

        if (xp >= roomAPrices[1] && CurrentLvl == 1)
        {
            UpgradeToLv2 = true;
        }
        else
        {
            UpgradeToLv2 = false;
        }

        if (xp >= roomAPrices[2] && CurrentLvl == 2)
        {
            UpgradeToLv3 = true;
        }
        else
        {
            UpgradeToLv3 = false;
        }

        if (xp >= roomAPrices[3] && CurrentLvl == 3)
        {
            UpgradeToLv4 = true;
        }
        else
        {
            UpgradeToLv4 = false;
        }
    }
    
    public void ClicOnRoomA()
    {
        //ouvrir interface en fonction de Current level.
        //fait appparaitre boutton pour ConfirmClicRoomA()
    }



    public void ConfirmClicOnRoomA()
    {
        if (UpgradeToLv1 == true && CurrentLvl == 0)
        {
            CurrentLvl = 1;
            xp = xp - roomAPrices[0];
            //Change toutes les stats


        }



    }

    
}
