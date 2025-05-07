using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheStack
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected UIManager uiManager;

        public virtual void Init(UIManager uiManger)
        {
            this.uiManager = uiManger;
        }

        protected abstract UIState GetUIState();

        public void SetActive(UIState state)
        {
            gameObject.SetActive(GetUIState() == state);
        }
    }
}