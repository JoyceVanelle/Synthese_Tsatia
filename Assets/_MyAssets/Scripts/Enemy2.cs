using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float _vitesse = 5.0f;
    [SerializeField] private int _points = 100;
    [SerializeField] private GameObject _explosionPrefab = default;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        if (transform.position.x < -7f)
        {
            float randomX = Random.Range(-7.0f, 7.0f);
            transform.position = new Vector3(randomX, 7f, 0f);
        }
    }

    //private void MouvementsJoueur()
    //{
    //    float horizInput = Input.GetAxis("Horizontal");
    //    float vertiInput = Input.GetAxis("Vertical");
    //    Vector3 direction = new Vector3(horizInput, vertiInput, 0f);
    //    transform.Translate(direction * Time.deltaTime * _vitesse);
    //    // ajuster la position en y (vertical) en utilisant le math.clamp
    //    transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 3.5f), 0f);
    //    //  ajuster la position en x
    //    if (transform.position.x < -9.5f)
    //    {
    //        transform.position = new Vector3(9.5f, transform.position.y, 0f);
    //    }
    //    else if (transform.position.x > 9.5f)
    //    {
    //        transform.position = new Vector3(-9.5f, transform.position.y, 0f);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Knive")
        {
            Debug.Log("hello");
            Destroy(collision.gameObject); // elle detruit le couteau
            _uiManager.AjouterScore(_points);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // elle detruit l'enemie

        }
       
        else if (collision.tag == "Player" )
        {
            Destroy(gameObject); // elle detruit l'enemie
            Jouer player = collision.transform.GetComponent<Jouer>();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            player.Damage(); // elle detruit le joue 

        }
       
    }
}
