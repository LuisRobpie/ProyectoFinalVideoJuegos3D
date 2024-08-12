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

        if (Input.GetButtonDown("Fire1") && Locked == false)
        {
            angle = 100;
            direction = Vector3.up;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" & amKeys.Equals("1"))
        {
            Locked = false;
            collectibleManager.UpdateTextbox(Key, 0);
            
        }
    }

}
