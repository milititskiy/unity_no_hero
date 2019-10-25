using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static Dictionary<string, List<TacticsMove>> units = new Dictionary<string, List<TacticsMove>>();
    public static Queue<string> turnKey = new Queue<string>();
    public static Queue<TacticsMove> turnTeam = new Queue<TacticsMove>();

    public static bool inCombat = false;
    public static bool endedTurn = false;
    public static bool currentlySelected = false;

    public static PlayerMove playerMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        

        if (turnTeam.Count == 0)
        {
            
            if (inCombat == true)
            {
                
                InitTeamTurnQueue();
                
            }
            else
            {
                return;
            }
        }


    }


    public static void InitTeamTurnQueue()
    {
        List<TacticsMove> teamList = units[turnKey.Peek()];

        
            if(inCombat == true)
            {
                foreach (TacticsMove unit in teamList)
                    {
                    //Debug.Log(unit);
                    turnTeam.Enqueue(unit);
                    
                    }
                    StartTurn();
        }
            else
            {
                foreach (TacticsMove unit in teamList)
                {
                    //Debug.Log(unit);
                    
                    turnTeam.Enqueue(unit);
                    unit.move = 18;
                   
                }
                
                StartTurn();
            }
            

            


    }


   public static void StartTurn()
    {

        if(turnTeam.Count > 0)
        {
            
            TacticsMove unit = turnTeam.Peek();
            unit.currentlySelected = true;
            unit.GetComponent<PlayerMove>().SelectedClick();
            unit.BeginTurn();
            
            
           
            
            //Debug.Log(turnTeam.Peek().name);
           
            
        }
    }


   public static void EndTurn()
    {
       
        TacticsMove unit = turnTeam.Dequeue();
        Debug.Log(unit.name);
        if(endedTurn == true)
        {

            
            foreach ( TacticsMove u in turnTeam)
            {
                
                u.EndTurn();
               
               
            }
            
            endedTurn = false;
           
        }
        unit.EndTurn();

        if (unit.currentlySelected == true)
        {
            unit.currentlySelected = false;
            unit.GetComponent<PlayerMove>().SelectedClick();
        }
            


        if (turnTeam.Count > 0)
        {
            
            StartTurn();
        }
        else
        {
            
            string team = turnKey.Dequeue();
            turnKey.Enqueue(team);
            InitTeamTurnQueue();
        }

    }
            
               
                
            
           
            

            


    public static void AddUnit(TacticsMove unit)
    {
        List<TacticsMove> list;

        if(!units.ContainsKey(unit.tag))
        {   
            list = new List<TacticsMove>();
            units[unit.tag] = list;
            

            if (!turnKey.Contains(unit.tag))
            {
               
                turnKey.Enqueue(unit.tag);
            }
        }
        else
        {
            list = units[unit.tag];
            
        }

        list.Add(unit);
    }

    
}
