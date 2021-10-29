using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roleta : MonoBehaviour
{
    [SerializeField] float velocidadeMaxima = 360f;
    [SerializeField] Button botaoParar;
    [SerializeField] TextMeshProUGUI textoBotaoParar;
    [SerializeField] Image premio;
    [SerializeField] GameObject backgroundPremio;
    [SerializeField] AudioSource caixaDeMusica;
    [SerializeField] Sprite[] premios;

    int fatorDeAceleracao = 500;
    float offSet = 100f;
    float grausParaGirar = 0;
    bool girar = false;

    private void Start()
    {
        GirarRoleta();
    }

    void Update()
    {
        if (girar)
        {
            grausParaGirar = grausParaGirar >= velocidadeMaxima ? velocidadeMaxima : grausParaGirar + (fatorDeAceleracao * Time.deltaTime);
            MecanicaRoleta();
        }
        else if (grausParaGirar != 0)
        {
            grausParaGirar = grausParaGirar - (offSet * Time.deltaTime);

            if (grausParaGirar <= 0)
            {
                grausParaGirar = 0;
                MostrarPremio();
            }

            MecanicaRoleta();
        }
    }

    public void JogarNovamente()
    {
        backgroundPremio.SetActive(false);
        GirarRoleta();
    }

    public void GirarRoleta()
    {
        girar = true;
        caixaDeMusica.enabled = true;

        StartCoroutine(HabilitarBotaoDeParar());
    }

    public void PararRoleta()
    {
        float variacaoDeParada = Random.Range(50, 151);

        offSet = 100f * (variacaoDeParada / 100);
        girar = false;
        botaoParar.interactable = false;

    }

    IEnumerator HabilitarBotaoDeParar()
    {
        textoBotaoParar.text = "AGUARDE...";
        botaoParar.interactable = false;

        yield return new WaitForSeconds(1);

        textoBotaoParar.text = "PARAR";
        botaoParar.interactable = true;
    }

    void MecanicaRoleta()
    {
        transform.Rotate(0, 0, grausParaGirar * Time.deltaTime);
    }

    void MostrarPremio()
    {
        string premioSorteado = FindObjectOfType<Seta>().PegarPremio();

        caixaDeMusica.enabled = false;

        switch (premioSorteado)
        {
            case "Collider01":
                premio.sprite = premios[0];
                break;
            case "Collider02":
                premio.sprite = premios[1];
                break;
            case "Collider03":
                premio.sprite = premios[2];
                break;
            case "Collider04":
                premio.sprite = premios[3];
                break;
            case "Collider05":
                premio.sprite = premios[4];
                break;
            case "Collider06":
                premio.sprite = premios[5];
                break;
            case "Collider07":
                premio.sprite = premios[6];
                break;
            case "Collider08":
                premio.sprite = premios[7];
                break;
            case "Collider09":
                premio.sprite = premios[8];
                break;
            case "Collider10":
                premio.sprite = premios[9];
                break;
            case "Collider11":
                premio.sprite = premios[10];
                break;
            case "Collider12":
                premio.sprite = premios[11];
                break;
            default:
                Debug.Log("SEM PRÊMIO");
                break;
        }

        backgroundPremio.SetActive(true);
    }
}
