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

    public Transform curUnit;

    bool hasPath;

    Tile unitTile;
    Tile curTile;
    Tile prevTile;

    Vector3 mousePos;

    

    


    private void Start()
    {
        //line = GetComponent<LineRenderer>();
        //line.useWorldSpace = true;

        
    }
    public void Init()
    {


        //Vector3 worldPos = GridBase.singleton.GetWorldCoordinatesFromTile(0, 1, 0);
        //curUnit.transform.position = worldPos;
        curUnit = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject go = new GameObject();
        go.transform.localPosition = new Vector3(0, 1.5f, 0);
        Material green = Resources.Load("Green", typeof(Material)) as Material;
        go.name = "move line";
        line = go.AddComponent<LineRenderer>();
        line.material = green;
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
    {

        OnMouseOver();

    }





    void OnMouseOver()
    {



        //Debug.Log(curUnit.transform.position);
        //curTile = GridBase.singleton.GetWorldCoordinatesFromTile(p, Mathf.RoundToInt(p.y), Mathf.RoundToInt(p.z));

        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        PlayerMove player = GetComponent<PlayerMove>();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
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

                    shortPath.Clear();
                    Tile next = tile;
                    while (next != null)
                    {
                        shortPath.Add(next);
                        next = next.parent;

                    }
                    
                    line.positionCount = shortPath.Count;
                    
                    //var j = shortPath.Count;
                    for (int i = 0; i < shortPath.Count; i++)
                    {
                        
                        line.SetPosition(i, shortPath[i].transform.position);
                        
                    }
                   

                }









                //else
                //{


                //    line.positionCount = 0;
                //    shortPath.Clear();


                //}


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
            }


        }


        //if (Input.GetMouseButtonDown(0))
        if(player)
        {
            //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (shortPath.Count > 0)
            {
                //Debug.Log(">0");
                //Debug.Log(shortPath.Count);
                //Debug.Log("hello");
                var p = player.transform.position;
                //lineTime += Time.deltaTime;
                var pX = Mathf.RoundToInt(p.x / 2.0f);
                var pY = Mathf.RoundToInt(p.y * 0);
                var pZ = Mathf.RoundToInt(p.z / 2.0f);
                var distance = (mousePos - p).magnitude;
                var playerTile = GridBase.singleton.GetWorldCoordinatesFromTile(pX, pY, pZ);
                
                var tile = GridBase.singleton.GetTileFromWorldPosition(curUnit.transform.position);

                var pos = curUnit.transform.position;
                Debug.Log(pos);
                
                

            }







        }

    }
        
    

}



































