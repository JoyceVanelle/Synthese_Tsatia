using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy = default;
    [SerializeField] private GameObject _prefabEnemy2 = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private GameObject _enemyContainer2 = default;
    [SerializeField] private GameObject[] _listePUPrefabs = default;
    private bool _stopSpawn = false;
    private bool _stopSpawn2 = false;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(SpawnEnemyRouting());
        StartCoroutine(SpawnEnemy2Routing());
    }

    // Update is called once per frame
   

    IEnumerator SpawnEnemyRouting()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawn == false)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0f);
            GameObject newEnemy = Instantiate(_prefabEnemy, posSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }

    }
    IEnumerator SpawnEnemy2Routing()
    {
        yield return new WaitForSeconds(3.0f);
        while (_stopSpawn2 == false)
        {
            //Vector3 posiSpawn = new Vector3(Random.Range(-7.0f, 7.0f), -0.5f, 0f);
            Vector3 posiSpawn = new Vector3(7.0f, -3f, 0f);
            GameObject newEnemy2 = Instantiate(_prefabEnemy2, posiSpawn, Quaternion.identity);
            newEnemy2.transform.parent = _enemyContainer2.transform;
            yield return new WaitForSeconds(2f);
        }
    }
    
    public void FinJeu()
    {
        _stopSpawn = true;
        _stopSpawn2 = true;
    }
}
