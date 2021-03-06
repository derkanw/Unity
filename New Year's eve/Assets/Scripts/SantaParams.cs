using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SantaParams : MonoBehaviour
{
    public GameObject prefab;
    public float fireSpeed;
    public int hp, level, cost, upgradeCost;
    private bool flag = false;
    private Slider bar;
    private Animator animator;

    void Start()
    {
        bar = gameObject.transform.GetChild(5).transform.GetChild(0).GetComponent<Slider>();
        bar.maxValue = hp;
        bar.value = hp;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!flag && Physics.Raycast(transform.position, new Vector3(1, 0, 0), 10f))
        {
            flag = true;
            StartCoroutine(InitGift());
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "MaleFreeSimpleMovement1(Clone)")
        {
            ChildParams child = collider.gameObject.GetComponent<ChildParams>();
            hp -= child.power;
            bar.value = hp;
            child.dissatisfaction = 0;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
            GameObject.Find("camera").GetComponent<Animator>().SetTrigger("Effect");
        }
    }

    IEnumerator InitGift()
    {
        float speed = 5f, distance = 10f;
        while (Physics.Raycast(transform.position, new Vector3(1, 0, 0), distance))
        {
            animator.SetBool("Throw", true);
            GameObject gift = Instantiate(prefab, new Vector3(transform.position.x , transform.position.y + 1, transform.position.z), Quaternion.identity);
            gift.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * speed;
            yield return new WaitForSeconds(fireSpeed);
            animator.SetBool("Throw", false);
        }
        flag = false;
    }
}
