using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    public float Velocidade = 500.0f;
    private Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.GetComponent<Rigidbody2D>();
        Rigidbody.velocity = new Vector2(0, Velocidade);

        GetComponent<Animator>().SetBool("PopBalloon", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
