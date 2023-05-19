using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtPointage = default;
    [SerializeField] private TMP_Text _txtMeilleur = default;
    // Start is called before the first frame update
    void Start()
    {
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
    }
   
}
