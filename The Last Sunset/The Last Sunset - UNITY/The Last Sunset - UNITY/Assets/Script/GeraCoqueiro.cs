﻿using System.Collections;

using System.Collections.Generic;
using UnityEngine;

class Tilee
{
    public GameObject theTil;
    public float creationTimee;

    public Tilee(GameObject t, float ct)
    {
        theTil = t;
        creationTimee = ct;
    }
}

public class GeraCoqueiro : MonoBehaviour
{
    public GameObject plane;
    public GameObject player;


    public int planeSize = 10;
    public int halfTilesX = 10;
    public int halfTileZ = 15;


    Vector3 startPos;

    Hashtable tiles = new Hashtable();



    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos =Vector3.zero;
        float updateTime = Time.realtimeSinceStartup;

        for (int x = -halfTilesX; x < halfTilesX; x++)
        {
            for (int z = -halfTileZ; z < halfTileZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x),
                                           0,
                                          (z * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);


                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
        }



    }

    // Update is called once per frame
    void Update()
    {

        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor( planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z  / planeSize) * planeSize);

            for (int x = -halfTilesX; x < halfTilesX; x++)
            {
                for (int z = -halfTileZ; z < halfTileZ; z++)
                {
                    Vector3 pos = new Vector3( (x * planeSize + startPos.z),
                                               0,
                                              (z * planeSize + startPos.z));
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if (!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);

                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    else
                    {

                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }


                }

            }




            Hashtable newTerrain = new Hashtable();

            foreach (Tile tls in tiles.Values)
            {
                if (tls.creationTime != updateTime)
                {
                    Destroy(tls.theTile);

                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }

            }
            tiles = newTerrain;

            startPos = new Vector3(50,0, 0);

        }



    }
}

