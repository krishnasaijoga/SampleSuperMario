using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour {
    public int enemySpeed;
    public int enemyXDirection;
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(enemyXDirection,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyXDirection, 0) * enemySpeed;
        if (hit.distance < 0.7f)
            Flip();
	}

    void Flip()
    {
        //enemyXDirection = -1*enemyXDirection;
        if (enemyXDirection < 0)
            enemyXDirection = 1;
        else enemyXDirection = -1;
    }
}
