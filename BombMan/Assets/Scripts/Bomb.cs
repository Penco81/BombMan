using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float delay = 1.0f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, delay);
	}

    private void OnDestroy()
    {
        Instantiate(GameManager.Instance.fire, transform.position, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
