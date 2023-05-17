using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knive : MonoBehaviour
{
    [SerializeField] private float _vitesse = 14f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * _vitesse);
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
