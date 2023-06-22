using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TerrainCreate 
{
    public static Terrain GetMap()
    {
        Terrain terrain = new Terrain(100, 100);
        int x = 0;
        int y = 0;
        float r = Random.value;
        for (int i = 0; i < terrain.Height/3; i++)
        {
            for (int j = 0; j <= x; j++) {
                if (Random.value < 0.5f) r += Random.value/3;
                else r -= Random.value;
                if (r > 3) r = 2;
                if (r < 0) r = 0;
                terrain.ChangeHeight(x, j, r);
                terrain.ChangeHeight(x + 1, j, r);
                terrain.ChangeHeight(x+2, j, r);
            }
            for (int j = 0; j <= y; j++)
            {
                if (Random.value < 0.5f) r += Random.value/3;
                else r -= Random.value;
                if (r > 3) r = 2;
                if (r < 0) r = 0;
                terrain.ChangeHeight(j, y, r);
                terrain.ChangeHeight(j, y + 1, r);
                terrain.ChangeHeight(j, y+2, r);
            }
            x+=3;
            y+=3;
        }
        return terrain;
    }
}
