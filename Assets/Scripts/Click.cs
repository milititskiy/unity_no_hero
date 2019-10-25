using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickablesLayer;
    private List<GameObject> selectedObjects;

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
                playerMove.currentlySelected = true;
                playerMove.clickMe();
                
                
                
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
        //var inCombat = TurnManager.inCombat;
        //TurnManager.InitTeamTurnQueue();

        if (TurnManager.inCombat == false)
        {

            TurnManager.inCombat = true;

        }
    }

    public void StartGame()
    {
        var inCombat = TurnManager.inCombat;
        TurnManager.InitTeamTurnQueue();
    }

}
