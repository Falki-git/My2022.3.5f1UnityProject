using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable InconsistentNaming

namespace OrbitalSurvey.UI.Controls
{
    public class VesselMarkerControl : VisualElement
    {
        public const string UssClassName = "vessel-marker";
        public const string UssClassName_Name = UssClassName + "__name";
        public const string UssClassName_Marker = UssClassName + "__marker";
        public const string UssClassName_MarkerGoodTint = UssClassName_Marker + "--good";
        public const string UssClassName_MarkerWarningTint = UssClassName_Marker + "--warning";
        public const string UssClassName_MarkerErrorTint = UssClassName_Marker + "--error";
        public const string UssClassName_MarkerInnactiveTint = UssClassName_Marker + "--innactive";
        public static string UssClassName_Latitude = UssClassName + "__latitude";
        public static string UssClassName_Longitude = UssClassName + "__longitude";

        private Label NameLabel;
        private VisualElement MarkerElement;
        private Label LatitudeLabel;
        private Label LongitudeLabel;

        public string NameValue
        {
            get => NameLabel.text;
            set => NameLabel.text = value;
        }

        public Texture2D MarkerTexture
        {
            get => MarkerElement.style.backgroundImage.value.texture;
            set => MarkerElement.style.backgroundImage = value;
        }

        public double LatitudeValue
        {
            //get => LatitudeLabel.text;
            set => LatitudeLabel.text = $"LAT: {value.ToString("F6")}";
        }

        public double LongitudeValue
        {
            //get => LongitudeLabel.text;
            set => LongitudeLabel.text = $"LON: {value.ToString("F6")}";
        }

        public VesselMarkerControl(string name, double latitude, double longitude) : this()
        {
            NameValue = name;
            LatitudeValue = latitude;
            LongitudeValue = longitude;
        }

        public VesselMarkerControl()
        {
            AddToClassList(UssClassName);

            NameLabel = new Label()
            {
                name = "vessel-name"
            };
            NameLabel.AddToClassList(UssClassName_Name);
            hierarchy.Add(NameLabel);

            MarkerElement = new VisualElement()
            {
                name = "vessel-marker"
            };
            MarkerElement.AddToClassList(UssClassName_Marker);
            hierarchy.Add(MarkerElement);

            LatitudeLabel = new Label()
            {
                name = "vessel-latitude"
            };
            LatitudeLabel.AddToClassList(UssClassName_Latitude);
            hierarchy.Add(LatitudeLabel);

            LongitudeLabel = new Label()
            {
                name = "vessel-longitude"
            };
            LongitudeLabel.AddToClassList(UssClassName_Longitude);
            hierarchy.Add(LongitudeLabel);
        }

        public void SetAsNormal()
        {
            MarkerElement.RemoveFromClassList(UssClassName_MarkerGoodTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerWarningTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerErrorTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerInnactiveTint);
        }

        public void SetAsGood()
        {
            MarkerElement.AddToClassList(UssClassName_MarkerGoodTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerWarningTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerErrorTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerInnactiveTint);
        }

        public void SetAsWarning()
        {
            MarkerElement.RemoveFromClassList(UssClassName_MarkerGoodTint);
            MarkerElement.AddToClassList(UssClassName_MarkerWarningTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerErrorTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerInnactiveTint);
        }

        public void SetAsError()
        {
            MarkerElement.RemoveFromClassList(UssClassName_MarkerGoodTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerWarningTint);
            MarkerElement.AddToClassList(UssClassName_MarkerErrorTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerInnactiveTint);
        }

        public void SetAsInnactive()
        {
            MarkerElement.RemoveFromClassList(UssClassName_MarkerGoodTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerWarningTint);
            MarkerElement.RemoveFromClassList(UssClassName_MarkerErrorTint);
            MarkerElement.AddToClassList(UssClassName_MarkerInnactiveTint);
        }

        public new class UxmlFactory : UxmlFactory<VesselMarkerControl, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription _name = new()
            { name = "VesselName", defaultValue = "Fly-Safe-1" };
            UxmlDoubleAttributeDescription _latitude = new()
            { name = "Latitude", defaultValue = 45.813053 };
            UxmlDoubleAttributeDescription _longitude = new()
            { name = "Latitude", defaultValue = 15.977301 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                if (ve is VesselMarkerControl control)
                {
                    control.NameValue = _name.GetValueFromBag(bag, cc);
                    control.LatitudeValue = _latitude.GetValueFromBag(bag, cc);
                    control.LongitudeValue = _longitude.GetValueFromBag(bag, cc);
                }
            }
        }
    }
}