using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public ActionManager ActionManager;
    public TurnManager TurnManager;

    public int WaveNumber = 1;

    [SerializeField] private int _nbPlatform;
    [SerializeField] private GameObject _prefabPlatform;
    [SerializeField] private float _offset;

    [HideInInspector] public GameObject[] Platforms;
    public EmplacementData[] EmplacementsData;

    [SerializeField] private GameObject _player;
    public int _emplacementPlayerStart;

    void Start()
    {
        Platforms = new GameObject[_nbPlatform];

        EmplacementsData = new EmplacementData[_nbPlatform];

        float totalOffset = 0;
        for (int i = 0; i < _nbPlatform; i++)
        {
            SpriteRenderer spriteRenderer = _prefabPlatform.GetComponent<SpriteRenderer>();
            Vector3 instPos = new Vector3(totalOffset, 0, 0);
            Platforms[i] = Instantiate(_prefabPlatform, instPos, Quaternion.identity);
            Platforms[i].name = "Platform " + i;

            EmplacementsData[i] = Platforms[i].GetComponent<EmplacementData>();
            EmplacementsData[i].PlatformEmplacement = Platforms[i];

            totalOffset = totalOffset + _offset + spriteRenderer.bounds.size.x / 2;

        }

        SpriteRenderer playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();
        Vector3 instPosPlayer = new Vector3(Platforms[_emplacementPlayerStart].transform.position.x, playerSpriteRenderer.bounds.size.y / 2 + Platforms[_emplacementPlayerStart].GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);
        _player = Instantiate(_player, instPosPlayer, Quaternion.identity);
        _player.GetComponent<PlayerController>().MainGame = this;

        EmplacementsData[_emplacementPlayerStart].GameobjectOnEmplacement = _player;

        TurnManager.MainGame = this;

    }

    void Update()
    {
        
    }
}




