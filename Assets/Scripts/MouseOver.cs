using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.TB;

public class MouseOver : MonoBehaviour
{



    public List<Tile> shortPath = new List<Tile>();
    public List<Transform> playerPosList = new List<Transform>();

    

    LineRenderer line;
    GameObject currentTile;

<<<<<<< HEAD
    public Transform curUnit;

=======
    public Transform curUnit;

>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
    bool hasPath;

    Tile unitTile;
    Tile curTile;
<<<<<<< HEAD
    Tile prevTile;




    GridBase grid;
=======
    Tile prevTile;

    Vector3 mousePos;

    

    
>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a


    private void Start()
    {
        //line = GetComponent<LineRenderer>();
        //line.useWorldSpace = true;
        

    }
    public void Init()
    {
        Vector3 worldPos = GridBase.singleton.GetWorldCoordinatesFromTile(0, 1, 0);
<<<<<<< HEAD
        curUnit.transform.position = worldPos;

        GameObject go = new GameObject();
        go.transform.localPosition = new Vector3(0, 1.5f, 0);
        Material red = Resources.Load("Green", typeof(Material)) as Material;
        go.name = "move line";
        line = go.AddComponent<LineRenderer>();
        line.material = red;
=======
        curUnit.transform.position = worldPos;

        GameObject go = new GameObject();
        go.transform.localPosition = new Vector3(0, 1.5f, 0);
        Material green = Resources.Load("Green", typeof(Material)) as Material;
        go.name = "move line";
        line = go.AddComponent<LineRenderer>();
        line.material = green;
>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
        line.useWorldSpace = false;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;

    }

    public static MouseOver singleton;

    private void Awake()
    {
        singleton = this;
    }

    private void Update()
<<<<<<< HEAD
    {

        OnMouseOver();

    }





    void OnMouseOver()
    {



        //Debug.Log(curUnit.transform.position);
        //curTile = GridBase.singleton.GetWorldCoordinatesFromTile(p, Mathf.RoundToInt(p.y), Mathf.RoundToInt(p.z));



=======
    {

        OnMouseOver();

    }





    void OnMouseOver()
    {



        //Debug.Log(curUnit.transform.position);
        //curTile = GridBase.singleton.GetWorldCoordinatesFromTile(p, Mathf.RoundToInt(p.y), Mathf.RoundToInt(p.z));

        

>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        PlayerMove player = GetComponent<PlayerMove>();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
<<<<<<< HEAD
        {


            Tile tile = hit.collider.GetComponent<Tile>();

            if (hit.collider.CompareTag("Tiles"))
            {
                //if (tile.selectable == true)
                if (tile.visited)
                {
                    tile.selectable = false;
                    tile.hoverOn = true;
                    //tile.target = true;

=======
        {
            

            Tile tile = hit.collider.GetComponent<Tile>();

            if (hit.collider.CompareTag("Tiles"))
            {
                if (tile.selectable == true)
                //if(Input.GetMouseButtonDown(0) && tile.selectable)
                {
                    tile.selectable = false;
                    tile.hoverOn = true;
                    //tile.target = true;

>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
                    shortPath.Clear();
                    Tile next = tile;
                    while (next != null)
                    {
                        shortPath.Add(next);
<<<<<<< HEAD
                        next = next.parent;

                    }
=======
                        next = next.parent;
>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a

                    }
                    Debug.Log(shortPath.Count);
                    line.positionCount = shortPath.Count;
                    
                    //var j = shortPath.Count;
                    for (int i = 0; i < shortPath.Count; i++)
                    {
<<<<<<< HEAD

                        line.SetPosition(i, shortPath[i].transform.position);
                        //Debug.Log(shortPath[i].transform.position);


                    }


=======
                        Debug.Log("hello");
                        line.SetPosition(i, shortPath[i].transform.position);
                        
                    }
                   

>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
                }




<<<<<<< HEAD
                else
                {



                    line.positionCount = 0;
                    shortPath.Clear();
=======





                //else
                //{


                //    line.positionCount = 0;
                //    shortPath.Clear();
>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a


                }


                //else 
                //{

                //var player = GetComponent<PlayerMove>();
                //if(player.moving == true)
                //{
                //    line.positionCount = 0;
                //    shortPath.Clear();
                //}

                //if (hit.collider.CompareTag("Player"))
                //{
                //    line.positionCount = 0;
                //    shortPath.Clear();
                //}
                //if (tile.target == true)
                //{
                //    line.positionCount = 0;
                //    shortPath.Clear();
                //}
                //if(tile.current == true)
                //{
                //    line.positionCount = 0;
                //    shortPath.Clear();
                //}

                //line.positionCount = 0;
                //shortPath.Clear();

                //}
<<<<<<< HEAD
            }


        }


        if (player.moving)

        {//Got the trace waypoint to dissappear

            Debug.Log("separator");

            {

                //Debug.Log("separator");

                playerPosList.Clear();
                for (int i = shortPath.Count - 1; i >= 0; i--)
                {
                    shortPath.RemoveAt(i);
                    Debug.Log(shortPath.Count);
                    var zero = Vector3.zero;
                    line.SetPosition(i, zero);

                }
                //var playerPos = player.transform;
                //playerPosList.Add(playerPos);

                //Debug.Log(playerPosList[playerPosList.Count -1].transform.position);

                //curTile = GridBase.singleton.GetTileFromWorldPosition(player.transform.position);

                //Debug.Log(curTile.transform.position);

                //Debug.Log(curTile.transform.position);

                //line.positionCount = 0;
                //shortPath.Clear();
                //for (int i = 0; i < shortPath.Count; i++)
                //{
                //playerPosList.Add(playerPos);
                //var l1 = playerPosList;
                //var ls = shortPath;
                //if(l1[i].position == shortPath[i].transform.position)
                //{
                //    Debug.Log("Commit");
                //}
            }
            //shortPath.Clear();
        }
        //else
        //{
        //Debug.Log("not moving");
        //}

    }
}
    
=======
            }


        }


        //if (Input.GetMouseButtonDown(0))
        //{   
        //    //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    if(shortPath.Count > 0)
        //    {
        //        //Debug.Log(">0");
        //        //Debug.Log(shortPath.Count);
        //        //Debug.Log("hello");
        //        var p = player.transform.position;
        //        //lineTime += Time.deltaTime;
        //        var pX = Mathf.RoundToInt(p.x / 2.0f);
        //        var pY = Mathf.RoundToInt(p.y * 0);
        //        var pZ = Mathf.RoundToInt(p.z / 2.0f);
        //        var distance = (mousePos - p).magnitude;
        //        //var playerTile = GridBase.singleton.GetWorldCoordinatesFromTile(pX, pY, pZ);
                
             
                
        //    }
            
            
            


            
            
        //}
       
    }
        
    

}



>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
































<<<<<<< HEAD

=======
>>>>>>> 6f29afe9ee92c0708aa10ca857fceca69d26a87a
