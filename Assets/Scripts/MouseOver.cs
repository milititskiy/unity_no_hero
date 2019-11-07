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

    


    GridBase grid;


    private void Start()
    {
        //line = GetComponent<LineRenderer>();
        //line.useWorldSpace = true;

    }
    public void Init()
    {
        Vector3 worldPos = GridBase.singleton.GetWorldCoordinatesFromTile(0,1,0);
        curUnit.transform.position = worldPos;
        
        GameObject go = new GameObject();
        go.transform.localPosition = new Vector3(0,1.5f,0);
        Material red = Resources.Load("Green", typeof(Material)) as Material;
        go.name = "move line";
        line = go.AddComponent<LineRenderer>();
        line.material = red;
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
                //if (tile.selectable == true)
                if(tile.visited)
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
                    for (int i = 0; i < shortPath.Count; i++)
                    {

                        line.SetPosition(i, shortPath[i].transform.position);
                        //Debug.Log(shortPath[i].transform.position);
                        

                    }
                    
                    
                }




                else
                {



                    line.positionCount = 0;
                    shortPath.Clear();


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
            }

            
        }

        
        if (player.moving)
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

    

































