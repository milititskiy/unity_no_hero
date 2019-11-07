    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;
    namespace SA.TB
    {

    public class PlayerMove : TacticsMove
    {
        [SerializeField]
            private Material red;
        [SerializeField]
        private Material clear;
        private MeshRenderer objRendered;

        //public Transform curUnit;
        //public PlayerMove player;

        //public void Init()
        //{
        //    Vector3 worldPos = GridBase.singleton.WorldCoordinatedFromTile(4, 2, 12);
        //    curUnit.transform.position = worldPos;
        //}

        public static PlayerMove singleton;
        private void Awake()
        {
            singleton = this;
        }
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
    }
