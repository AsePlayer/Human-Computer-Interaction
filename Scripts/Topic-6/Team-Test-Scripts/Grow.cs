using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grow : MonoBehaviour
{
    // OLD VARIABLES
    // public Text growthInfo, setGoal, treeGrowthInfo, treeWaterGoal;

    // public Slider pillarGrowthSlider;
    // public Slider goalSetterSlider;

    // public Slider treeGrowthSlider;
    // public Slider treeWaterGoalSlider;

    // private GameObject tree;

    // private Vector3 originalTreeScale, originalTreePosition;

    // public ParticleSystem rain;
    // public GameObject cloud;

    // NEW VARIABLES
    public Button runSimulationBtn;
    public GameObject stdevPillar;
    private GameObject stdevPillarZ, stdevPillar1, stdevPillar2, stdevPillar3, stdevPillarNeg1, stdevPillarNeg2, stdevPillarNeg3;
    private Vector3 originalScale, originalPosition;
    public Slider mean, stdev, z_score;
    public Text meanText, stdevText, zScoreText;

    void Start()
    {
        originalPosition = stdevPillar.transform.GetChild(0).position;
        originalScale = stdevPillar.transform.GetChild(0).localScale;
        runSimulationBtn.onClick.AddListener(TasksOnClick);

        generateSTDEVPillars();

        // OLD CODE 

        /*
        capture changes in sliders and scale the objects they affect, accordingly
        stdev.onValueChanged.AddListener(delegate { 
            GrowObject(stdevPillar, originalScale, originalPosition, mean);
            GrowObject(stdevPillar1, originalScale, originalPosition, mean);
            GrowObject(stdevPillar2, originalScale, originalPosition, mean);
            GrowObject(stdevPillar3, originalScale, originalPosition, mean);
            GrowObject(stdevPillarNeg1, originalScale, originalPosition, mean);
            GrowObject(stdevPillarNeg2, originalScale, originalPosition, mean);
            GrowObject(stdevPillarNeg3, originalScale, originalPosition, mean);
        });
        */

        // originalTreePosition = tree.transform.position;
        // originalTreeScale = tree.transform.localScale;

        // treeGrowthSlider.onValueChanged.AddListener(delegate { GrowObject(tree, originalTreeScale, originalTreePosition, treeGrowthSlider); });

        // rain.Stop();
        // cloud.SetActive(false);

    }


    void Update()
    {
        //continuously display the values of each slider

        /* OLD CODE
        growthInfo.text = "Pillar Growth: " + pillarGrowthSlider.value.ToString();
        setGoal.text = "Pillar Growth Goal: " + goalSetterSlider.value.ToString();
        treeGrowthInfo.text = "Tree Growth: " + treeGrowthSlider.value.ToString();
        treeWaterGoal.text = "Water Goal: " + treeWaterGoalSlider.value.ToString();
        */

        // NEW CODE
        meanText.text = "Mean: " + mean.value.ToString();
        stdevText.text = "Standard Deviation: " + stdev.value.ToString();
        zScoreText.text = "Z-Score: " + z_score.value.ToString();
    }

    void generateSTDEVPillars()
    {
        stdevPillar1 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x + 3.5f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillar1.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1 STDEV";
        stdevPillar2 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x + 3.5f*2f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillar2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "2 STDEV";
        stdevPillar3 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x + 3.5f*3f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillar3.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "3 STDEV";
        stdevPillarNeg1 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x - 3.5f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillarNeg1.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-1 STDEV";
        stdevPillarNeg2 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x - 3.5f*2f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillarNeg2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-2 STDEV";
        stdevPillarNeg3 = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x - 3.5f*3f, stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillarNeg3.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-3 STDEV";
    }

    void GrowObject(Transform obj, Vector3 objOriginalScale, Vector3 objOriginalPosition, Slider growthSlider)
    {
        obj.localScale = objOriginalScale + new Vector3(0, growthSlider.value, 0);

        //prevent scaling under ground plane, by moving the object upwards as it scales
        //This is NOT an elegant solution, but a quick fix!! - with some minor side effects
        obj.position = objOriginalPosition + new Vector3(0, growthSlider.value, 0);
    }

    IEnumerator ScaleOverTime(float time, Transform obj, Vector3 objOriginalScale, Vector3 objOriginalPosition, float factor)
    {
        // start rain if the object is tree
        Debug.Log(obj.name);
       
        //NOTE: There is a minor bug, that makes it rain even when the user
        //does not select the tree - FIX IT :)
        // scales an object over time, using values set by the user with the slider

        Vector3 destinationScale = objOriginalScale + new Vector3(0, factor, 0);
        Vector3 destinationPosition = objOriginalPosition + new Vector3(0, factor, 0);

        float currentTime = 0.0f;
        
        do
        {
            obj.localScale = Vector3.Lerp(objOriginalScale, destinationScale, currentTime / time);

            //prevent scaling under ground plane, by moving the object upwards as it scales
            obj.position = Vector3.Lerp(objOriginalPosition, destinationPosition, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    void generateZScorePillar()
    {
        float meanz = mean.value - (Mathf.Abs(z_score.value) * stdev.value);
        if (stdevPillarZ != null)
        {
            Destroy(stdevPillarZ);
        }

        stdevPillarZ = Instantiate(stdevPillar, new Vector3(stdevPillar.transform.position.x + (3.5f*z_score.value), stdevPillar.transform.position.y, stdevPillar.transform.position.z), stdevPillar.transform.rotation);
        stdevPillarZ.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Z-Score\n" + meanz.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillarZ.transform.GetChild(0), originalScale, stdevPillarZ.transform.GetChild(0).position, meanz));
    }

    void TasksOnClick()
    {
        // executed when the "Run Simulation" button is clicked
        float meanv, meanv1, meanv2, meanv3;
        meanv = mean.value;
        meanv1 = meanv - (stdev.value);
        meanv2 = meanv - (2f * stdev.value);
        meanv3 = meanv - (3f * stdev.value);

        StartCoroutine(ScaleOverTime(2, stdevPillar.transform.GetChild(0), originalScale, originalPosition, meanv));
        stdevPillar.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "0 STDEV\n" + meanv.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillar1.transform.GetChild(0), originalScale, stdevPillar1.transform.GetChild(0).position, meanv1));
        stdevPillar1.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "1 STDEV\n" + meanv1.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillar2.transform.GetChild(0), originalScale, stdevPillar2.transform.GetChild(0).position, meanv2));
        stdevPillar2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "2 STDEV\n" + meanv2.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillar3.transform.GetChild(0), originalScale, stdevPillar3.transform.GetChild(0).position, meanv3));
        stdevPillar3.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "3 STDEV\n" + meanv3.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillarNeg1.transform.GetChild(0), originalScale, stdevPillarNeg1.transform.GetChild(0).position, meanv1));
        stdevPillarNeg1.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-1 STDEV\n" + meanv.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillarNeg2.transform.GetChild(0), originalScale, stdevPillarNeg2.transform.GetChild(0).position, meanv2));
        stdevPillarNeg2.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-2 STDEV\n" + meanv2.ToString();
        StartCoroutine(ScaleOverTime(2, stdevPillarNeg3.transform.GetChild(0), originalScale, stdevPillarNeg3.transform.GetChild(0).position, meanv3));
        stdevPillarNeg3.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "-3 STDEV\n" + meanv3.ToString();

        generateZScorePillar();
    }
}
