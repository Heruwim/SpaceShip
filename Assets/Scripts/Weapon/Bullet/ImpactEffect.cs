using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField] private float _delay = 0.3f;

    private void Start()
    {
        Destroy(gameObject, _delay);
    }
}
