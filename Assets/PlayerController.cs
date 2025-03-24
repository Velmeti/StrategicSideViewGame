using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [HideInInspector] public MainGame MainGame;

    public int playerPos = 0;

    private int facing = 1;


    void Start()
    {
        playerPos = MainGame._emplacementPlayerStart;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(-1);
        }
    }

    
    private void Move(int direction)
    {
        if (!MainGame.ActionManager.CanDoAction())
            return;

        if (facing == direction)
        {
            if (!isValidPos(direction))
                return;

            TradePosition(direction);

            MainGame.EmplacementsData[playerPos + direction].GameobjectOnEmplacement = this.gameObject;
            playerPos += direction;

            transform.position = new Vector2(MainGame.Platforms[playerPos].transform.position.x, transform.position.y);
        }
        else
        {
            facing = direction;
            transform.localScale = new Vector2(direction, transform.localScale.y);
        }

        MainGame.ActionManager.DecreaseAction();
    }


    private bool isValidPos(int direction)
    {
        if (playerPos + direction < 0 || playerPos + direction > MainGame.Platforms.Length - 1)
            return false;
        return true;
    }


    private void TradePosition(int direction)
    {
        if (MainGame.EmplacementsData[playerPos + direction].GameobjectOnEmplacement == null)
        {
            MainGame.EmplacementsData[playerPos].GameobjectOnEmplacement = null;
            return;
        }

        MainGame.EmplacementsData[playerPos].GameobjectOnEmplacement = MainGame.EmplacementsData[playerPos + direction].GameobjectOnEmplacement;
        MainGame.EmplacementsData[playerPos].GameobjectOnEmplacement.transform.position = new Vector2(MainGame.EmplacementsData[playerPos].PlatformEmplacement.transform.position.x, transform.position.y);
    }
}
