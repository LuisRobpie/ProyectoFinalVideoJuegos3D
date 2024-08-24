using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLockedController : MonoBehaviour
{

    public float speed;
    public float angle;
    public Vector3 direction;

    public bool Locked;

    CollectibleType Key = CollectibleType.KEY;

    public string amKeys;

    [SerializeField]
    CollectibleManager collectibleManager;

    [SerializeField]
    CollectorController collector;

    void Start()
    {
        angle = transform.eulerAngles.y;

    }

    void Update()
    {
        amKeys = collectibleManager.GetTextbox(Key);
        if (Mathf.Round(transform.eulerAngles.y) != angle)
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            if (gameObject.CompareTag("PuertaFinal"))
            {
                if (Input.GetButtonDown("Fire1") && Locked == true && amKeys.Equals("1") && other.GetComponent<CollectorController>().actualKey == ("Last"))
                {
                    Locked = false;
                    angle = 95;
                    direction = Vector3.up;
                    collector.Decrease(Key, 1);
                    collectibleManager.UpdateTextbox(Key, 0);
                    other.GetComponent<CollectorController>().actualKey = null;
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && Locked == true && amKeys.Equals("1"))
                {
                    Locked = false;
                    angle = 95;
                    direction = Vector3.up;
                    collector.Decrease(Key, 1);
                    collectibleManager.UpdateTextbox(Key, 0);
                    other.GetComponent<CollectorController>().actualKey = null;

                }
            }


        }
    }

}
