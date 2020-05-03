using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour
{
    //velocidade do balão
    public float Velocidade = 100.0f;
    private Rigidbody2D Rigidbody;
    public float TempoAnimacao = 0.8f;


    public AudioClip MusicClip;
    public AudioSource MusicSource;


    // Start is called before the first frame update
    void Start()
    {

        if (MostrarDica.FinalizouJogo)
        {
            MusicSource = this.GetComponent<AudioSource>();
            MusicSource.clip = MusicClip;

            Rigidbody = this.GetComponent<Rigidbody2D>();
            //forçando a velocidade do balão
            Rigidbody.velocity = new Vector2(0, Velocidade);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //se o balão passar da tela, destruo ele
        if(transform.position.y >= 460)
        {
            Destroy(this.gameObject);
        }
    }

    public void PocouBalao()
    {
        MusicSource.Play();
        StartCoroutine(TempodaAnimacao());
        
    }

    IEnumerator TempodaAnimacao()
    {
        while (true)
        {
            yield return new WaitForSeconds(TempoAnimacao);
            GetComponent<Animator>().SetBool("PopBalloon", true);
            yield return new WaitForSeconds(0.3f);
            yield return new WaitForSeconds(TempoAnimacao);
            Destroy(this.gameObject);
        }
    }
}
