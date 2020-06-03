using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MostrarObjeto : MonoBehaviour
{
    public GameObject ShadowBoat, ShadowTent, ShadowCarousel, ShadowCastle,  ShadowFerrisWheel, ShadowCoaster;

    public static List<string> ListaObjects = new List<string>(); //Lista de objetos
    public string FindObjects;

    public int SorteioDica;

    public Vector3 Position;

    public Image ColoredBoat;
    public Image ColoredTent;
    public Image ColoredCarousel;   
    public Image ColoredCastle;
    public Image ColoredFerrisWheel;
    public Image ColoredCoaster;

    private bool MatchingBoat = false;
    private bool MatchingTent = false;
    private bool MatchingCarousel = false;
    private bool MatchingCastle = false;
    private bool MatchingFerrisWheel = false;
    private bool MatchingCoaster = false;

    private bool Encontrou = false;

    public static bool FinalizouJogo;



    // Start is called before the first frame update
    void Start()
    {
        IniciarVariaveis();

        AdicionarObjetoLista();

        //Enquanto houver objeto na lista
        if (ListaObjects.Count > 0)
            SorteioDica = Random.Range(0, ListaObjects.Count - 1); //Sorteie um objeto

        //Pegando o nome do objeto sorteado
        FindObjects = ListaObjects[SorteioDica];

        //Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando
        ListaObjects.RemoveAt(SorteioDica);

        PosicaoInicial();

        HabilitandoObjeto(FindObjects);

    }

        // Update is called once per frame
    void Update()
    {

        if (Encontrou)
        {
            if (ListaObjects.Count > 0)
            {
                SorteioDica = Random.Range(0, ListaObjects.Count - 1); //Sorteie um personagem
                //Pegando o nome do personagem sorteado
                FindObjects = ListaObjects[SorteioDica];

                //Removendo o Personagem sorteado da lista, para que ele não seja desabilitado no próximo comando
                ListaObjects.RemoveAt(SorteioDica);

                HabilitandoObjeto(FindObjects);

                Encontrou = false;
            }
        }

        if ((MatchingBoat) && (MatchingTent) && (MatchingCarousel) && (MatchingCastle) && (MatchingFerrisWheel) && (MatchingCoaster) && (!FinalizouJogo))
        {
            FinalizouJogo = true;
        }

    }

        public void DragObjects(string FindObjects) //fazendo os objetos se mexerem, de acordo com o mouse
    {
        if (FindObjects == "ColoredBoat")
        {
            if (!MatchingBoat) //se ainda não encontrou esse objeto
            {
                ColoredBoat.transform.position = Input.mousePosition;
            }
        }
        else if (FindObjects == "ColoredTent")
        {
            if(!MatchingTent)
            {
                ColoredTent.transform.position = Input.mousePosition;
            }
        }
        else if (FindObjects == "ColoredCarousel")
        {
            if (!MatchingCarousel)
            {
                ColoredCarousel.transform.position = Input.mousePosition;
            }
        }
        else if (FindObjects == "ColoredCastle")
        {
            if (!MatchingCastle)
            {
                ColoredCastle.transform.position = Input.mousePosition;
            }
        }
        else if (FindObjects == "ColoredFerrisWheel")
        {
            if (!MatchingFerrisWheel)
            {
                ColoredFerrisWheel.transform.position = Input.mousePosition;
            }
        }
        else if (FindObjects == "ColoredCoaster")
        {
            if (!MatchingCoaster)
            {
                ColoredCoaster.transform.position = Input.mousePosition;
            }
        }
    }

    public void DropObject(string FindObjects)
    {
        if (FindObjects == "ColoredBoat")
        {
            float Distance = Vector3.Distance(ColoredBoat.transform.position, ShadowBoat.transform.position); //pegando a distância entre o objeto colorido e a sombra dele
            if (Distance < 50)
            {
                ColoredBoat.transform.position = ShadowBoat.transform.position; //colocando o objeto colorido em cima da sombra
                MatchingBoat = true;
                Encontrou = true;
            }
            else
            {
                ColoredBoat.transform.localPosition = Position; //volta para a posição inicial
            }
        }
        else if (FindObjects == "ColoredTent")
        {
            float Distance = Vector3.Distance(ColoredTent.transform.position, ShadowTent.transform.position);
            if (Distance < 50)
            {
                ColoredTent.transform.position = ShadowTent.transform.position;
                MatchingTent = true;
                Encontrou = true;
            }
            else
            {
                ColoredTent.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCarousel")
        {
            float Distance = Vector3.Distance(ColoredCarousel.transform.position, ShadowCarousel.transform.position);
            if (Distance < 50)
            {
                ColoredCarousel.transform.position = ShadowCarousel.transform.position;
                MatchingCarousel = true;
                Encontrou = true;
            }
            else
            {
                ColoredCarousel.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCastle")
        {
            float Distance = Vector3.Distance(ColoredCastle.transform.position, ShadowCastle.transform.position);
            if (Distance < 50)
            {
                ColoredCastle.transform.position = ShadowCastle.transform.position;
                MatchingCastle = true;
                Encontrou = true;
            }
            else
            {
                ColoredCastle.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredFerrisWheel")
        {
            float Distance = Vector3.Distance(ColoredFerrisWheel.transform.position, ShadowFerrisWheel.transform.position);
            if (Distance < 50)
            {
                ColoredFerrisWheel.transform.position = ShadowFerrisWheel.transform.position;
                MatchingFerrisWheel = true;
                Encontrou = true;
            }
            else
            {
                ColoredFerrisWheel.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCoaster")
        {
            float Distance = Vector3.Distance(ColoredCoaster.transform.position, ShadowCoaster.transform.position);
            if (Distance < 50)
            {
                ColoredCoaster.transform.position = ShadowCoaster.transform.position;
                MatchingCoaster = true;
                Encontrou = true;
            }
            else
            {
                ColoredCoaster.transform.localPosition = Position;
            }
        }
    }

    private void IniciarVariaveis()
    {
        ListaObjects.Clear();
        FinalizouJogo = false;
    }


    private void AdicionarObjetoLista()
    {
        ListaObjects.Add("ColoredBoat");
        ListaObjects.Add("ColoredTent");
        ListaObjects.Add("ColoredCarousel");
        ListaObjects.Add("ColoredCastle");
        ListaObjects.Add("ColoredFerrisWheel");
        ListaObjects.Add("ColoredCoaster");
    }

    private void PosicaoInicial()
    {  
        Position = new Vector3(-149.5f, -37.145f, 0);
    }

    private void HabilitandoObjeto(string FindObjects)
    {
        if (FindObjects == "ColoredBoat")
        {
            if (ColoredBoat != null)
            {
                ColoredBoat.enabled = true;
                ColoredBoat.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredTent")
        {
            if (ColoredTent != null)
            {
                ColoredTent.enabled = true;
                ColoredTent.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCarousel")
        {
            if (ColoredCarousel != null)
            {
                ColoredCarousel.enabled = true;
                ColoredCarousel.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCastle")
        {
            if (ColoredCastle != null)
            {
                ColoredCastle.enabled = true;
                ColoredCastle.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredFerrisWheel")
        {
            if (ColoredFerrisWheel != null)
            {
                ColoredFerrisWheel.enabled = true;
                ColoredFerrisWheel.transform.localPosition = Position;
            }
        }
        else if (FindObjects == "ColoredCoaster")
        {
            if (ColoredCoaster != null)
            {
                ColoredCoaster.enabled = true;
                ColoredCoaster.transform.localPosition = Position;
            }
        }

    }
    
}
