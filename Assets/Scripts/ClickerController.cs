using UnityEngine;

public class ClickerController : MonoBehaviour
{
    public static ClickerController Instance;

    public float clickCount;
    public int clicksPerClick;
    public int extraClicksPerSecond;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        clicksPerClick = 1;
        extraClicksPerSecond = 0;
    }

    void Update()
    {
        clickCount += extraClicksPerSecond * Time.deltaTime;
    }

    public void OnClick()
    {
        clickCount += clicksPerClick;
    }

    public void DecreaseClickCount(int amount)
    {
        clickCount -= amount;
    }

    public void IncreaseClicksPerClick(Upgrade upgrade)
    {
        clicksPerClick *= 2;
    }

    public void IncreaseExtraClicksPerSecond(Upgrade upgrade)
    {
        extraClicksPerSecond += 1;
    }

    public void DoubleTotalClicks(Upgrade upgrade)
    {
        clickCount *= 2;
    }

}
