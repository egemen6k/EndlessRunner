using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    ObjectPooler objectPooler;
    private float _zSpawn = 0f;
    private float tileLength = 30f;
    private int numberOfTiles = 5;
    private int _talesSize;

    private List<GameObject> _activeTiles;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _talesSize = objectPooler.poolDictionary.Count;
        _activeTiles = new List<GameObject>();

        for(int i = 0; i<numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, _talesSize));
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 35f > _zSpawn - (numberOfTiles*tileLength))
        {
            SpawnTile(Random.Range(0, 5));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject pooled = objectPooler.SpawnFromPool(tileIndex.ToString(), transform.forward * _zSpawn, transform.rotation);
        _zSpawn += tileLength;
        _activeTiles.Add(pooled);
    }

    private void DeleteTile()
    {
        _activeTiles[0].SetActive(false);
        _activeTiles.RemoveAt(0);
    }
}
