using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _vitesse = 14f;
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * _vitesse);
        if (transform.position.y > 9f)
        {
            if (this.transform.parent == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this.transform.parent.gameObject);
            }

        }

    }
}
