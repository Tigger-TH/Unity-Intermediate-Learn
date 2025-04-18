using PrimeTween;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int price = 5;
    void PrintCurrrentMoney(int currentMoney)
    {
        Debug.Log($"Current money is {currentMoney}");
    }

    private void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrrentMoney);
        Tween.PositionY(transform, transform.position.y + 0.25f ,1f,cycles: 99, cycleMode: CycleMode.Yoyo);
    }
    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrrentMoney);
    }

    public void Collect()
    {
        GameManager.Instance.Money = price;
        Destroy(gameObject);
    }
}
