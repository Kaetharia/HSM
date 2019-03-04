using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Clicker : MonoBehaviour
{
    public float multiplicateur_click = 1;
    public float multiplicateur_base = 1;
    public float multiplicateurA = 1;
    public float multiplicateurB = 1;
    public float multiplicateurC = 1;
    public float multiplicateurD = 1;

    public Text xp_text; 
    private float precision = 100;
    private float fps2;
    public float fps;
    private float xpPerSecondsTotal;
    public Text xpPerSeconds_text;
    public Text fpsText;
    public float deltaTime;
    public Text xpPerSecondsRA;
    public Text xpPerSecondsRB;
    public Text xpPerSecondsRC;
    public Text xpPerSecondsRD;
    public float xpRA;
    public float xpRB;
    public float xpRC;
    public float xpRD;
    public Image progressBarRA;
    public Image progressBarRB;
    public Image progressBarRC;
    public Image progressBarRD;
    public ParticleSystem plusXeffect;
    public Text plusXtext;
    

    private void Awake()
    {
        progressBarRA.fillAmount = xpRA * 10;
        xpPerSecondsRA.text = (multiplicateur_base * multiplicateurA / 10).ToString("0"+".##"+" xp/s");
        xpPerSecondsRB.text = (multiplicateur_base * multiplicateurB / 10).ToString("0"+".##"+" xp/s");
        xpPerSecondsRC.text = (multiplicateur_base * multiplicateurC / 10).ToString("0"+".##"+" xp/s");
        xpPerSecondsRD.text = (multiplicateur_base * multiplicateurD / 10).ToString("0"+".##"+" xp/s");
        xpPerSecondsTotal = (multiplicateur_base * multiplicateurA / 10) + (multiplicateur_base * multiplicateurB / 10) + (multiplicateur_base * multiplicateurC / 10) + (multiplicateur_base * multiplicateurD / 10);
        xpPerSeconds_text.text = xpPerSecondsTotal.ToString("0" + ".##" +  " Global XP/s");
    }

    void Start()
    {
        StartCoroutine("FarmingRA");
        StartCoroutine("FarmingRB");
        StartCoroutine("FarmingRC");
        StartCoroutine("FarmingRD");
    }

    void Update()
    {
        


        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();



        


    }
    IEnumerator FarmingRA()
    {
        if (xpRA >= 0.1f)
        {
            xpRA = 0;
            Debug.Log("restart roomA");
        }
        yield return new WaitForSeconds(0.01f); //se fait toutes les 0.01 secondes
        progressBarRA.fillAmount = xpRA * 10 / 1;
        xpRA = (5/3000f * multiplicateur_base * multiplicateurA) + xpRA; //le total général d'1 xp par seconde est incrémenté.
        Scr_XP.Scr_XPStatic.xp = (5/3000f * multiplicateur_base * multiplicateurA) + Scr_XP.Scr_XPStatic.xp;
        xp_text.text = Scr_XP.Scr_XPStatic.xp.ToString(".#"+"0"); //le texte général est modifié
        
        StartCoroutine("FarmingRA"); //recommence 
    }

    IEnumerator FarmingRB()
    {
        if (xpRB >= 0.1f) //Restart de la barre quand elle est remplie à 100%
        {
            xpRB = 0;
            Debug.Log("restart roomB");
        }
        yield return new WaitForSeconds(0.01f); //se fait toutes les 0.01 secondes
        progressBarRB.fillAmount = xpRB * 10 / 1;
        xpRB = (5 / 3000f * multiplicateur_base * multiplicateurB) + xpRB; //le total général d'1 xp par seconde est incrémenté.
        Scr_XP.Scr_XPStatic.xp = (5 / 3000f * multiplicateur_base * multiplicateurB) + Scr_XP.Scr_XPStatic.xp;
        xp_text.text = Scr_XP.Scr_XPStatic.xp.ToString(".#" + "0"); //le texte général est modifié
        StartCoroutine("FarmingRB"); //recommence 
    }
    IEnumerator FarmingRC()
    {
        if (xpRC >= 0.1f)
        {
            xpRC = 0;
            Debug.Log("restart roomC");
        }
        yield return new WaitForSeconds(0.01f); //se fait toutes les 0.01 secondes
        progressBarRC.fillAmount = xpRC * 10 / 1;
        xpRC = (5 / 3000f * multiplicateur_base * multiplicateurC) + xpRC; //le total général d'1 xp par seconde est incrémenté.
        Scr_XP.Scr_XPStatic.xp = (5 / 3000f * multiplicateur_base * multiplicateurC) + Scr_XP.Scr_XPStatic.xp;
        xp_text.text = Scr_XP.Scr_XPStatic.xp.ToString(".#" + "0"); //le texte général est modifié
        StartCoroutine("FarmingRC"); //recommence 
    }
    IEnumerator FarmingRD()
    {
        if (xpRD >= 0.1f)
        {
            xpRD = 0;
            Debug.Log("restart roomD");
        }
        yield return new WaitForSeconds(0.01f); //se fait toutes les 0.01 secondes
        progressBarRD.fillAmount = xpRD * 10 / 1;
        xpRD = (5 / 3000f * multiplicateur_base* multiplicateurD) + xpRD; //le total général d'1 xp par seconde est incrémenté.
        Scr_XP.Scr_XPStatic.xp = (5 / 3000f * multiplicateur_base * multiplicateurD) + Scr_XP.Scr_XPStatic.xp;
        xp_text.text = Scr_XP.Scr_XPStatic.xp.ToString(".#" + "0"); //le texte général est modifié
        StartCoroutine("FarmingRD"); //recommence 
    }
    public void OnMouseDown()
    {
        xpPerSecondsRA.text = (multiplicateur_base * multiplicateurA / 10).ToString("0" + ".##" + " xp/s");
        xpPerSecondsRB.text = (multiplicateur_base * multiplicateurB / 10).ToString("0" + ".##" + " xp/s");
        xpPerSecondsRC.text = (multiplicateur_base * multiplicateurC / 10).ToString("0" + ".##" + " xp/s");
        xpPerSecondsRD.text = (multiplicateur_base * multiplicateurD / 10).ToString("0" + ".##" + " xp/s");
        xpPerSecondsTotal = (multiplicateur_base * multiplicateurA / 10) + (multiplicateur_base * multiplicateurB / 10) + (multiplicateur_base * multiplicateurC / 10) + (multiplicateur_base * multiplicateurD / 10);
        xpPerSeconds_text.text = xpPerSecondsTotal.ToString("0" + ".##" +" Global XP/s");
    }
    public void ClickXP()
    {
        Debug.Log("clic xp");
        plusXtext.text = (multiplicateur_click/10).ToString("+0"+".#" + "0");
        Scr_XP.Scr_XPStatic.xp = (0.10f * multiplicateur_click) + Scr_XP.Scr_XPStatic.xp;
        ParticleSystem clone = (ParticleSystem) Instantiate(plusXeffect, plusXeffect.transform.position, plusXeffect.transform.rotation);
        Destroy(clone.gameObject, 1);


        Scr_XP.Scr_XPStatic.xp = Mathf.Floor(Scr_XP.Scr_XPStatic.xp * precision + 0.5f) / precision;
        //xp_text.text = Scr_XP.Scr_XPStatic.xp.ToString(".##");
        Debug.Log(Scr_XP.Scr_XPStatic.xp);

        
        

    }

    public void RoomA()
    {
        Debug.Log("Click RoomA");
    }
    public void RoomB()
    {
        Debug.Log("Click RoomB");
    }
    public void RoomC()
    {
        Debug.Log("Click RoomC");
    }
    public void RoomD()
    {
        Debug.Log("Click RoomD");
    }
    
}
