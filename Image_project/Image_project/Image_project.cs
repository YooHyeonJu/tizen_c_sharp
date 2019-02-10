using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace STVNUIApplication1
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            ImageView view = new ImageView();
            view.Size2D = new Size2D(500, 200);
            view.Position = new Position(750, 275, 0);
            view.PositionUsesPivotPoint = true;
            view.PivotPoint = PivotPoint.TopLeft;
            view.ParentOrigin = ParentOrigin.TopLeft;
            view.SetImage(DirectoryInfo.Resource + "tizen_image.jpg");

            
            Window.Instance.GetDefaultLayer().Add(view);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
