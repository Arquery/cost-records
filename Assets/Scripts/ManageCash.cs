using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageCash : MonoBehaviour
{
    private Text totalCash;
    private Text currentDate;
    
    public InputField entry;
    public InputField egress;

    private float totalF;

    // Start is called before the first frame update
    void Start()
    {
        totalCash = GameObject.Find("Total").GetComponent<Text>();
        currentDate = GameObject.Find("Date").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        currentDate.text = System.DateTime.Now.ToString("MMM, yyyy");
        totalCash.text = PlayerPrefs.GetString("Flow");
        totalF = float.Parse(totalCash.text);
        if (totalF < 0)
        {
            totalCash.color = Color.red;
        }
        else if(totalF > 0)
        {
            totalCash.color = Color.green;
        }
        else
        {
            totalCash.color = Color.black;
        }
    }

    public void EntryCash()
    {
        float entryF = float.Parse(entry.text);
        totalF = totalF + entryF;
        totalCash.text = totalF.ToString("0.00");
        PlayerPrefs.SetString("Flow", totalCash.text);
        entry.text = "";
    }

    public void EgressCash()
    {
        float egressF = float.Parse(egress.text);
        totalF = totalF - egressF;
        totalCash.text = totalF.ToString("0.00");
        PlayerPrefs.SetString("Flow", totalCash.text);
        egress.text = "";
    }
}
