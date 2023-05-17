using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy = default;
    [SerializeField] private GameObject _prefabEnemy2 = default;
    [SerializeField] private GameObject _prefabball = default;
    [SerializeField] private GameObject _prefabPotion = default;
    [SerializeField] private GameObject _prefabPioson = default;
    [SerializeField] private GameObject _prefabStone = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private GameObject _enemyContainer2 = default;
    [SerializeField] private GameObject _enemyContainer3 = default;
    [SerializeField] private GameObject _enemyContainer4 = default;
    [SerializeField] private GameObject _enemyContainer5 = default;
    [SerializeField] private GameObject _enemyContainer6 = default;
    private UIManager _uiManager;
    //[SerializeField] private GameObject[] _listePUPrefabs = default;
    private bool _stopSpawn4 = false;
    private bool _stopSpawn2 = false;
    private bool _stopSpawn3 = false;
    private bool _stopSpawn = false;
    private bool _stopSpawn5 = false;
    private bool _stopSpawn6 = false;


    private bool _displayStone = true;

    // Start is called before the first frame update
    public void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        StartCoroutine(SpawnEnemyRouting());
        StartCoroutine(SpawnEnemy2Routing());
        StartCoroutine(SpawnEnemyRouting3());
        StartCoroutine(SpawnEnemyRouting4());
        StartCoroutine(SpawnEnemyRouting6());

    }
    public void Update()
    {
        if(_uiManager.GetScore() > 800 && _displayStone)
        {
            StartCoroutine(SpawnStoneRouting());
            _displayStone= false;
        }
    }

    // Update is called once per frameaaaaaa


    IEnumerator SpawnEnemyRouting()
    {
        yield return new WaitForSeconds(5.0f);
        while (!_stopSpawn)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newEnemy = Instantiate(_prefabEnemy, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(15f);
        }

    }
    IEnumerator SpawnEnemy2Routing()
    {
        yield return new WaitForSeconds(7.0f);
        while (!_stopSpawn2)
        {
            //Vector3 posiSpawn = new Vector3(Random.Range(-7.0f, 7.0f), -0.5f, 0f);
            Vector3 posiSpawn = new Vector3(7.0f, -3f, 0f);
            GameObject newEnemy2 = Instantiate(_prefabEnemy2, posiSpawn, Quaternion.identity);
            newEnemy2.transform.parent = _enemyContainer2.transform;
            yield return new WaitForSeconds(10f);
        }
    }
    IEnumerator SpawnEnemyRouting3()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawn3)
        {
            // Vector3 posSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            Vector3 posiSpawn3 = new Vector3(7.0f, -3f, 0f);
            GameObject newEnemy3 = Instantiate(_prefabball, posiSpawn3, Quaternion.identity);
            newEnemy3.transform.parent = _enemyContainer3.transform;
            yield return new WaitForSeconds(15f);
        }

    }

    IEnumerator SpawnEnemyRouting4()
    {
        yield return new WaitForSeconds(10f);
        while (!_stopSpawn4)
        {
            Vector3 posSpawn4 = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newEnemy4 = Instantiate(_prefabPotion, posSpawn4, Quaternion.identity);
            newEnemy4.transform.parent = _enemyContainer4.transform;
            yield return new WaitForSeconds(10f);
        }

    }
    IEnumerator SpawnStoneRouting()
    {
        yield return new WaitForSeconds(3f);
        while (!_stopSpawn5)
        {
            Vector3 posSpawn5 = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newEnemy5 = Instantiate(_prefabStone, posSpawn5, Quaternion.identity);
            newEnemy5.transform.parent = _enemyContainer5.transform;
            yield return new WaitForSeconds(5f);
        }

    }
    IEnumerator SpawnEnemyRouting6()
    {
        yield return new WaitForSeconds(4f);
        while (!_stopSpawn6)
        {
            Vector3 posSpawn6 = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newEnemy6 = Instantiate(_prefabPioson, posSpawn6, Quaternion.identity);
            newEnemy6.transform.parent = _enemyContainer6.transform;
            yield return new WaitForSeconds(6f);
        }

    }

    public void FinJeu()
    {
        _stopSpawn5 = true;
        _stopSpawn6 = true;
        _stopSpawn4 = true;
        _stopSpawn2 = true;
        _stopSpawn3 = true;
        _stopSpawn = true;
    }
}
