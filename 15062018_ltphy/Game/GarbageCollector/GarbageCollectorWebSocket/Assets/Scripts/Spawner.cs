using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Use this for initialization
    public ArrayList positionList = new ArrayList();
    public  List<GameObject> goList = new List<GameObject>(5);

    private float timer;
    private int previous;
    private int current;
    private bool[] checkAvailablePosition = new bool[3];
    private int[] carIndex = new int[2];
    public List<GameObject> trashList = new List<GameObject>(1);
    private float garbageTimeRange = 2.5f; //the same for all mode
    public List<GameObject> energyList = new List<GameObject>(0);
    public float delayTimeEnergy; //the same for all mode
    public List<GameObject> GoList 
    {
        get
        {
            return goList;
        }

        set
        {
            goList = value;
        }
    }
    void generateIndexCars(int[] carIndex, int range)
    {
        int firstIndex = Random.Range(0, range);
        int secondIndex = firstIndex;
        do
        {
            firstIndex = Random.Range(0, range);
        } while (firstIndex == secondIndex);
        carIndex[0] = firstIndex;
        carIndex[1] = secondIndex;
       
        //Debug.Log(carIndex[0] + "," + carIndex[1]);
    }
    public void setTimer(float time)
    {
        timer = time;
    }
    void Start () {
        //Debug.Log(ModeStat.DelayTime);
        positionList.Add(-3.5f);
        positionList.Add(0f);
        positionList.Add(3.5f);
        timer = ModeStat.DelayTime; //get delay time from mode stat
        previous = Random.Range(0, 3);
        delayTimeEnergy = Random.Range(8f, 15f);
        current = previous;
        checkAvailablePosition[current] = true;
        Physics2D.IgnoreLayerCollision(8, 9);//ignore the layer f garbage and car enemy
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(8, 10);
    }
	
	// Update is called once per frame
    
	void Update () {
        timer -= Time.deltaTime;
        //find a time that it certainly will not in the same place with other car enemy
        delayTimeEnergy -= Time.deltaTime;
        if (timer <= 0)
        {

            generateIndexCars(carIndex, 5);
            //Debug.Log(carIndex.Length);
            for (int i = 0;i<carIndex.Length;i++)//the index of random objects
            {
                int index = 0;
                for(int j = 0;j<checkAvailablePosition.Length;j++)
                {
                    if (checkAvailablePosition[j] == false) index = j;//get the position of available slot from 0-2
                }
                if (index < -1 || index > 2)
                {
                    Debug.Log("Wrong");
                }
                else
                {
                    Vector3 carPos = new Vector3((float)positionList[index], transform.position.y, transform.position.z);           
                    if (goList[carIndex[i]] != null)//check if the car in the goList is available.
                    {
                        //Debug.Log(carIndex[i]);
                        Instantiate(goList[carIndex[i]], carPos, Quaternion.identity);
                        checkAvailablePosition[index] = true;
                    }
                }
            }
           
            timer = ModeStat.DelayTime;
            previous = current;
            do
            {
                current = Random.Range(0, 3);
            } while (current == previous);
            for (int i = 0; i < checkAvailablePosition.Length; i++)
            {
                checkAvailablePosition[i] = false;
            }
            checkAvailablePosition[current] = true;
            //random a range for garbage spawn
            garbageTimeRange = Random.Range(0f, 0.8f);
        }
        if(timer<=garbageTimeRange)//garbage spawn when in a range of time 0-2.5f
        {
            Vector3 trashPos = new Vector3((float)positionList[Random.Range(0,3)], transform.position.y, transform.position.z);
                //Debug.Log(carIndex[i]);
            Instantiate(trashList[0], trashPos, Quaternion.identity);
            //checkAvailablePosition[index] = true;
            garbageTimeRange = -0.1f;// it will spanw 1 time in a range only
        }
        if (delayTimeEnergy <= 0)
        {
            Vector3 energyPos = new Vector3((float)positionList[Random.Range(0, 3)], transform.position.y, transform.position.z);
            //Debug.Log(carIndex[i]);
            Instantiate(energyList[0], energyPos, Quaternion.identity);
            //checkAvailablePosition[index] = true;
            delayTimeEnergy = Random.Range(8f, 15f);// it will spanw 1 time in a range only
        }
    }
}
