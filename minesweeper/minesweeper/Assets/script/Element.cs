﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{

    public bool mine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Default";
    }

    void OnMouseUpAsButton()
    {
        if (mine)
        {
            Grid.uncoverMines();

            print("You lose");
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(Grid.adjacentMines(x, y));

            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

            if (Grid.isFinished())
                print("you win");

        }

    }
}
