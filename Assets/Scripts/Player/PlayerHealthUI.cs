using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour {
    [SerializeField] Gradient uiHealthFillGradient;
    [SerializeField] Image uiHealthFill;
    [SerializeField] TextMeshProUGUI uiHealthText;


    private void OnEnable() {
        GEventsManager.AddListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
    }

    private void OnPlayerDamagedHandler(GData data) {
        float currentHealth = data.Get<float>(0);
        float defaultHealth = data.Get<float>(1);

        uiHealthText.text = Mathf.Round(currentHealth).ToString();

        float fillValue = currentHealth / defaultHealth;
        uiHealthFill.fillAmount = fillValue;
        uiHealthFill.color = uiHealthFillGradient.Evaluate(fillValue);
    }



    private void OnDisable() {
        GEventsManager.RemoveListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
    }
}
