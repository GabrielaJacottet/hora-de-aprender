using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarBalao : MonoBehaviour
{
    //public GameObject BalaoPrefab;
    public  GameObject[] BalaoPrefab;
    public float TempoReaparecer = 2.0f;

    private GameObject[] InstanciarBaloes;
    public int QuantidadeRepeticao=0;



    void Start()
    {
        
        
    }

    void Update()
    {
        //StartCoroutine(OndaBalao());
        if ((MostrarDica.FinalizouJogo) || MostrarObjeto.FinalizouJogo )
        {
            while (QuantidadeRepeticao < 4)
            {
                StartCoroutine(OndaBalao());
                QuantidadeRepeticao++;
            }
        }
    }

    private void AparecerBalao()
    {
       // if (MostrarDica.FinalizouJogo)
       // {
           // 
            //{
                InstanciarBaloes = new GameObject[BalaoPrefab.Length];
                for (int i = 0; i < BalaoPrefab.Length; i++)
                {
                    InstanciarBaloes[i] = Instantiate(BalaoPrefab[i]) as GameObject;
                    //GameObject Balao = Instantiate(BalaoPrefab) as GameObject;
                    //Balao.transform.position = new Vector2(Random.Range(0, 800), 0);
                    //Balao.transform.parent = gameObject.transform;

                    InstanciarBaloes[i].transform.position = new Vector2(Random.Range(0, 700), Random.Range(-100, 0));
                    InstanciarBaloes[i].transform.parent = gameObject.transform;

                }
               // QuantidadeRepeticao++;
               
           // }
            //MostrarDica.FinalizouJogo = false;

        //}
    }

    IEnumerator OndaBalao()
    {
       
            yield return new WaitForSeconds(TempoReaparecer);
            AparecerBalao();
           

    }
}
