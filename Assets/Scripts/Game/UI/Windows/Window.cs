using System.Collections;
using System.Collections.Generic;
using Core.State;
using UnityEngine;

namespace Core.Game.UI
{
    public abstract class Window : MonoBehaviour
    {
        protected abstract void OnClose();
        protected abstract void OnShow();

        public void Close()
        {
            OnClose();
            Destroy(gameObject);
        }

        public void Show()
        {
            OnShow();
            gameObject.SetActive(true);
        }

    }
}