using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGameManager : MonoBehaviour
{
    // Class Variables and Properties
    public bool Quest1 = false;
    public bool Quest2 = false;
    public bool Quest3 = false;
    public int count = 0;
    private static SimpleGameManager instance = null;
    public static SimpleGameManager Instance
    {
        get
        {
            if (SimpleGameManager.instance == null)
            {
                SimpleGameManager.instance = FindObjectOfType<SimpleGameManager>();
                if (SimpleGameManager.instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SimpleGameManager";
                    SimpleGameManager.instance = go.AddComponent<SimpleGameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return SimpleGameManager.instance;
        }
    }

    // Class Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FinishQuest(string questName)
    {
        Debug.Log("Handling Quest for " + questName);
        // See Assets/Easy FPS/Scripts/BulletScript.cs to see
        // what tags are in use!
        switch (questName)
        {
            case "Pick Up1":
                Quest1 = true;
                count++;
                break;
            case "Pick Up2":
                Quest2 = true;
                count++;
                break;
            case "Pick Up3":
                Quest3 = true;
                count++;
                break;
            default:
                break;
        }

        // Open the gate if all quests are complete!
        if (AreQuestsFinished()) OpenTheGate();
    }
    public bool AreQuestsFinished()
    {
        Debug.Log("Are Quests Finished? " + (Quest1 && Quest2 && Quest3));
        return count == 3;
    }
    void OpenTheGate()
    {
        // Open the gates in 2s
        GameObject[] gates;
        gates = GameObject.FindGameObjectsWithTag("EndWall");
        Debug.Log("Got " + gates.Length + " gates");
        foreach (GameObject gate in gates)
        {
            Destroy(gate, 2.0f);
        }
    }
}
