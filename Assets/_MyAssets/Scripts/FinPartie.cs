using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtPointage = default;
    [SerializeField] private TMP_Text _txtMeilleur = default;
    [SerializeField] private TMP_Text _txtTemps = default;

    public UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();


        _txtPointage.text = "pointage :" + PlayerPrefs.GetInt("pointage", 0);
       
       
        if (PlayerPrefs.HasKey("meilleur"))
        {
            if (PlayerPrefs.GetInt("pointage") > PlayerPrefs.GetInt("meilleur"))
            {
                PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
            }
        }
        else
        {
            PlayerPrefs.SetInt("meilleur", PlayerPrefs.GetInt("pointage"));
        }
        PlayerPrefs.Save();
        _txtMeilleur.text = "meilleiur pointage " + PlayerPrefs.GetInt("meilleur");
        _txtTemps.text = "temps :" + PlayerPrefs.GetFloat("temps");
    }
   
}
