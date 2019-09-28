using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarBalao : MonoBehaviour
{
    public GameObject BalaoPrefab;
    public float TempoReaparecer = 1.0f;
   // public string NomeBalao

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OndaBalao());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AparecerBalao()
    {
        GameObject Balao = Instantiate(BalaoPrefab) as GameObject;
        Balao.transform.position = new Vector3(0,0,0);
        Balao.transform.parent = gameObject.transform;
        //Balao.name = "teste";
    }

    IEnumerator OndaBalao()
    {
        while (true)
        {
            yield return new WaitForSeconds(TempoReaparecer);
            AparecerBalao();
        }
    }
}
