using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{

    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] public static Transform spawnPosition;

    private List<GameObject> _activeArrow=new List<GameObject>();
    private List<GameObject> _passiveArrow=new List<GameObject>();
    private bool _isSpawning=true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            InstantiateArrow();
            StartCoroutine(nameof(Spawn));
        }
    }

    public void InstantiateArrow()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject ArrowObject = Instantiate(spawnPrefab,
            new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z),
            Quaternion.identity);

            // ArrowObject.transform.rotation=Quaternion.EulerRotation(euler:new Vector3(1,1,1));
            _passiveArrow.Add(ArrowObject);
        }
    }

    IEnumerator Spawn()
    {
        while (_isSpawning)
        {
            if (_passiveArrow.Count == 0)
            {
                for (int i = 0; i < _activeArrow.Count; i++)
                {
                    _passiveArrow.Add(_activeArrow[i]);
                    _passiveArrow[i].SetActive(false);
                    Destroy(_passiveArrow[i].GetComponent<MoveArrow>());
                    _activeArrow.Remove(_activeArrow[i]);
                }
            }

            for (int i = 0; i < _passiveArrow.Count; i++)
            {
                yield return new WaitForSeconds(5f);
                _passiveArrow[i].SetActive(true);
                _passiveArrow[i].transform.position = new Vector3(15, -5f);
                _passiveArrow[i].AddComponent<MoveArrow>();
                _activeArrow.Add(_passiveArrow[i]);
                _passiveArrow.Remove(_passiveArrow[i]);
            }

        }

    }
}
