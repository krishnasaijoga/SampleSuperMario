using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_health : MonoBehaviour {
    public static int lives=3;
    public bool hasDied;
    public int health;
	// Use this for initialization
	void Start () {
        hasDied = false;
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -7)
            hasDied = true;
        if (hasDied == true)
            StartCoroutine("Die");
	}
    IEnumerator Die ()
    {
        if (lives == 0)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
        lives--;
        SceneManager.LoadScene("prototype1");
        yield return null;
        /*Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has Died");*/
    }
}
