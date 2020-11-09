using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 6;
    private Rigidbody rigid;
    private Camera cam;
    [SerializeField]
    private Vector3 velocity;
    public bool nearNpc;

    private QuestInfo questInfo;
    [SerializeField]
    private GameObject questWindow;
    [SerializeField]
    private Text questTitle;
    [SerializeField]
    private Text questDescription;
    [SerializeField]
    private Text goal;
    [SerializeField]
    private Text currentAmmount;
    [SerializeField]
    private Text reward;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * speed;

        if (nearNpc)
        {
            Debug.Log("in range");
            if (Input.GetKeyDown(KeyCode.E))
            {
                questWindow.SetActive(true);
                questTitle.text = questInfo.questName;
                questDescription.text = questInfo.questDescription;
                goal.text = "Goal: " + questInfo.goal.ToString();
                currentAmmount.text = "Progress: " + questInfo.currentAmmount.ToString();
                reward.text = "Gold reward: " + questInfo.reward.ToString();
            }
        }
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + velocity * Time.fixedDeltaTime);
    }
}
