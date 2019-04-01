using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.25f);
        int row = (int)transform.position.y;
        int col = (int)transform.position.x;
        int[] dr = { 1, -1, 0, 0 };
        int[] dc = { 0, 0, 1, -1 };
        for (int i = 0; i < 4; i++)
        {
            int newc = col + dc[i];
            int newr = row + dr[i];
            if (newc < 0 || newc >= GameManager.countCol || newr < 0 || newr >= GameManager.countRow)
                continue;
            if(GameManager.Instance.map[newr, newc] != null && GameManager.Instance.map[newr,newc].gameObject.name.Contains("Wall"))
            {
                Destroy(GameManager.Instance.map[newr, newc].gameObject);
                GameManager.Instance.map[newr, newc] = null;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "monster")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
