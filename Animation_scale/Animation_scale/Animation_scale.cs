using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Animation_scale
{
    class Program : NUIApplication
    {
        private Animation scaleAnimation;
        private PushButton _scaleButton;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void AllStop()
        {
            scaleAnimation.Stop();
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

            _scaleButton = CreateButton("ScaleChange");
            _scaleButton.Clicked += ButtonClick;
            _scaleButton.Position2D = new Position2D(750, 800);
            Window.Instance.GetDefaultLayer().Add(_scaleButton);

            scaleAnimation = new Animation();
            /*
            scaleAnimation.AnimateTo(text, "scaleX", 2.0f, 100, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleY", 2.0f, 100, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleX", 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleX", -2.0f, 1100, 2000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleY", -2.0f, 1100, 2000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            */

            /*
            scaleAnimation.AnimateTo(text, "scaleX", 7.0f, 100, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleY", -2.0f, 300, 800, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleX", 1.0f, 1300,1700, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", 1.0f, 1100, 1900, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleX", -0.6f, 2400, 3000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            scaleAnimation.AnimateTo(text, "scaleY", 3.2f, 2100, 2700, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            */

            scaleAnimation.AnimateTo(text, "scaleX", 2.0f, 100, 500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", 2.0f, 100, 500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

            scaleAnimation.AnimateTo(text, "scaleX", -2.0f,1100,1500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", 2.0f, 1100, 1500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

            scaleAnimation.AnimateTo(text, "scaleX", 2.0f, 2100, 2500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", -2.0f,2100, 2500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

            scaleAnimation.AnimateTo(text, "scaleX", -2.0f, 3100, 3500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            scaleAnimation.AnimateTo(text, "scaleY", -2.0f, 3100, 3500, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

            scaleAnimation.EndAction = Animation.EndActions.StopFinal;
        }
        

        private bool ButtonClick(object source, EventArgs e)
        {
            PushButton button = source as PushButton;

            if (button.Name == "ScaleChange")
            {
                AllStop();
                scaleAnimation.Play();
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
