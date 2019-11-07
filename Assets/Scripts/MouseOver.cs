using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.TB;

public class MouseOver : MonoBehaviour
{



    public List<Tile> shortPath = new List<Tile>();

    LineRenderer line;
    GameObject currentTile;

    public Transform curUnit;
    public PlayerMove player;
    bool hasPath;

    Tile unitTile;
    Tile curTile;
    Tile prevTile;

    List<Tile> path;


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
        go.name = "move line";
        line = go.AddComponent<LineRenderer>();
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
        OnMouseEnter();
        
    }


    

    void OnMouseEnter()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            TacticsMove tactics = GetComponent<TacticsMove>();
            Tile tile = hit.collider.GetComponent<Tile>();

            var arr = tactics.path.ToArray();
            if (hit.collider.CompareTag("Tiles"))
            {
                //tile.transform.position = hit.point;

                if (tile.selectable == true)
                {

                    tile.selectable = false;
                    tile.hoverOn = true;


                    shortPath.Clear();
                    

                    Tile next = tile;

                    while (next != null)
                    {

                        shortPath.Add(next);
                        next = next.parent;

                        
                        //Debug.Log(hit.point);

                    }

                    if (line == null)
                    {
                        //GameObject go = Instantiate(lineGO, pos, Quaternion.identity) as GameObject;
                        //line = go.GetComponent<LineRenderer>();

                        //line.transform.position = pos;
                        //line.enabled = true;
                        Debug.Log("here true");

                    }
                    
                    else
                    {
                        line.positionCount = shortPath.Count;
                        Debug.Log("vertex");
                        for (int i = 0; i < shortPath.Count; i++)
                        {

                            line.SetPosition(i, shortPath[i].transform.position);
                            
                        }
                    }
                }

            }




        }


    }







}
