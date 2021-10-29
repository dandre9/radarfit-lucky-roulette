using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roleta : MonoBehaviour
{
    [SerializeField] float velocidadeMaxima = 360f; // Define a velocidade final da roleta (graus por segundo) 
    [SerializeField] int fatorDeAceleracao = 500; // Fator arbitrário que define em quanto a roleta ira acelerar
    [SerializeField] float offSet = 100f; // Variável usada para variar a desaceleração da roleta
    [SerializeField] Button botaoParar;
    [SerializeField] TextMeshProUGUI textoBotaoParar;
    [SerializeField] Image premio;
    [SerializeField] GameObject backgroundPremio;
    [SerializeField] AudioSource caixaDeMusica;
    [SerializeField] Sprite[] premios;

    float grausParaGirar = 0; // Variável que recebe a variação de aceleração e desaceleração
    bool girar = false; // Variável usada como flag para girar ou parar a roleta no Update()

    private void Start()
    {
        // Invoca de início a função que faz girar a roleta
        GirarRoleta();
    }

    void Update()
    {
        if (girar)
        {
            // Incrementa a variável de aceleração até a velocidade máxima
            grausParaGirar = grausParaGirar >= velocidadeMaxima ? velocidadeMaxima : grausParaGirar + (fatorDeAceleracao * Time.deltaTime);
            MotorRoleta();
        }
        // Caso a variável girar for false e grausParaGirar for maior que 0, é para frear a roleta
        else if (grausParaGirar > 0)
        {
            grausParaGirar = grausParaGirar - (offSet * Time.deltaTime);

            if (grausParaGirar <= 0)
            {
                // Garante que aceleração final é 0
                grausParaGirar = 0;
                MostrarPremio();
            }

            MotorRoleta();
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

        StartCoroutine(DesabilitarHabilitarBotaoDeParar());
    }

    public void PararRoleta()
    {
        // Gera valor aleatorio para variar a desaceleração da roleta garantindo aleatoriedade
        float variacaoDeParada = Random.Range(50, 151);

        offSet = variacaoDeParada;
        girar = false;
        botaoParar.interactable = false;

    }

    IEnumerator DesabilitarHabilitarBotaoDeParar()
    {
        textoBotaoParar.text = "AGUARDE...";
        botaoParar.interactable = false;

        yield return new WaitForSeconds(1);

        textoBotaoParar.text = "PARAR";
        botaoParar.interactable = true;
    }

    void MotorRoleta()
    {
        transform.Rotate(0, 0, grausParaGirar * Time.deltaTime);
    }

    void MostrarPremio()
    {
        // Pega da classe Seta o prêmio sorteado
        string premioSorteado = FindObjectOfType<Seta>().PegarPremio();

        caixaDeMusica.enabled = false;

        // Atribui à Image de premiação o sprite do prêmio sorteado
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
