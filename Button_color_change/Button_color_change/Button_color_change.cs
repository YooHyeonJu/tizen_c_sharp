using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Button_color_change
{
    class Program : NUIApplication
    {
        private PushButton _colorButton;
        private TextLabel _text;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.BackgroundColor = Color.Black;
            Window.Instance.KeyEvent += OnKeyEvent;

            _text = new TextLabel("Hello World");
            _text.HorizontalAlignment = HorizontalAlignment.Center;
            _text.VerticalAlignment = VerticalAlignment.Center;
            _text.TextColor = Color.White;
            _text.PointSize = 100.0f;
            _text.HeightResizePolicy = ResizePolicyType.FillToParent;
            _text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(_text);

            _colorButton = CreateButton("ColorChange");
            _colorButton.Clicked += ButtonClick;
            _colorButton.Position2D = new Position2D(750, 800);
            Window.Instance.GetDefaultLayer().Add(_colorButton);
        }
        
        
        private bool ButtonClick(object source, EventArgs e)
        {
            PushButton button = source as PushButton;

            Color[] colorArray = new Color[] {Color.Black,Color.Blue,Color.Cyan,Color.Green,Color.Magenta,
                Color.Red,Color.Transparent, Color.White,Color.Yellow};

            Random random = new Random();
            int idx = random.Next(0, 9);

            if (button.Name == "ColorChange")
            {
                // 전체 배경색이 바뀐다.
                Window.Instance.BackgroundColor = colorArray[idx];

                // 'Hello World' 글자 색이 바뀐다.
                _text.TextColor = colorArray[idx];

                // 버튼이 있는 공간의 배경색이 바뀐다.
                button.BackgroundColor = colorArray[idx];

                // 버튼이 클릭되는 순간 눌려진(선택된) 버튼색이 바뀐다.
                button.SelectedColor = colorArray[idx];
                
                // 버튼이 클릭되고 난 후, 눌려졌던(선택되었던) 버튼색이 바뀐다.
                button.UnselectedColor = colorArray[idx];
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
            button.Name = name;
            PropertyMap _buttonText = CreateTextVisual(name, Color.Blue);
            button.Label = _buttonText;
            //button.LabelText = name;
            
            return button;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
