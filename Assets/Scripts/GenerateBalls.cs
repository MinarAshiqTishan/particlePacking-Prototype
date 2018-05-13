using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBalls : MonoBehaviour {

    public GameObject balls;
    public GameObject panel;

    public PlayerController pc;

    public InputField fieldScaleX;
    public InputField fieldScaleY;
    public InputField fieldScaleZ;

    public InputField fieldRotX;
    public InputField fieldRotY;
    public InputField fieldRotZ;

    [SerializeField]
    private Vector3 ballPosData { get; set; }

    [SerializeField]
    private Quaternion ballRotData { get; set; }



    private float maxYPos = 6.0f;
    private float minYPos = 5.5f;

    private float maxXPos = -2.5f;
    private float minXPos = 2.5f;

    private float maxZPos = -2.5f;
    private float minZPos = 2.5f;

    private int maxBalls = 200;


    public float ScaleX = 1.0f;
    public float ScaleY = 1.0f;
    public float ScaleZ = 1.0f;

    public float RotX = 1.0f;
    public float RotY = 1.0f;
    public float RotZ = 1.0f;


    private bool toggleSpawn = false;

    // Use this for initialization

    Coroutine co;

    string objFlag = "balls";

    void Start () {
        fieldScaleX.text = "1.0";
        fieldScaleY.text = "1.0";
        fieldScaleZ.text = "1.0";

        fieldRotX.text = "1.0";
        fieldRotY.text = "1.0";
        fieldRotZ.text = "1.0";

    }

    // Update is called once per frame
    void Update () {
    
	}

    public void SetObject(GameObject ballObject)
    {
        balls = ballObject;
    }

   


    public void CreateBalls()
    {
        objFlag = "balls";

        var x = fieldScaleX.GetComponent<InputField>().text;
        var y = fieldScaleY.GetComponent<InputField>().text;
        var z = fieldScaleZ.GetComponent<InputField>().text;

        ScaleX = float.Parse(x);
        ScaleY = float.Parse(y);
        ScaleZ = float.Parse(z);



        var rx = fieldRotX.GetComponent<InputField>().text;
        var ry = fieldRotY.GetComponent<InputField>().text;
        var rz = fieldRotZ.GetComponent<InputField>().text;


        RotX = float.Parse(rx);
        RotY = float.Parse(ry);
        RotZ = float.Parse(rz);

        float biggest = ScaleX;

        if (biggest < ScaleY)
        {
            biggest = ScaleY;
        }

        if (biggest < ScaleZ)
        {
            biggest = ScaleZ;
        }



        balls = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        balls.transform.position = new Vector3(0f, 6f, 0f);
        balls.transform.position = new Vector3(0f, 6f, 0f);
        balls.transform.localScale = new Vector3(ScaleX, ScaleY, ScaleZ);
        balls.transform.localRotation = Quaternion.Euler(RotX, RotY, RotZ);
        balls.AddComponent<Rigidbody>();
        balls.AddComponent<SphereCollider>();
      //  balls.GetComponent<SphereCollider>().radius = biggest / 2f;

        balls.tag = "Player";
        balls.AddComponent<PlayerController>();
/*
        var scriptAsset = AssetDatabase.FindAssets("PlayerController");
        
        if (scriptAsset.Length > 0)
        {
            balls.AddComponent(Type.GetType("PlayerController"));
        }
        else
        {
            Debug.Log("PlayerController.cs" + " not supported!");
        }
        */
        SetObject(balls);
    }


    public void CreateCapsule()
    {
        objFlag = "capsule";

        var x = fieldScaleX.GetComponent<InputField>().text;
        var y = fieldScaleY.GetComponent<InputField>().text;
        var z = fieldScaleZ.GetComponent<InputField>().text;

        ScaleX = float.Parse(x);
        ScaleY = float.Parse(y);
        ScaleZ = float.Parse(z);

        float biggest = ScaleX;

        if(biggest < ScaleY)
        {
            biggest = ScaleY;
        }

        if(biggest < ScaleZ)
        {
            biggest = ScaleZ;
        }

        var rx = fieldRotX.GetComponent<InputField>().text;
        var ry = fieldRotY.GetComponent<InputField>().text;
        var rz = fieldRotZ.GetComponent<InputField>().text;


        RotX = float.Parse(rx);
        RotY = float.Parse(ry);
        RotZ = float.Parse(rz);


        balls = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        balls.transform.position = new Vector3(0f, 6f, 0f);
        balls.transform.localScale = new Vector3(ScaleX,ScaleY, ScaleZ);
        balls.transform.localRotation = Quaternion.Euler(RotX,RotY, RotZ);

        balls.AddComponent<Rigidbody>();
        balls.AddComponent<CapsuleCollider>();

        balls.GetComponent<CapsuleCollider>().radius = biggest/2;
       
        balls.tag = "Player";
        balls.AddComponent<PlayerController>();
        /*   var scriptAsset = AssetDatabase.FindAssets("PlayerController");
           if (scriptAsset.Length > 0)
           {
               balls.AddComponent(Type.GetType("PlayerController"));
           }
           else
           {
               Debug.Log("PlayerController.cs" + " not supported!");
           }
   */
        SetObject(balls);
    }


    public void CreateCube()
    {
        objFlag = "cube";

        var x = fieldScaleX.GetComponent<InputField>().text;
        var y = fieldScaleY.GetComponent<InputField>().text;
        var z = fieldScaleZ.GetComponent<InputField>().text;

        ScaleX = float.Parse(x);
        ScaleY = float.Parse(y);
        ScaleZ = float.Parse(z);



        var rx = fieldRotX.GetComponent<InputField>().text;
        var ry = fieldRotY.GetComponent<InputField>().text;
        var rz = fieldRotZ.GetComponent<InputField>().text;


        RotX = float.Parse(rx);
        RotY = float.Parse(ry);
        RotZ = float.Parse(rz);


        
      

        balls = GameObject.CreatePrimitive(PrimitiveType.Cube) ;
        balls.transform.position = new Vector3(0f, 6f, 0f);
        balls.transform.position = new Vector3(0f, 6f, 0f);
        balls.transform.localScale = new Vector3(ScaleX, ScaleY, ScaleZ);
        balls.transform.localRotation = Quaternion.Euler(RotX, RotY, RotZ);
        balls.AddComponent<Rigidbody>();
        balls.AddComponent<BoxCollider>();
        balls.GetComponent<BoxCollider>().size.Set(  ScaleX,ScaleY,ScaleZ );
       
        balls.tag = "Player";
         balls.AddComponent<PlayerController>();
        /*
                var scriptAsset = AssetDatabase.FindAssets("PlayerController");
                if (scriptAsset.Length > 0)
                {
                    balls.AddComponent(Type.GetType("PlayerController"));
                }
                else
                {
                    Debug.Log("PlayerController.cs" + " not supported!");
                }
                */
        SetObject(balls);
    }

    public void StartSpawn()
    {

        if(objFlag == "balls")
        {
            CreateBalls();
        }
        else if(objFlag == "capsule")
        {
            CreateCapsule();
        }
        else
        {
            CreateCube();
        }

        if (toggleSpawn == false)
        {
           
            co = StartCoroutine(Spawn());
            toggleSpawn = true;
        }
        else
        {
            StopCoroutine(co);
            toggleSpawn = false;
        }
        
    }
    
    public void ScaleBall(ref GameObject ball)
    {
        /*
        
      */
        var ballScale = new Vector3(ScaleX,
            ScaleY, ScaleZ);

        ball.transform.localScale = ballScale;
    }


    public void RotBall(ref GameObject ball)
    {

        /*
    
     */

        var ballRot = Quaternion.Euler(RotX,
            RotY, RotZ);

        ball.transform.localRotation = ballRot;
    }


    IEnumerator Spawn()
    {
        for (int i = 0; i < maxBalls; i++)
        {
            yield return new WaitForSeconds(0.75f);
            var ballPos = new Vector3 (UnityEngine.Random.Range(minXPos, maxXPos), 
                UnityEngine.Random.Range(minYPos, maxYPos), UnityEngine.Random.Range(minZPos, maxZPos));
          
            if(balls == null)
            {
                StartSpawn();
            }
            GameObject ball = Instantiate(balls);

            ScaleBall(ref ball);
            RotBall(ref ball);
 
            
            ball.transform.position = ballPos;
         
        }
    }

   

    public void GeneratePositions()
    {
        GameObject[] remainingBalls;
        List<Vector3> positions  =  new List<Vector3>();
        remainingBalls = GameObject.FindGameObjectsWithTag("Player");

        foreach (var item in remainingBalls)
        {
            ballPosData = item.transform.position;
            positions.Add(ballPosData);
               
        }

        using(TextWriter writer = new StreamWriter(@"./postions.txt"))
        {
            foreach (var item in positions)
            {
                writer.WriteLine(item);
            }
        }

        panel.gameObject.SetActive ( true);
    }

    public void GenerateRotations()
    {
        GameObject[] remainingBalls;
        List<Quaternion> rotations = new List<Quaternion>();
        remainingBalls = GameObject.FindGameObjectsWithTag("Player");

        foreach (var item in remainingBalls)
        {
            ballRotData = item.transform.rotation;
            rotations.Add(ballRotData);

        }

        using (TextWriter writer = new StreamWriter(@"./rotations.txt"))
        {
            foreach (var item in rotations)
            {
                writer.WriteLine(item);
            }
        }

        panel.gameObject.SetActive(true);
    }
}
