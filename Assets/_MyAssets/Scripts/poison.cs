using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;
    Player _playerPrefab;
    void Start()
    {
        _playerPrefab = FindObjectOfType<Player>();
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(Random.Range(-9f, 9f), -8f, 0f), _speed * Time.deltaTime);
        if (transform.position.y <= -7.0f)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Player player = collision.transform.GetComponent<Player>();
            Jouer _player = FindObjectOfType<Jouer>();
            _player.poison();
            Destroy(gameObject);
        }
    }
}
