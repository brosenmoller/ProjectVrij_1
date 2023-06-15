using UnityEngine;

[RequireComponent(typeof(Light))]
public class LockLight : MonoBehaviour
{
    [SerializeField] private Color setColor;
    private Light lockLight;

    private void Awake()
    {
        lockLight = GetComponent<Light>();    
    }

    public void SetColor()
    {
        lockLight.color = setColor;
    }
}
