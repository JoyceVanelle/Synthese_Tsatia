using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouer : MonoBehaviour
{

    [SerializeField] private float _vitesse = 10.0f;
    [SerializeField] private float _cadenceTir = 0.5f;
    [SerializeField] private float _cadenceCut = 0.5f;
    [SerializeField] private GameObject _laserPrefab = default;
    [SerializeField] private GameObject _KnivePrefab = default;
   [SerializeField] private GameObject _explosionPrefab = default;
    
    [SerializeField] ProgressBarPro _lifebar;
    private SpawnManager _spawnManager;
    private GestionScene _gestionScene;

    //HealthBar BarreDevie = new HealthBar();


    private float _canFire = -1f;
    private float _canCut = -1f;
    private float _cadenceInitiale;
    private float _canCutInitiale;
    private float _life;
  
    private Animator _anim;

    // Start is called before the first frame update

    private void Start()
    {
        _life = 1f;
        transform.position = new Vector3(-7f, -4f, 0f);
        _cadenceInitiale = _cadenceTir;
        _canCutInitiale = _cadenceCut;
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _gestionScene = GameObject.Find("GestionScene").GetComponent<GestionScene>();
        _anim = GetComponent<Animator>();

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



        // Gestion des Animations

        if (horizInput < 0f)
        {
            _anim.SetBool("JumpAttack", true);
            _anim.SetBool("Knightwalk", false);
        }
        else if (horizInput > 0f)
        {
            _anim.SetBool("JumpAttack", false);
            _anim.SetBool("Knightwalk", true);
        }
        else
        {
            _anim.SetBool("JumpAttack", false);
            _anim.SetBool("Knightwalk", false);
        }

        // ajuster la position en y (vertical) en utilisant le math.clamp
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.0f, 10.0f), Mathf.Clamp(transform.position.y, -3f, 5f), 0f);

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
            Instantiate(_KnivePrefab, transform.position + new Vector3(0f, 0.2f, 0f), Quaternion.identity);

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy1" || collision.tag == "Enemy2") /*|| collision.tag == "Enemy2" || collision.tag == "Ball")*/
        {
            Debug.Log("hello");
            Destroy(collision.gameObject); // elle detruit lenemie
                                           
            Damage();
        }

    }


    public void Damage()
    {
        _life = _life - 0.1f;
        Debug.Log(_life);

        _lifebar.SetValue(_life);

        if (_lifebar.Value == 0f)
        {
            Destroy(gameObject);
            _spawnManager.FinJeu();        
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gestionScene.ChangerSceneSuivante();
        }



    }
    public void Heal()
    {
        if (_lifebar.Value < 1f)
        {
            _life = _life + 0.1f;
            _lifebar.SetValue(_life);
        }

    }
    public void poison()
    {
        if (_lifebar.Value < 1f)
        {
            _life = _life - 0.1f;
            _lifebar.SetValue(_life);
        }
       

    }
}




