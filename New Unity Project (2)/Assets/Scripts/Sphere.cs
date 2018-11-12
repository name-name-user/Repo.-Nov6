using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
  
{
    // Create an SimpleGameManager variable
    SimpleGameManager GM;

    // On Awake, set the variable to our SimpleGameManager.Instance
    // (Note the capital 'I')
    void Awake()
    {
        GM = SimpleGameManager.Instance;
    }
    public float speed;
    public Text Quest1Text;
    public string winText;

    private Rigidbody Rigidbody;
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
        if (other.gameObject.CompareTag("Pick Up1") || other.gameObject.CompareTag("Pick Up2") || other.gameObject.CompareTag("Pick Up3"))
        {
            other.gameObject.SetActive(false);
            GM.FinishQuest(other.gameObject.tag);
            if (GM.AreQuestsFinished())
            { 
                SetQuest1Text
            }
        }
    }

    void SetQuest1Text()
    {
        Quest1Text.text = "count: " + GM.count.ToString();
       
    }
}

