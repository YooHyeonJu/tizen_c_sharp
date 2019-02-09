using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace STVNUIApplication1
{
    class Program : NUIApplication
    {
        //private Animation colorAnimation;
        //private PushButton _colorButton;

        private Animation sizeAnimation;
        private PushButton _sizeButton;

        private void AllStop()
        {
            //colorAnimation.Stop();
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.BackgroundColor = Color.Black;
            Window.Instance.KeyEvent += OnKeyEvent;
            View focusIndicator = new View();
            FocusManager.Instance.FocusIndicator = focusIndicator;

            TextLabel text = new TextLabel("Hello World");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Red;
            text.PointSize = 100.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);

            //_colorButton = CreateButton("ColorChange");
            //_colorButton.Clicked += ButtonClick;
            //_colorButton.Position2D = new Position2D(750 , 800);
            //Window.Instance.GetDefaultLayer().Add(_colorButton);

            _sizeButton = CreateButton("SizeChange");
            _sizeButton.Clicked += ButtonClick;
            _sizeButton.Position2D = new Position2D(750, 800);
            Window.Instance.GetDefaultLayer().Add(_sizeButton);

            /*
            TableView tableView = new TableView(1, 2);
            tableView.Size2D = new Size2D(650, 600);
            tableView.PivotPoint = PivotPoint.TopLeft;
            tableView.ParentOrigin = ParentOrigin.TopLeft;
            tableView.Position2D = new Position2D(650, 730);
            

            tableView.AddChild(_colorButton, new TableView.CellPosition(0, 0));
            tableView.AddChild(_sizeButton, new TableView.CellPosition(0, 1));
            Window.Instance.GetDefaultLayer().Add(tableView);
            */

            /*
            colorAnimation = new Animation();
            Color[] colorArray = new Color[] {Color.Black,Color.Blue,Color.Cyan,Color.Green,Color.Magenta,Color.Red,Color.Transparent,
                Color.White,Color.Yellow};
            colorAnimation.AnimateTo(text, "color", text.TextColor = colorArray[new Random().Next(1, 9)]);
            colorAnimation.EndAction = Animation.EndActions.StopFinal;
            */

            sizeAnimation = new Animation();
            sizeAnimation.AnimateTo(text, "scaleX", 2.0f, 100, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            sizeAnimation.AnimateTo(text, "scaleY", 2.0f, 100, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            sizeAnimation.AnimateTo(text, "scaleX", 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            sizeAnimation.AnimateTo(text, "scaleY", 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            sizeAnimation.AnimateTo(text, "scaleX", -0.5f, 1300, 2000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            sizeAnimation.AnimateTo(text, "scaleY", -0.5f, 1300, 2000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce));
            sizeAnimation.EndAction = Animation.EndActions.StopFinal;


            text.Focusable = true;
            Window.Instance.KeyEvent += OnKeyEvent;
        }

        private bool ButtonClick(object source,EventArgs e)
        {
            PushButton button = source as PushButton;
            if (button.Name == "SizeChange")
            {
                AllStop();
                sizeAnimation.Play();
            }
            /*
            else if (button.Name == "ColorChange")
            {
                AllStop();
                colorAnimation.Play();
            }
            */
            
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
            
            PropertyMap _focusText = CreateTextVisual(name, Color.Red);
            PropertyMap _unfocusText = CreateTextVisual(name, Color.White);
            button.Label = _unfocusText;

            button.FocusLost += (obj, e) =>
            {
                button.Label = _unfocusText;
            };

            button.FocusGained += (obj, e) =>
            {
                button.Label = _focusText;
            };
            
            return button;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
