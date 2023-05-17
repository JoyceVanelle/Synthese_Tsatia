using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float _vitesse = 6f;
    
    [SerializeField] private GameObject _explosionPrefab = default;
    // Start is called before the first frame update
   

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
       
         if (collision.tag == "Player")
        {
            Destroy(gameObject); // elle detruit lE stone
            Jouer player = collision.transform.GetComponent<Jouer>();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            player.Damage(); // elle detruit le joue

        }
    }
}
