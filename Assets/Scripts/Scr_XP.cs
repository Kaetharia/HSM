using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_XP : MonoBehaviour
{
    public static Scr_XP Scr_XPStatic;
    public float xp = 0;


   void Start()
   {
        Scr_XPStatic = this;
   }
}
