using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace OrbitalSurvey.UI.Controls
{
    public class OrbitLine : VisualElement
    {
        public OrbitLine()
        {
            generateVisualContent += OnGenerateVisualContent;
        }

        private void OnGenerateVisualContent(MeshGenerationContext mgc)
        {
            var paint = mgc.painter2D;

            paint.strokeColor = Color.cyan;
            paint.BeginPath();

            var p0 = new Vector2(0, 0);
            var p1 = new Vector2(1500, 0);
            var p2 = new Vector2(100, 200);
            var p3 = new Vector2(0, 100);

            //paint.MoveTo(p0);
            //paint.LineTo(p1);
            //paint.LineTo(p2);
            //paint.LineTo(p3);
            //paint.ClosePath();
            //paint2d.Fill();
            //paint.Stroke();

            //paint.BeginPath();
            //paint.Arc(new(200, 200), 50, -30, 90);
            //paint.Stroke();

            paint.BeginPath();
            paint.MoveTo(new(100,100));
            paint.BezierCurveTo(new(50, 200), new(300, 250), new Vector2(400, 100));
            paint.Stroke();
        }
        

        public new class UxmlFactory : UxmlFactory<OrbitLine, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlColorAttributeDescription _color = new UxmlColorAttributeDescription()
            { name = "color", defaultValue = Color.black };
            UxmlStringAttributeDescription _text = new UxmlStringAttributeDescription()
            { name = "text", defaultValue = "NameOfControl" };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                if (ve is OrbitLine control)
                {
                    //control.ColorValue = _color.GetValueFromBag(bag, cc);
                    //control.TextValue = _text.GetValueFromBag(bag, cc);
                }
            }
        }
    }
}