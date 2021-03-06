﻿using UnityEngine;
using System.Collections;

public class EnemyFSM : MonoBehaviour {

    public string enemyState;
    public int patrolFrom;
    public int patrolTo;
    public float enemySpeed = 0.2f;
    bool patrolRight = true;
    bool patrolLeft = false;
    public float proximity = 5.0f;
    private float distToPlayer;
    private int idleDuration;
    private int idleCounter;

    void Start()
    {
        idleCounter = 0;
        enemyState = "Patrol";
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(enemyState);
        if (enemyState != "Blinded")
        {
            distToPlayer = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            if (distToPlayer < proximity)
            {
                enemyState = "Discover";
            }
        }
        
        if (!GameObject.Find("Manager").GetComponent<LightController>().lights[GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom])
        {
            enemyState = "Blinded";
        }

        switch (enemyState)
        {
            case "Blinded":
                //Vector3 switchPos = GameObject.Find("Manager").GetComponent<GlobalVariables>().switchPositions[GameObject.Find("Manager").GetComponent<GlobalVariables>().currentRoom];
                break;

            case "Patrol":
                if (transform.position.x < patrolFrom && patrolRight)
                {
                    transform.Translate(transform.right * enemySpeed * Time.deltaTime);
                    //play walk right animation
                }
                if (transform.position.x > patrolFrom && patrolRight)
                {
                    patrolRight = false;
                    patrolLeft = true;
                    idleDuration = Random.Range(50,120);
                    idleCounter = 0;
                    enemyState = "Idle";
                }
                if (transform.position.x > patrolTo && patrolLeft)
                {
                    transform.Translate(-transform.right * enemySpeed * Time.deltaTime);
                    //Play walk left animation
                }
                if (transform.position.x < patrolTo && patrolLeft)
                {
                    patrolRight = true;
                    patrolLeft = false;
                    idleDuration = Random.Range(50, 120);
                    idleCounter = 0;
                    enemyState = "Idle";
                }
                break;
            
            case "Idle":
                //play idle animation
                if (idleCounter<idleDuration)
                {
                   idleCounter++;
                }
                else
                {
                    enemyState = "Patrol";
                }
                break;

            case "Discover":
                
                    //Run detect animation and then go to gameover screen

                break;
        }
	}

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(patrolTo, transform.position.y, 0), new Vector3(patrolFrom, transform.position.y, 0));
    }
}
