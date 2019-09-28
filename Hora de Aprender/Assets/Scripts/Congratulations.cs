using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    //velocidade do balão
    public float Velocidade = 100.0f;
    private Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.GetComponent<Rigidbody2D>();
        //forçando a velocidade do balão
        Rigidbody.velocity = new Vector2(0, Velocidade);

        PocouBalao("");
        //GetComponent<Animator>().SetBool("PopBalloon", true);
    }

    // Update is called once per frame
    void Update()
    {
        //se o balão passar da tela, destruo ele
        if(transform.position.y >= 480)
        {
            Destroy(this.gameObject);
        }
    }

    public void PocouBalao(string nome)
    {
        GetComponent<Animator>().SetBool("PopBalloon", true);
       // Destroy(this.gameObject);
    }
}
