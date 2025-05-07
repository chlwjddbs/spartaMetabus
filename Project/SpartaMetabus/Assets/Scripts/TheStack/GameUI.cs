using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TheStack
{
    public class GameUI : BaseUI
    {
        private TextMeshProUGUI scoreText;
        private TextMeshProUGUI comboText;
        private TextMeshProUGUI maxComboText;

        protected override UIState GetUIState()
        {
            return UIState.Game;
        }

        public override void Init(UIManager uiManger)
        {
            base.Init(uiManger);

            scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
            maxComboText = transform.Find("MaxComboText").GetComponent<TextMeshProUGUI>();
        }

        public void SetUI(int score, int combo, int maxCombo)
        {
            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
            maxComboText.text = maxCombo.ToString();
        }
    }
}