using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.TB;

public class MouseOver : MonoBehaviour
{
    public float delay = 40f;


    public List<Tile> shortPath = new List<Tile>();
    public List<Transform> playerPosList = new List<Transform>();

    public bool useCurve = true;
    public float width = 1.0f;

    LineRenderer line;
    

    public Transform curUnit;

    bool hasPath;

    Tile unitTile;
    Tile curTile;
    Tile prevTile;

    Vector3 mousePos;



    private LineRenderer lr;


    private void Start()
    {
        //line = GetComponent<LineRenderer>();
        //line.useWorldSpace = true;
       
        // Set some positions
       

    }
    public void Init()
    {


        Vector3 worldPos = GridBase.singleton.GetWorldCoordinatesFromTile(0, 1, 0);
        curUnit.transform.position = worldPos;
        //curUnit = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject go = new GameObject();
        go.transform.localPosition = new Vector3(0, 1.5f, 0);
        //GameObject go = GameObject.FindGameObjectWithTag("Player");
        //go.transform.position = curUnit.transform.position;
        Material green = Resources.Load("Green", typeof(Material)) as Material;
        go.name = "move line";
        go.transform.tag = "Line";
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

        //Debug.Log(go.transform.position);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            PlayerMove player = GetComponent<PlayerMove>();
            Tile tile = hit.collider.GetComponent<Tile>();
            

            if (hit.collider.CompareTag("Tiles"))
            {
                if (tile.selectable)
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

                    //Debug.Log(shortPath.Count - 1);
                    

                    for (int i = 0; i < shortPath.Count; i++)
                    {
                        //line.SetPosition(0, go.transform.position);
                        line.SetPosition(i, shortPath[i].transform.position);
                    }


                    
                    if (player.moving)
                    {


                        var sel = GetComponent<TacticsMove>();

                        foreach (Tile t in sel.selectableTiles)
                        {
                            t.selectable = false;

                        }


                        
                        var p = curUnit.transform.position;

                        var pX = Mathf.RoundToInt(p.x / 2.0f);
                        var pY = Mathf.RoundToInt(p.y * 0);
                        var pZ = Mathf.RoundToInt(p.z / 2.0f);

                        var playerTile = GridBase.singleton.GetWorldCoordinatesFromTile(pX, pY, pZ);
                        
                        StartCoroutine(RemoveSegments());

                    }

                }
                
                
                    






            }

            

        }

    }






























        
        


    IEnumerator RemoveSegments()
    {
        
        for (int i = shortPath.Count - 1; i > 0; i--)
        {
            line.positionCount = i;
            yield return new WaitForSeconds(0.5f);
            
        }
    }


}



































