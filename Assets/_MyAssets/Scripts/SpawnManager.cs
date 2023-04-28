using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy = default;
    [SerializeField] private GameObject _enemyContainer = default;
    [SerializeField] private GameObject[] _listePUPrefabs = default;
    private bool _stopSpawn = false;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(SpawnEnemyRouting());
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

    public void FinJeu()
    {
        _stopSpawn = true;
    }
}
