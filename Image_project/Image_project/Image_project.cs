using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace image_project
{
    class Program : NUIApplication
    {
        private ImageView image;

        private Animation opacityAnimation;
        private Animation orientationAnimation;
        private Animation pixelAreaAnimation;

        private PushButton _opacityButton;
        private PushButton _orientationButton;
        private PushButton _pixelAreaButton;


        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private void AllStop()
        {
            opacityAnimation.Stop();
            orientationAnimation.Stop();
            pixelAreaAnimation.Stop();
        }


        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            image = new ImageView();
            image.Size2D = new Size2D(500, 200);
            image.Position = new Position(750, 275, 0);
            image.PositionUsesPivotPoint = true;
            image.PivotPoint = PivotPoint.TopLeft;
            image.ParentOrigin = ParentOrigin.TopLeft;
            image.SetImage(DirectoryInfo.Resource + "tizen_image.jpg");
            Window.Instance.GetDefaultLayer().Add(image);

            _opacityButton = CreateButton("OpacityAnimation");
            _orientationButton = CreateButton("OrientationAnimation");
            _pixelAreaButton = CreateButton("pixelAreaAnimation");

            _opacityButton.Clicked += ButtonClick;
            _orientationButton.Clicked += ButtonClick;
            _pixelAreaButton.Clicked += ButtonClick;
            
            TableView tableView = new TableView(1, 3);
            tableView.Size2D = new Size2D(1300, 330);
            tableView.PivotPoint = PivotPoint.TopLeft;
            tableView.ParentOrigin = ParentOrigin.TopLeft;
            tableView.Position2D = new Position2D(400, 800);
            
            tableView.AddChild(_orientationButton, new TableView.CellPosition(0, 0));
            tableView.AddChild(_opacityButton, new TableView.CellPosition(0, 1));
            tableView.AddChild(_pixelAreaButton, new TableView.CellPosition(0, 2));

            Window.Instance.GetDefaultLayer().Add(tableView);

            opacityAnimation = new Animation();
            orientationAnimation = new Animation();
            pixelAreaAnimation = new Animation();

            opacityAnimation = new Animation(1500);
            opacityAnimation.AnimateTo(image, "Opacity", 0.5f, 0, 400);
            opacityAnimation.AnimateTo(image, "Opacity", 0.0f, 400, 800);
            opacityAnimation.AnimateTo(image, "Opacity", 0.7f, 800, 1250);
            opacityAnimation.AnimateTo(image, "Opacity", 1.0f, 1250, 1500);
            opacityAnimation.EndAction = Animation.EndActions.StopFinal;

            orientationAnimation = new Animation();
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(new Degree(200.0f)), PositionAxis.X), 0, 400);
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(new Degree(60.0f)), PositionAxis.Y), 400, 800);
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(new Degree(30.0f)), PositionAxis.Z), 800, 1000);
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(0.0f), PositionAxis.X), 1000, 1400);
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(0.0f), PositionAxis.Y), 1400, 1800);
            orientationAnimation.AnimateTo(image, "Orientation", new Rotation(new Radian(0.0f), PositionAxis.Z), 1800, 2200);
            orientationAnimation.EndAction = Animation.EndActions.StopFinal;
            
            pixelAreaAnimation = new Animation(2000);
            RelativeVector4 vec1 = new RelativeVector4(0.0f, 0.0f, 1.0f, 0.3f);
            RelativeVector4 vec2 = new RelativeVector4(0.6f, 0.0f, 1.0f, 0.4f);
            RelativeVector4 vec3 = new RelativeVector4(0.0f, 0.0f, 1.0f, 1.0f);
            pixelAreaAnimation.AnimateTo(image, "pixelArea", vec1, 0, 500);
            pixelAreaAnimation.AnimateTo(image, "pixelArea", vec2, 500, 1000);
            pixelAreaAnimation.AnimateTo(image, "pixelArea", vec3, 1500, 2000);
            pixelAreaAnimation.EndAction = Animation.EndActions.StopFinal;

        }

        private bool ButtonClick(object source, EventArgs e)
        {
            PushButton button = source as PushButton;
            
            if (button.Name == "OpacityAnimation")
            {
                AllStop();
                opacityAnimation.Play();
            }
            if (button.Name == "OrientationAnimation")
            {
                AllStop();
                orientationAnimation.Play();
            }
            if (button.Name == "pixelAreaAnimation")
            {
                AllStop();
                pixelAreaAnimation.Play();
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
            button.Size2D = new Size2D(400, 100);
            button.Focusable = true;
            button.Name = name;
            
            PropertyMap _buttonText = CreateTextVisual(name, Color.Black);
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
