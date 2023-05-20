using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tiers;

    private int activeTier;

    private void Start()
    {
        activeTier = 0;
        SwitchCanvas(activeTier);
    }

    public void SwitchCanvas(int tierIndex)
    {
        tiers[activeTier].SetActive(false);
        tiers[tierIndex].SetActive(true);
        activeTier = tierIndex;
    }
}
