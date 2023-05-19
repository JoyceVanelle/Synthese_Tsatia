using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip _sonExplosion = default;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 0.2f);
    }

    private void Update()
    {
        AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.05f);
        transform.Translate(Vector3.down * Time.deltaTime * 2f);
    }
}
