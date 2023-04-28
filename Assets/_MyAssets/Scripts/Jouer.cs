using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouer : MonoBehaviour
{

    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _cadenceTir = 0.5f;
    [SerializeField] private float _cadenceCut = 0.5f;
    [SerializeField] private GameObject _laserPrefab = default;
    [SerializeField]private GameObject _KnivePrefab= default;
    [SerializeField] private GameObject _explosionPrefab = default;
  

    private float _canFire = -1f;
    private float _canCut  = -1f;
    private float _cadenceInitiale;
    private float _canCutInitiale;

    // Start is called before the first frame update

    private void Start()
    {
        transform.position = new Vector3(0f , -2.89f , 0f);
        _cadenceInitiale = _cadenceTir;
        _canCutInitiale = _cadenceCut;
    }
    // Update is called once per frame
    void Update()
    {
        MouvementsJoueur();
        Tir();
        Cut();
    }

    private void MouvementsJoueur()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertiInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizInput, vertiInput, 0f);
        transform.Translate(direction * Time.deltaTime * _vitesse);
        // ajuster la position en y (vertical) en utilisant le math.clamp
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.0f, 4.0f), Mathf.Clamp(transform.position.y, -4f, 3.5f), 0f);
       
    }


    private void Tir()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _cadenceTir;
            Instantiate(_laserPrefab, transform.position + new Vector3(0f, 1.1f, 0f), Quaternion.identity);

        }
    }


    private void Cut()
    {
        if (Input.GetKey(KeyCode.V) && Time.time > _canCut)
        {
            _canCut = Time.time + _cadenceCut;
            Instantiate(_KnivePrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);

        }
    }



    IEnumerator SpeedCoroutine()
    {
        yield return new WaitForSeconds(5);
        _cadenceTir = _cadenceInitiale;
    }

    IEnumerator CutCorouting()
    {
        yield return new WaitForSeconds(5);
        _cadenceCut = _canCutInitiale;
    }
 }




