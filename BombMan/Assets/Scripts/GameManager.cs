using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public const int countCol = 25;
    public const int countRow = 20;
    private const float length = 1f;
    public GameObject[,] map = new GameObject[countRow, countCol];
    public Transform container;
    public float startC;
    public float startR;
    public GameObject metal;
    public GameObject wall;
    public GameObject bomb;
    public GameObject fire;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>() as GameManager;
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
    }

    // Use this for initialization
    void Start () {
        //生成金属
		for(int i = 0; i < countCol; i++)
        {
            for(int j = 0; j < countRow; j++)
            {
                if(i == 0 || j == 0 || i == countCol - 1 || j == countRow - 1)
                {
                    GameObject go = Instantiate(metal, new Vector2(i, j), Quaternion.identity);
                    map[j, i] = go;
                    go.transform.SetParent(container);
                }
                else if(i % 2 == 0  && j % 2 == 0)
                {
                    GameObject go = Instantiate(metal, new Vector2(i, j), Quaternion.identity);
                    map[j, i] = go;
                    go.transform.SetParent(container);
                }
            }
        }

        //生成墙
        for(int i = 0; i < 100; i++)
        {
            int row, col;
            do
            {
                row = Random.Range(1, countRow - 2);
                col = Random.Range(1, countCol - 2);
                if (row == 1 && col == 1 || row == 2 && col == 1 || row == 1 && col == 2)
                    continue;
            } while (map[row, col] != null || (row == 1 && col == 1 || row == 2 && col == 1 || row == 1 && col == 2));
            GameObject go = Instantiate(wall, new Vector2(col, row), Quaternion.identity);
            go.transform.SetParent(container);
            map[row, col] = go;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Debug.Log("You lose!");
    }

    public void GameWin()
    {

    }
}
