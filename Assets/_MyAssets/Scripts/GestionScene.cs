using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    [SerializeField] private GameObject _instructions = default;
    //private bool _eninstructions = false;
    // Start is called before the first frame update
    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; // Récupère l'index de la scène en cours
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }
    public void instructionsActive()
    {
        _instructions.SetActive(true);
    }
    public void instructionsINActive()
    {
        _instructions.SetActive(false);
    }
}
