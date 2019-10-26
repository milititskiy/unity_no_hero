using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : TacticsMove
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material clear;

    private MeshRenderer objRendered;

    

    // Start is called before the first frame update
    void Start()
    {
        objRendered = GetComponent<MeshRenderer>();
        Init();

    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if(!turn)
        {
            return;
        }
       
        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();

        }
        else
        {
            Move();
        }

        



        

    }

   


    public void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("player move");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tiles")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {   //todo:move target
                        MoveToTile(t);
                    }
                }
                
            }
            
        }
    }
    public void clickMe()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    if(currentlySelected == false)
                    {
                        objRendered.material = clear;
                    
                    }
                    else
                    {

                        objRendered.material = red;

                    }
                    
                }
                

            }
    }
    
    public void SelectedClick()
    {
        
        if (currentlySelected == false)
        {
            objRendered.material = clear;
            
        }
        else
        {
            
            objRendered.material = red;

        }
    }
        
            

        
}
