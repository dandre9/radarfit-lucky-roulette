using UnityEngine;

public class Seta : MonoBehaviour
{
    string premio = "";
    AudioSource tekTekSom;

    private void Start()
    {
        // Atribui à variável tekTekSom o componente AudioSource deste objeto
        tekTekSom = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cada vez que o collider de prêmio variar a variável prêmio é atualizada e toca o tekTekSom
        if (other.tag == "PremioRoleta" && other.name != premio)
        {
            tekTekSom.Play();
            premio = other.name;
        }
    }

    public string PegarPremio()
    {
        return premio;
    }
}
