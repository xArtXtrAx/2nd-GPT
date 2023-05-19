using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeSO upgrade;
    public Image progressBar;

    private float currentProgress;

    private void Update()
    {
        // Get the target progress directly here
        float targetProgress = GameManager.Instance.GetUpgradeProgress(upgrade);

        // Interpolate towards the target progress.
        currentProgress = Mathf.Lerp(currentProgress, targetProgress, 0.3f);

        progressBar.fillAmount = currentProgress;
    }
}
