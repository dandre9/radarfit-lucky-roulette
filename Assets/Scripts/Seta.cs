using UnityEngine;

public class Seta : MonoBehaviour
{
    string premio = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PremioRoleta")
            premio = other.name;
    }

    public string PegarPremio()
    {
        return premio;
    }
}
