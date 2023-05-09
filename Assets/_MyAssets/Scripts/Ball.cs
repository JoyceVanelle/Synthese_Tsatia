using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _vitesse = 14f;
    [SerializeField] private GameObject _explosionPrefab = default;
    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesse);
        if (transform.position.x < -7f)
        {
            float randomX = Random.Range(-7.0f, 7.0f);
            transform.position = new Vector3(randomX, 7f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject); // elle detruit l'enemie
            Jouer player = collision.transform.GetComponent<Jouer>();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            player.Damage();

        }
    }
}

    // Update is called once per frame
  

