using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Student : MonoBehaviour
{
    [Header("Boutons classiques")]
    public Button A_btn;
    public Button B_btn;
    public Button C_btn;
    public Button D_btn;
    [Header("Boutons de confirmation")]
    public GameObject A_btn_confirm;
    public GameObject B_btn_confirm;
    public GameObject C_btn_confirm;
    public GameObject D_btn_confirm;
    [Header("Elèves instanciés")]
    public GameObject fireStudent;
    public GameObject poisonStudent;
    public GameObject explosionStudent;
    public GameObject invocationStudent;
    [Header("Canvas")]
    public GameObject Canvas;
    public Vector3 pos;
    [Header("Prix des Achats")]
    public float prixMagieALv1;
    public float prixMagieBLv1;
    public float prixMagieCLv1;
    public float prixMagieDLv1;
    [Header("Affichage dans le boutton")]
    public Text TexteMagieA;
    public Text TexteMagieB;
    public Text TexteMagieC;
    public Text TexteMagieD;
    [Header("Boutons en marche")]
    private bool btnA_active;
    private bool btnB_active;
    private bool btnC_active;
    private bool btnD_active;




    private void Awake()
    {
        TexteMagieA.text = prixMagieALv1.ToString();
        TexteMagieB.text = prixMagieBLv1.ToString();
        TexteMagieC.text = prixMagieCLv1.ToString();
        TexteMagieD.text = prixMagieDLv1.ToString();
        pos = this.transform.position;

    }

    void Start()
    {


    }

    private void OnMouseUp()
    {
        SwitchCanvasApparition();


    }


    private void Update()
    {
        if (Canvas.activeSelf == true)
        {
            //Bouton A
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieALv1 && A_btn.interactable == false) // Si j'ai assez d'argent et que le bouton est désactivé
            {
                A_btn.interactable = true; // le bouton deviens actif
            }
            else if (Scr_XP.Scr_XPStatic.xp < prixMagieALv1 && A_btn.interactable == true) // Sinon, si le bouton est actif mais que je n'ai pas assez d'argent il redeviens inutilisable
            {
                A_btn.interactable = false; // le bouton se désactive
            }
            //Bouton B
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieBLv1 && B_btn.interactable == false) // Si j'ai assez d'argent et que le bouton est désactivé
            {
                B_btn.interactable = true; // le bouton deviens actif
            }
            else if (Scr_XP.Scr_XPStatic.xp < prixMagieBLv1 && B_btn.interactable == true) // Sinon, si le bouton est actif mais que je n'ai pas assez d'argent il redeviens inutilisable
            {
                B_btn.interactable = false; // le bouton se désactive
            }
            //Bouton C
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieCLv1 && C_btn.interactable == false) // Si j'ai assez d'argent et que le bouton est désactivé
            {
                C_btn.interactable = true; // le bouton deviens actif
            }
            else if (Scr_XP.Scr_XPStatic.xp < prixMagieCLv1 && C_btn.interactable == true) // Sinon, si le bouton est actif mais que je n'ai pas assez d'argent il redeviens inutilisable
            {
                C_btn.interactable = false; // le bouton se désactive
            }
            //Bouton D
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieDLv1 && D_btn.interactable == false) // Si j'ai assez d'argent et que le bouton est désactivé
            {
                D_btn.interactable = true; // le bouton deviens actif
            }
            else if (Scr_XP.Scr_XPStatic.xp < prixMagieDLv1 && D_btn.interactable == true) // Sinon, si le bouton est actif mais que je n'ai pas assez d'argent il redeviens inutilisable
            {
                D_btn.interactable = false; // le bouton se désactive
            }


        }
    }

    private void SwitchCanvasApparition()
    {
        if (Input.GetMouseButtonUp(0) && Canvas.activeSelf == true)
        {
            Debug.Log("Clic");
            Canvas.SetActive(false);//Désaffiche le canvas



        }
        else if (Input.GetMouseButtonUp(0) && Canvas.activeSelf == false)
        {
            Debug.Log("active");
            Canvas.SetActive(true); //Affiche le canvas d'amélioration
            Canvas.transform.position = pos;
            Canvas.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        }

    }

    public void MagieA()
    {


        if (A_btn_confirm.activeSelf == true) // si le bouton valider est activé
        {
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieALv1)
            {
                Scr_XP.Scr_XPStatic.xp = Scr_XP.Scr_XPStatic.xp - prixMagieALv1;
                Instantiate(fireStudent, pos, Quaternion.identity);
                SwitchCanvasApparition();
                A_btn_confirm.SetActive(false);
                
            }
        }
        else // si le bouton valider est désactivé
        {
            A_btn_confirm.SetActive(true); // on l'active
        }
    }
    public void MagieB()
    {
        if (B_btn_confirm.activeSelf == true) // si le bouton valider est activé
        {
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieBLv1)
            {
                Scr_XP.Scr_XPStatic.xp = Scr_XP.Scr_XPStatic.xp - prixMagieBLv1;
                Instantiate(fireStudent, pos, Quaternion.identity);
                SwitchCanvasApparition();
                B_btn_confirm.SetActive(false);

            }
        }
        else // si le bouton valider est désactivé
        {
            B_btn_confirm.SetActive(true); // on l'active
        }
    }
    public void MagieC()
    {
        if (C_btn_confirm.activeSelf == true) // si le bouton valider est activé
        {
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieCLv1)
            {
                Scr_XP.Scr_XPStatic.xp = Scr_XP.Scr_XPStatic.xp - prixMagieCLv1;
                Instantiate(fireStudent, pos, Quaternion.identity);
                SwitchCanvasApparition();
                C_btn_confirm.SetActive(false);

            }
        }
        else // si le bouton valider est désactivé
        {
            C_btn_confirm.SetActive(true); // on l'active
        }
    }
    public void MagieD() 
    {
        if (D_btn_confirm.activeSelf == true) // si le bouton valider est activé
        {
            if (Scr_XP.Scr_XPStatic.xp >= prixMagieDLv1)
            {
                Scr_XP.Scr_XPStatic.xp = Scr_XP.Scr_XPStatic.xp - prixMagieDLv1;
                Instantiate(fireStudent, pos, Quaternion.identity);
                SwitchCanvasApparition();
                D_btn_confirm.SetActive(false);

            }
        }
        else // si le bouton valider est désactivé
        {
            D_btn_confirm.SetActive(true); // on l'active
        }
    }


    public void ClicOnLockedBtn()
    {
        Debug.Log("Locked");
    }


}




