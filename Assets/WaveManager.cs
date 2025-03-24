using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Instantiate(GetEnemyType(i));
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