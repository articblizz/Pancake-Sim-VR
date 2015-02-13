﻿using UnityEngine;
using System.Collections;

public class Pannkakan : MonoBehaviour {

	public GameObject bot;
	public GameObject top;

	GameObject side;
	public float Score = 0;
	public float colorTick; // def -0.001

    float tmpScore;

    float multiplier = 1;

    public float MaxPosX = 10;
    public float MaxPosZ = 4;

	//float lel = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //print(Score);
        if (Input.GetMouseButtonDown(1))
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;

        //var pos = Camera.main.transform.position;

        //pos = Vector3.MoveTowards(pos, new Vector3(0 , 2.72f, (-transform.position.y / 2) - 10), Vector3.Distance(pos, transform.position));
        ////pos.z = (-transform.position.y / 2) - 10;
        //if (pos.z >= -10f)
        //    pos.z = -10f;
        //if (pos.z <= -35f)
        //    pos.z = -35f;


        var pos = transform.position;

        if (pos.x >= MaxPosX)
            pos.x = MaxPosX;
        else if (pos.x <= -MaxPosX)
            pos.x = -MaxPosX;

        if (pos.z >= MaxPosZ)
            pos.z = MaxPosZ;
        else if (pos.z <= -MaxPosZ)
            pos.z = -MaxPosZ;

        if (transform.position.y >= 6)
        {
            //print(rigidbody.velocity.y);
            if(rigidbody.velocity.y > 0)
                multiplier = transform.position.y / 6;
        }


        transform.position = pos;
        //Camera.main.transform.position = pos;

        Score = tmpScore * multiplier;
	}

    //public void Stek(string sida, GameObject sender)

	public void Stek(object[] parameters)
	{
        var sida = (string)parameters[0];
        //var sender = (GameObject)parameters[1];
		Color c = new Color();
		
		if (sida == "top")
		{
			c = top.renderer.material.color;
			side = top;
		}
		else if (sida == "bot")
		{
			c = bot.renderer.material.color;
			side = bot;
		}



        //print(c.b);
		if (c.b <= 0 && tmpScore > 0)
		{
			tmpScore += c.b;
			if (tmpScore <= 0)
				tmpScore = 0;

            c.r += colorTick;
            c.g += colorTick;
            c.b += colorTick;
		}
		else
		{
			tmpScore -= colorTick * 100;

            c.r += colorTick / 10;
            c.g += colorTick / 2;
            c.b += colorTick;
		}

		side.renderer.material.color = c;
	}
}
