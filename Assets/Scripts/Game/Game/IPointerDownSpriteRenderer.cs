using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Game
{
    public interface IPointerDownSpriteRenderer
    {
        Collider2D Collider { get; }
        void OnClick();
    }
}
