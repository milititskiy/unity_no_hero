using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : TurnManager
{
    [SerializeField]
    private LayerMask clickablesLayer;
    private List<GameObject> selectedObjects;

    private GameObject objToSpawn;
    private GameObject [] tiles;

    private Color startcolor;
    Renderer rend;

    private void Start()
    {
        selectedObjects = new List<GameObject>();
        
    }
    // Update is called once per frame
    void Update()
    {
       
       
        if (Input.GetMouseButtonDown(1))
        {
            if (selectedObjects.Count > 0)
            {
                 Debug.Log("right click");
                foreach (GameObject obj in selectedObjects)
                {
                    obj.GetComponent<PlayerMove>().currentlySelected = false;
                    obj.GetComponent<PlayerMove>().clickMe();
                }
                selectedObjects.Clear();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, clickablesLayer))
            {

                PlayerMove playerMove = hit.collider.GetComponent<PlayerMove>();


                if (Input.GetKey("left ctrl"))
                {
                    if (playerMove.currentlySelected == false)
                    {
                        selectedObjects.Add(hit.collider.gameObject);
                        playerMove.currentlySelected = true;
                        playerMove.clickMe();
                    }
                    else
                    {
                        selectedObjects.Remove(hit.collider.gameObject);
                        playerMove.currentlySelected = false;
                        playerMove.clickMe();
                    }


                }
                else
                {
                    if (selectedObjects.Count > 0)
                    {
                        foreach (GameObject obj in selectedObjects)
                        {
                            obj.GetComponent<PlayerMove>().currentlySelected = false;
                            obj.GetComponent<PlayerMove>().clickMe();

                        }
                        selectedObjects.Clear();

                    }

                }

                selectedObjects.Add(hit.collider.gameObject);
                //playerMove.currentlySelected = true;
                //playerMove.clickMe();



            }


        }







    }



                        




    public void EndTurnButton()
    {
        var endedTurn = TurnManager.endedTurn;
        //Debug.Log(endedTurn);
        if(endedTurn == false)
        {
            //Debug.Log("ended turn");
            //endedTurn = true;
            TurnManager.EndTurn();
        }



    }

    public void StartCombat()
    {   
        if(currentState != BattleStates.INCOMBAT)
        {
            if (TurnManager.inCombat == false)
            {
                TurnManager.inCombat = true;
            }
            currentState = BattleStates.INCOMBAT;
            
        }
        Spawn();
        

       
        
    }
        
       
        



    public void StartAction()
    {
        //var inCombat = TurnManager.inCombat;
        //TurnManager.InitTeamTurnQueue();
    }

    public void Spawn()
    {
        Material red = Resources.Load("Green", typeof(Material)) as Material;
        //objToSpawn = new GameObject("ORCS!!!");
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = gameObject.GetComponent<MeshFilter>().mesh;
        objToSpawn = GameObject.CreatePrimitive(PrimitiveType.Cube);
        MeshRenderer meshRenderer = objToSpawn.GetComponent<MeshRenderer>();
        objToSpawn.AddComponent<NPCMove>();
        meshRenderer.material = red;
        //true generator starts here
        tiles = GameObject.FindGameObjectsWithTag("Tiles");
        var index = Random.Range(0, tiles.Length);
        Tile tile = tiles[index].GetComponent<Tile>();
        if (tile!= null && tile.walkable)
        {
            var p = tile.transform.position;
            Vector3 pos = new Vector3(p.x, 1.9F, p.z);
            Instantiate(objToSpawn, pos, Quaternion.identity);
            Destroy(objToSpawn);
        }
    }


    
}