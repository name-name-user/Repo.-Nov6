using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    public class SimpleGameManager : MonoBehaviour
{
    void Awake()
    private bool quest1;
    private bool quest2;
    private bool quest3;
    {
        if (instance = null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
}
        else
        {
            Destroy(gameObject);
        }
    }
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
                SimpleGameManager.instance = go.Addcomponent<SimpleGameManager>();
                DontDestroyOnLoad(go);
            }
        }
        return SimpleGameManager.instance;

  
public void FinishQuest(string quest)
{
    {
        if (quest == "quest1")
        {
            quest1 = true;
        }
    }
}
{

    public float speed;
    public Text countText;
    public winText

    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "count: " + count.ToString();
        FindObjectOfType(count >= 12)
            {
            winText.text = "you win!"
        }
    }
}

