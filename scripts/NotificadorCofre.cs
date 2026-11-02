using UnityEngine;

public class NotificadorCofre : MonoBehaviour
{
    public  delegate void mensaje();
    public event mensaje OnEventoVista;
    public void OnPointerEnter() {
        OnEventoVista();
    }
    public void OnPointerExit() {}
}
