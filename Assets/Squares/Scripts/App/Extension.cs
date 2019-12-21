using UnityEngine;
using UnityEngine.UI;

namespace Squares
{
    /// <summary>
    /// 拡張メソッド。増えてきたらTransformExtensionみたいにクラス分けする。
    /// </summary>
    public static class Extension
    {
        #region Transform
        public static Transform SetLocalPositionX(this Transform t, float x)
        {
            t.localPosition = new Vector3(x, t.localPosition.y, t.localPosition.z);
            return t;
        }

        public static Transform SetLocalPositionY(this Transform t, float y)
        {
            t.localPosition = new Vector3(t.localPosition.x, y, t.localPosition.z);
            return t;
        }

        public static Transform SetLocalPositionZ(this Transform t, float z)
        {
            t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y, z);
            return t;
        }

        public static Transform SetLocalPositionXY(this Transform t, float x, float y)
        {
            t.localPosition = new Vector3(x, y, t.localPosition.z);
            return t;
        }
        
        public static Transform SetLocalPositionXZ(this Transform t, float x, float z)
        {
            t.localPosition = new Vector3(x, t.localPosition.y, z);
            return t;
        }

        public static Transform SetLocalPositionYZ(this Transform t, float y, float z)
        {
            t.localPosition = new Vector3(t.localPosition.x, y, z);
            return t;
        }

        public static Transform SetPositionX(this Transform t, float x)
        {
            t.position = new Vector3(x, t.position.y, t.position.z);
            return t;
        }

        public static Transform SetPositionY(this Transform t, float y)
        {
            t.position = new Vector3(t.position.x, y, t.position.z);
            return t;
        }

        public static Transform SetPositionZ(this Transform t, float z)
        {
            t.position = new Vector3(t.position.x, t.position.y, z);
            return t;
        }

        public static Transform SetPositionXY(this Transform t, float x, float y)
        {
            t.position = new Vector3(x, y, t.position.z);
            return t;
        }

        public static Transform SetPositionXZ(this Transform t, float x, float z)
        {
            t.position = new Vector3(x, t.position.y, z);
            return t;
        }

        public static Transform SetPositionYZ(this Transform t, float y, float z)
        {
            t.position = new Vector3(t.position.x, y, z);
            return t;
        }

        public static Transform SetLocalScaleX(this Transform t, float x)
        {
            t.localScale = new Vector3(x, t.localScale.y, t.localScale.z);
            return t;
        }

        public static Transform SetLocalScaleY(this Transform t, float y)
        {
            t.localScale = new Vector3(t.localScale.x, y, t.localScale.z);
            return t;
        }

        public static Transform SetLocalScaleZ(this Transform t, float z)
        {
            t.localScale = new Vector3(t.localScale.x, t.localScale.y, z);
            return t;
        }

        public static Transform SetLocalScaleXY(this Transform t, float x, float y)
        {
            t.localScale = new Vector3(x, y, t.localScale.z);
            return t;
        }

        public static Transform SetLocalScaleXZ(this Transform t, float x, float z)
        {
            t.localScale = new Vector3(x, t.localScale.y, z);
            return t;
        }

        public static Transform SetLocalScaleYZ(this Transform t, float y, float z)
        {
            t.localScale = new Vector3(t.localScale.x, y, z);
            return t;
        }

        public static Transform SetLocalRotationX(this Transform t, float x)
        {
            t.localRotation = Quaternion.Euler(x, t.localRotation.eulerAngles.y, t.localRotation.eulerAngles.z);
            return t;
        }

        public static Transform SetLocalRotationY(this Transform t, float y)
        {
            t.localRotation = Quaternion.Euler(t.localRotation.eulerAngles.x, y, t.localRotation.eulerAngles.z);
            return t;
        }

        public static Transform SetLocalRotationZ(this Transform t, float z)
        {
            t.localRotation = Quaternion.Euler(t.localRotation.eulerAngles.x, t.localRotation.eulerAngles.y, z);
            return t;
        }

        public static Transform SetLocalRotationXY(this Transform t, float x, float y)
        {
            t.localRotation = Quaternion.Euler(x, y, t.localRotation.eulerAngles.z);
            return t;
        }

        public static Transform SetLocalRotationXZ(this Transform t, float x, float z)
        {
            t.localRotation = Quaternion.Euler(x, t.localRotation.eulerAngles.y, z);
            return t;
        }

        public static Transform SetLocalRotationYZ(this Transform t, float y, float z)
        {
            t.localRotation = Quaternion.Euler(t.localRotation.eulerAngles.x, y, z);
            return t;
        }
        #endregion

        #region Renderer
        public static Renderer SetColorR(this Renderer renderer, float r)
        {
            var m   = renderer.material;
            m.color = new Color(r, m.color.g, m.color.b, m.color.a);
            return renderer;
        }

        public static Renderer SetColorG(this Renderer renderer, float g)
        {
            var m   = renderer.material;
            m.color = new Color(m.color.r, g, m.color.b, m.color.a);
            return renderer;
        }

        public static Renderer SetColorB(this Renderer renderer, float b)
        {
            var m   = renderer.material;
            m.color = new Color(m.color.r, m.color.g, b, m.color.a);
            return renderer;
        }

        public static Renderer SetColorA(this Renderer renderer, float a)
        {
            var m   = renderer.material;
            m.color = new Color(m.color.r, m.color.g, m.color.b, a);
            return renderer;
        }
        #endregion

        #region Text
        public static Text SetColorR(this Text text, float r)
        {
            text.color = new Color(r, text.color.g, text.color.b, text.color.a);
            return text;
        }

        public static Text SetColorG(this Text text, float g)
        {
            text.color = new Color(text.color.r, g, text.color.b, text.color.a);
            return text;
        }

        public static Text SetColorB(this Text text, float b)
        {
            text.color = new Color(text.color.r, text.color.g, b, text.color.a);
            return text;
        }

        public static Text SetColorA(this Text text, float a)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            return text;
        }
        #endregion

        #region Outline
        public static Outline SetColorR(this Outline outline, float r)
        {
            outline.effectColor = new Color(r, outline.effectColor.g, outline.effectColor.b, outline.effectColor.a);
            return outline;
        }

        public static Outline SetColorG(this Outline outline, float g)
        {
            outline.effectColor = new Color(outline.effectColor.r, g, outline.effectColor.b, outline.effectColor.a);
            return outline;
        }

        public static Outline SetColorB(this Outline outline, float b)
        {
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, b, outline.effectColor.a);
            return outline;
        }

        public static Outline SetColorA(this Outline outline, float a)
        {
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, a);
            return outline;
        }
        #endregion
    }
}
