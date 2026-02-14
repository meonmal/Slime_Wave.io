using UnityEngine;

public class Item : MonoBehaviour
{
    // æ∆¿Ã≈€ »πµÊ »ø∞˙
    [SerializeField]
    private GameObject itemEffect;

    public void Exit()
    {
        Instantiate(itemEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
