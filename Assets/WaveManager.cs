using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WaveManager : MonoBehaviour
{
    public MainGame MainGame;

    [SerializeField] private GameObject _normalPrefab;
    [SerializeField] private GameObject _assassinPrefab;
    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private GameObject _spearmanPrefab;
    [SerializeField] private GameObject _wizardPrefab;

    [SerializeField] private WaveElementOfType[] _elements;

    private int enemyRemaining = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        for (int i = 0; i < _elements.Length; i++)
        {
            enemyRemaining += _elements[i].NumberOfEnemies;
            for (int j = 0; j < _elements[i].NumberOfEnemies; j++)
            {
                RandomizeSpawn(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject GetEnemyType(int index)
    {
        switch (_elements[index].SelectedEnemyType)
        {
            case EnemyType.Normal:
                return _normalPrefab;

            case EnemyType.Assassin:
                return _assassinPrefab;

            case EnemyType.Tank:
                return _tankPrefab;

            case EnemyType.Spearman:
                return _spearmanPrefab;

            case EnemyType.Wizard:
                return _wizardPrefab;
        }
        return null;
    }


    public void RandomizeSpawn(int index)
    {
        int emplacementFullCount = 0;
        for (int i = 0; i < MainGame.EmplacementsData.Length; i++)
        {
            if (MainGame.EmplacementsData[i].GameobjectOnEmplacement != null)
            {
                emplacementFullCount++;
            }
        }
        
        if (emplacementFullCount == MainGame.EmplacementsData.Length)
        {
            Debug.Log("End Randomize Spawn for all emplacements full. Number of emplacements full : " + emplacementFullCount);
            return;
        }

        int posIndex = UnityEngine.Random.Range(0, MainGame.EmplacementsData.Length);
        if (MainGame.EmplacementsData[posIndex].GameobjectOnEmplacement != null)
        {
            RandomizeSpawn(index);
            return;
        }

        Vector3 posToInst = MainGame.EmplacementsData[posIndex].PlatformEmplacement.transform.position;
        GameObject enemy = Instantiate(GetEnemyType(index), posToInst, Quaternion.identity);
        SpriteRenderer enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
        enemy.transform.position = new Vector3(posToInst.x, enemySpriteRenderer.bounds.size.y / 2 + MainGame.EmplacementsData[posIndex].PlatformEmplacement.GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);

        MainGame.EmplacementsData[posIndex].GameobjectOnEmplacement = enemy;
    }

}



[Serializable]
public class WaveElementOfType
{
    public int NumberOfEnemies = 0;

    public EnemyType SelectedEnemyType;
}




public enum EnemyType
{
    Normal,
    Assassin,
    Tank,
    Spearman,
    Wizard
}