//Created by Nathan Stowe & BlankSpace Studios
//Open-source license, use however you wish! :]

using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
    //these are the players.
    //TODO: Create player1 and player2 classes that hold models, moves, animations...etc, spawn these instead of test cubes
    GameObject player1;
    GameObject player2;

    
    //player move speeds
    float player1moveSpeed = 0.5f;
    float player2moveSpeed = 0.5f;

    //player jump speeds
    float player1jumpSpeed = 40.0f;
    float player2jumpSpeed = 40.0f;

    //player velocity
    Vector3 player1Veloc;
    Vector3 player2Veloc;

    //player acceleration
    Vector3 player1Accel;
    Vector3 player2Accel;

    //controller deadzones(1 for first player, 2 for second player)
    float deadZone1 = 0.6f;
    float deadZone2 = 0.6f;
    

    // Use this for initialization
    void Start () {
        //spawns players
        //TODO: Create player1 and player2 classes that hold models, moves, animations...etc, spawn these instead of test cubes
        player1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        player2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //initialize starting player positions
        player1.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        player1.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        player1.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        player1Accel = new Vector3(0.0f, 0.0f, 0.0f);
        player1Veloc = new Vector3(0.0f, 0.0f, 0.0f);

        player2.transform.position = new Vector3(15.0f, 5.0f, 0.0f);
        player2.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        player2.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        player2Accel = new Vector3(0.0f, 0.0f, 0.0f);
        player2Veloc = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update () {
        //note: alot of values use 5.0f, this is half the height of the player, and will need to be replaced with player1.height/2 eventually
        //INPUT CONTROLLER
        //Player1 = XBOX CONTROLLER
        //Player 2 = KEYBOARD
        //LeftstickX1 means left analog stick, x-axis, controller1


        //PLAYER 1
        //ensure player cant fall off map
        if (player1.transform.position.y != 5.0f) //player is at bottom of map
        {
            if (player1.transform.position.y < 5.0f) //player is below bottom of map
            {
                player1Accel.y = 0.0f;
                player1Veloc.y = 0.0f;
                player1.transform.position = new Vector3(player1.transform.position.x, 5.0f, player1.transform.position.z);
            }
            else //player is in air
            {
                player1Accel.y = -9.81f * 15; 
            }
        }
        


        //update veloc based on accel
        player1Veloc += player1Accel * Time.deltaTime; //we use delta time because otherwise it would go 9.81m per FRAME not second when in air

        //move player if they have any velocity
        if (player1Veloc != new Vector3(0.0f, 0.0f, 0.0f))
        {
            player1.transform.position = new Vector3(player1.transform.position.x + player1Veloc.x * Time.deltaTime, player1.transform.position.y + player1Veloc.y * Time.deltaTime, player1.transform.position.z + player1Veloc.z * Time.deltaTime);
        }
        
        //input manager
        if (Input.GetAxis("LeftStickX1") > deadZone1)
        {
            player1.transform.position = new Vector3(player1.transform.position.x + player1moveSpeed, player1.transform.position.y, player1.transform.position.z);
        }
        if (Input.GetAxis("LeftStickX1") < (deadZone1 * -1.0f))
        {
            player1.transform.position = new Vector3(player1.transform.position.x - player1moveSpeed, player1.transform.position.y, player1.transform.position.z);
        }
        if (Input.GetKey(KeyCode.JoystickButton1) /*&& TODO:player is on platform*/)
        {
            player1Veloc = new Vector3(0.0f, player1jumpSpeed, 0.0f);
        }



        //PLAYER 2
        //ensure player cant fall off map
        if (player2.transform.position.y != 5.0f) //player is at bottom of map
        {
            if (player2.transform.position.y < 5.0f) //player is below bottom of map
            {
                player2Accel.y = 0.0f;
                player2Veloc.y = 0.0f;
                player2.transform.position = new Vector3(player2.transform.position.x, 5.0f, player2.transform.position.z);
            }
            else //player is in air
            {
                player2Accel.y = -9.81f * 15;
            }
        }



        //update veloc based on accel
        player2Veloc += player2Accel * Time.deltaTime; //we use delta time because otherwise it would go 9.81m per FRAME not second when in air

        //move player if they have any velocity
        if (player2Veloc != new Vector3(0.0f, 0.0f, 0.0f))
        {
            player2.transform.position = new Vector3(player2.transform.position.x + player2Veloc.x * Time.deltaTime, player2.transform.position.y + player2Veloc.y * Time.deltaTime, player2.transform.position.z + player2Veloc.z * Time.deltaTime);
        }

        //input manager
        if (Input.GetKey(KeyCode.A))
        {
            player2.transform.position = new Vector3(player2.transform.position.x - player2moveSpeed, player2.transform.position.y, player2.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player2.transform.position = new Vector3(player2.transform.position.x + player2moveSpeed, player2.transform.position.y, player2.transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space) /*&& TODO:player is on platform*/)
        {
            player2Veloc = new Vector3(0.0f, player2jumpSpeed, 0.0f);
        }
        

    }
}
