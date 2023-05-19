using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeSO upgrade;
    public Image progressBar;

    private float currentProgress;
    private float targetProgress;

    private float _timeSinceLastUpdate = 0f;
    private float _updateInterval;  // This will now be dynamic

    private float minUpdateInterval = 0.05f;  // Update every 0.05 seconds at minimum
    private float maxUpdateInterval = 1.0f;   // Update every 1 second at maximum
    private float levelThreshold = 100.0f;    // Level at which the maximum update interval is used

    private void Awake()
    {
        GameManager.OnUpdateClicks += UpdateUpgradeProgress;
    }

    private void Update()
    {
        // Interpolate towards the target progress.
        currentProgress = Mathf.Lerp(currentProgress, targetProgress, 0.05f);

        _timeSinceLastUpdate += Time.deltaTime;
        if (_timeSinceLastUpdate >= _updateInterval)
        {
            progressBar.fillAmount = currentProgress;
            _timeSinceLastUpdate = 0f;
        }
    }

    private void OnDestroy()
    {
        GameManager.OnUpdateClicks -= UpdateUpgradeProgress;
    }

    private void UpdateUpgradeProgress()
    {
        targetProgress = GameManager.Instance.GetUpgradeProgress(upgrade);

        // Adjust the update interval based on the level
        float level = upgrade.level;
        _updateInterval = Mathf.Lerp(minUpdateInterval, maxUpdateInterval, level / levelThreshold);
    }
}
