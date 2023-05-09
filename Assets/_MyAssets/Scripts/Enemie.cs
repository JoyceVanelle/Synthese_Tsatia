using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    [SerializeField] private float _vitesse = 6f;
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
        transform.Translate(Vector3.down * Time.deltaTime * _vitesse);
        if (transform.position.y < -7f)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(randomX, 7f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject); // elle detruit le lasar
            _uiManager.AjouterScore(_points);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // elle detruit l'enemie

        }
        else if (collision.tag == "Player")
        {
            Destroy(gameObject); // elle detruit l'enemie
            Jouer player = collision.transform.GetComponent<Jouer>();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            player.Damage(); // elle detruit le joue

        }
    }
}
