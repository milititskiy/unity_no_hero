using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public  class MenuScript : MonoBehaviour
{
    [MenuItem("Tools/Assign Tile Material")]
    public static void AssignTileMaterial()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles");
        Material material = Resources.Load<Material>("Tile");
        foreach (GameObject t in tiles)
        {
            t.GetComponent<Renderer>().material = material;
        }
    }

    [MenuItem("Tools/Assign Tile Script")]
    public static void AssignTileScript(){

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles");
        foreach (GameObject t in tiles)
        {
           t.AddComponent<Tile>();
        }

    }
    //[MenuItem("Tools/Add ClickOn To Selection")]
    //public static void AssignClickOnScript()
    //{
    //    GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles");
    //    foreach (GameObject t in tiles)
    //    {
    //        t.AddComponent<ClickOn>();
           
    //    }
    //}

    //[MenuItem("Tools/Remove Script ClickOn")]
    //public static void RemoveClickOnScript()
    //{
    //    GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles");
    //    foreach(GameObject t in tiles)
    //    {
    //        var script = t.GetComponent<ClickOn>();
    //        DestroyImmediate(script);
    //    }


    //}
}
