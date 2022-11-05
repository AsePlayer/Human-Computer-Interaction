using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// EvaluatePosition Script - by Team 9 - Andrew Esch, Ryan Scott, Diego Guerra
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class EvaluatePosition : MonoBehaviour
{
    public Button btn, challengeBtn;
    public Text objectPositionsX;
    public Text objectPositionsY;
    public Text objectPositionsZ;
    public Text challenge;
    public Text numChallenges;

    private string randomObject1;
    private string randomObject2;
    private string randomPosition;

    private float delta, chDelta;
    private string relation;
    private float numCompleted = 0;

    
    void Start()
    {
        // Main Button
        btn.onClick.AddListener(TaskOnClick);

        // New Challenge Button
        challengeBtn.onClick.AddListener(TaskChallengeClick);

        // Generate Relative Positions
        objectPositionsX.text = "X: ";
        objectPositionsY.text = "Y: ";
        objectPositionsZ.text = "Z: ";

        // New Completed Challenges Text
        numChallenges.text = "Challenges Completed: " + numCompleted.ToString();

        // Generate New Challenge
        GenerateChallenge();
    }

    private void Update()
    {
        
    }

    void TaskOnClick()
    {
        objectPositionsX.text = "X: " + LogicalExpression("x", "Cube", "Sphere") + " AND " + LogicalExpression("x", "Sphere", "Cylinder");
        objectPositionsY.text = "Y: " + LogicalExpression("y", "Cube", "Sphere") + " AND " + LogicalExpression("y", "Sphere", "Cylinder");
        objectPositionsZ.text = "Z: " + LogicalExpression("z", "Cube", "Sphere") + " AND " + LogicalExpression("z", "Sphere", "Cylinder");
        
        if (VerifyPositions())
        {
            numCompleted++;
            numChallenges.text = "Challenges Completed: " + numCompleted.ToString();
            GenerateChallenge();
        }
    }

    void TaskChallengeClick()
    {
        GenerateChallenge();
    }

    Vector3 getObjPos(string obj)
    {
        GameObject theObj = GameObject.Find(obj);
        return theObj.GetComponent<Transform>().position;
    }
  
    string LogicalExpression(string axis, string obj1, string obj2)
    {
        Vector3 obj1Pos = getObjPos(obj1);
        Vector3 obj2Pos = getObjPos(obj2);
        
        switch (axis)
        {
            case "x":
                delta = obj1Pos.x - obj2Pos.x;
                relation = " more then ";
                break;
            case "y":
                delta = obj1Pos.y - obj2Pos.y;
                relation = " on top of ";
                break;
            case "z":
                delta = obj2Pos.z - obj1Pos.z;
                relation = " in front of ";
                break;
        }

        if (delta > 0f)
            return obj1 + relation + obj2;
        else
            return obj2 + relation + obj1;
    }
    void GenerateChallenge()
    {
        List<string> objNames = new List<string>();
        List<string> positions = new List<string>();


        objNames.Add("Cube");
        objNames.Add("Sphere");
        objNames.Add("Cylinder");

        positions.Add("more then");
        positions.Add("on top of");
        positions.Add("in front of");

        //Select two random objects
        randomObject1 = objNames[Random.Range(0, objNames.Count)];
        randomObject2 = objNames[Random.Range(0, objNames.Count)];
        while (randomObject1 == randomObject2) randomObject2 = objNames[Random.Range(0, objNames.Count)];

        randomPosition = positions[Random.Range(0, positions.Count)];

        challenge.text = "Challenge: " + randomObject1 + " " + randomPosition + " " + randomObject2;

    }

    bool VerifyPositions()
    {
        // Your code for the class activity goes here

        // Define Challenge Variables
        Vector3 newObj1Pos = getObjPos(randomObject1);
        Vector3 newObj2Pos = getObjPos(randomObject2);
        bool complete = false;

        // Determine type of position, get challenge delta value
        switch (randomPosition)
        {
            case "more then":
                chDelta = newObj1Pos.x - newObj2Pos.x;
                break;
            case "on top of":
                chDelta = newObj1Pos.y - newObj2Pos.y;
                break;
            case "in front of":
                chDelta = newObj1Pos.z - newObj2Pos.z;
                break;
        }

        // Determine if challenge is complete; Ternary operators!
        return(chDelta > 0f ? complete = true : complete = false);
    }
}
