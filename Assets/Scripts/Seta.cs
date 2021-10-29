using UnityEngine;

public class Seta : MonoBehaviour
{
    string premio = "";
    AudioSource tekTekSom;

    private void Start()
    {
        tekTekSom = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
