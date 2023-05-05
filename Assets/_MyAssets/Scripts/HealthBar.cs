using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //static Image Barre;
    //public float max { get; set; }
    //public float Valeur;
    private float m_value;
    private object views;
    private bool animateBar;

    //public float valeur
    //{
    //    get { return Valeur; }
    //    set
    //    {
    //        Valeur = Mathf.Clamp(value , 0 ,max);
    //        Barre.fillAmount= (1/max) * Valeur;
    //    }
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Barre= GetComponent<Image>();
    //}

    // Update is called once per frame


    public void SetValue(float percentage, bool skipAnimation = false)
    {
        if (Mathf.Approximately(m_value, percentage))
            return;



        m_value = Mathf.Clamp01(percentage);



        //for (int i = 0; i < views.Length; i++)
        //    views[i].NewChangeStarted(displayValue, m_value);



        if (animateBar && !skipAnimation && Application.isPlaying && gameObject.activeInHierarchy)
            StartSizeAnim(percentage);
        else
            SetDisplayValue(percentage);
    }

    private void SetDisplayValue(float percentage)
    {
        throw new NotImplementedException();
    }

    private void StartSizeAnim(float percentage)
    {
        throw new NotImplementedException();
    }

}
