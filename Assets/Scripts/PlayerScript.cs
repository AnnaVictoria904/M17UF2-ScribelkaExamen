using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator anim;
    private float horizontalInput;
    
    [Header("Animations")]
    [SerializeField] private KeyCode hurt;
    [SerializeField] private KeyCode die;
    [SerializeField] private KeyCode attack;

    [Header("Teleport")]
    [SerializeField] private float distanceX;
    [SerializeField] private float distanceY;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(hurt))
        {
            anim.SetTrigger("hurt");
        }
        if (Input.GetKeyDown(attack))
        {
            anim.SetTrigger("attack");
        }
        if (Input.GetKeyDown(die))
        {
            anim.SetTrigger("die");
        }
    }
    private void Teleport()
    {
        Vector3 destination;

        if (transform.localScale == Vector3.one)
            destination = transform.position + new Vector3(Mathf.Sign(horizontalInput) * distanceX, distanceY, 0);
        else
            destination = transform.position + new Vector3(Mathf.Sign(horizontalInput) * -distanceX, distanceY, 0);

        transform.position = destination;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 destination = transform.position + new Vector3(Mathf.Sign(horizontalInput) * distanceX, distanceY, 0);
        Gizmos.DrawLine(transform.position, destination);
    }
}
