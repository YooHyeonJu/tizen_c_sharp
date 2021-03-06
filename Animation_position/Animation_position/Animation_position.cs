﻿using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Animation_position
{
    class Program : NUIApplication
    {
        private Animation positionAnimation;
        private PushButton _positionButton;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void AllStop()
        {
            positionAnimation.Stop();
        }

        void Initialize()
        {
            Window.Instance.BackgroundColor = Color.Black;
            Window.Instance.KeyEvent += OnKeyEvent;

            TextLabel text = new TextLabel("Hello World");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Red;
            text.PointSize = 100.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);

            _positionButton = CreateButton("PositionChange");
            _positionButton.Clicked += ButtonClick;
            _positionButton.Position2D = new Position2D(750, 800);
            Window.Instance.GetDefaultLayer().Add(_positionButton);

            positionAnimation = new Animation(5000);
            positionAnimation.AnimateTo(text, "Position", new Position(-100, 150, 0), 0, 1000);
            positionAnimation.AnimateTo(text, "Position", new Position(600, -250, 0), 1000, 2000);
            positionAnimation.AnimateTo(text, "Position", new Position(-530, -265, 0), 2000, 3000);
            positionAnimation.AnimateTo(text, "Position", new Position(-100, 150, 0), 3000, 4000);
            positionAnimation.AnimateTo(text, "Position", new Position(0, 0, 0), 4000, 5000);
            positionAnimation.EndAction = Animation.EndActions.StopFinal;
        }

        private bool ButtonClick(object source, EventArgs e)
        {
            PushButton button = source as PushButton;

            if (button.Name == "PositionChange")
            {
                AllStop();
                positionAnimation.Play();
            }
            return false;
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        private PropertyMap CreateTextVisual(string text, Color color)
        {
            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
            map.Add(TextVisualProperty.Text, new PropertyValue(text));
            map.Add(TextVisualProperty.TextColor, new PropertyValue(color));
            map.Add(TextVisualProperty.PointSize, new PropertyValue(30.0f));
            map.Add(TextVisualProperty.HorizontalAlignment, new PropertyValue("CENTER"));
            map.Add(TextVisualProperty.VerticalAlignment, new PropertyValue("CENTER"));
            return map;
        }

        private PushButton CreateButton(string name)
        {
            PushButton button = new PushButton();
            button.Size2D = new Size2D(300, 100);
            button.Focusable = true;
            button.Name = name;
            PropertyMap _buttonText = CreateTextVisual(name, Color.Blue);
            button.Label = _buttonText;

            return button;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
