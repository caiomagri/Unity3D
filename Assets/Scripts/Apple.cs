using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private CircleCollider2D circleCollider;

	public GameObject collected;
	public int Score;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		circleCollider = GetComponent<CircleCollider2D>();
		
	}

	private void OnTriggerEnter2D(Collider2D collider) 
	{
		if(collider.gameObject.tag == "Player")
		{
			spriteRenderer.enabled = false;
			circleCollider.enabled = false;
			collected.SetActive(true);

			GameController.instance.totalScore += Score;
			GameController.instance.UpdateScoreText();

			Destroy(gameObject, 0.25f);
		}
	}
}
