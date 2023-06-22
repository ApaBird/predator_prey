using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain
{
    private List<List<float>> map;
    private float width;
    private float height;//переименовать в длину
    public float Width { get => width; set => width = value; }
    public float Height { get => height; set => height = value; }//переименовать в длину

    public Terrain(int width, int height)
    {
        this.map = new List<List<float>>();
        this.width = width;
        this.height = height;
        for (int i = 0; i < height + 2; i++)
        {
            List<float> list = new List<float>();
            for(int j = 0; j < width + 2; j++)
            {
                list.Add(1);
            }
            this.map.Add(list);
        }
    }

    public void ChangeHeight(int x, int z, float num) //Релизовать SetHeight для точечного выставления высоты
    {
        if(x > 0 && x < width && z > 0 && z < height)
            map[x][z] += num;
    }

    public float GetValueMap(int i, int j)
    {
        return map[i][j];
    }

    public float GetHeightDot(Vector2 pos) => GetHeightDot(pos.x, pos.y);

    public float GetHeightDot(float x, float z)
    {
        if (x > 0 && x < width && z > 0 && z < height)
        {
            Vector3 dot1 = new Vector3((int)Mathf.Floor(x+1), map[(int)Mathf.Floor(x+1)][(int)Mathf.Floor(z)], (int)Mathf.Floor(z));
            Vector3 dot2 = new Vector3((int)Mathf.Floor(x), map[(int)Mathf.Floor(x)][(int)Mathf.Floor(z+1)], (int)Mathf.Floor(z+1));
            Vector3 dot3;
            if (Mathf.Abs(x - z) < 0.5f)//неверная формула, верная x - z > 0
            {
                dot3 = new Vector3((int)Mathf.Floor(x + 1), map[(int)Mathf.Floor(x + 1)][(int)Mathf.Floor(z+1)], (int)Mathf.Floor(z + 1));
            }
            else
            {
                dot3 = new Vector3((int)Mathf.Floor(x), map[(int)Mathf.Floor(x)][(int)Mathf.Floor(z)], (int)Mathf.Floor(z));
            }

            Vector3 n = Vector3.Cross(dot2 - dot1, dot3 - dot1);

            return -(n.x * x + n.z * z - n.x * dot1.x - n.y * dot1.y - n.z * dot1.z) / n.y;
        }
        else if ((x == 0 || x == width) && (z == 0 || z == height))
        {
            return map[(int)x][(int)z];
        }
        else if (x == 0 || x == width || z == 0 || z == height)
        {
            Vector3 dot1;
            Vector3 dot2;
            if(x == 0 || x == width)
            {
                dot1 = new Vector3((int)x, map[(int)x][(int)Mathf.Ceil(z)], (int)Mathf.Ceil(z));
                dot2 = new Vector3((int)x, map[(int)x][(int)Mathf.Floor(z)], (int)Mathf.Floor(z));
                Vector3 p = dot1 - dot2;
                return ((z - dot1.z) * p.y) / p.z + dot1.y;
            }
            else
            {
                dot1 = new Vector3((int)Mathf.Ceil(x), map[(int)Mathf.Ceil(x)][(int)z], (int)z);
                dot2 = new Vector3((int)Mathf.Ceil(x), map[(int)Mathf.Floor(x)][(int)z], (int)z);
                Vector3 p = dot1 - dot2;
                return ((x - dot1.x) * p.y) / p.x + dot1.y;
            }
            //y = ((z - z0)*p2)/p3 + y0 где z0,y0 - точка линии, а p2,p3 - направляющий вектор
        }
        else
        {
            return 1;
        }
    }
}
