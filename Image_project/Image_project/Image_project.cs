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

            /*
            TextLabel text = new TextLabel("Hello World");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.White;
            text.PointSize = 100.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            */

            ImageView view = new ImageView();
            view.Size2D = new Size2D(500, 200);
            view.Position = new Position(750, 275, 0);
            view.PositionUsesPivotPoint = true;
            view.PivotPoint = PivotPoint.TopLeft;
            view.ParentOrigin = ParentOrigin.TopLeft;
            //view.SetImage(DirectoryInfo.Resource + "\tizen_image.jpg");
            view.SetImage(DirectoryInfo.Resource + "tizen_image.jpg");

            
            //view.SetImage("/opt/usr/apps/Image_project/tizen_image.jpg");
            //file:///C:/Users/yhj80/Documents/Visual%20Studio%202017/Projects/TV_NUI(NO_C_sharp)/Image_project/Image_project/tizen_image.jpg
            //Window.Instance.GetDefaultLayer().Add(text);
            Window.Instance.GetDefaultLayer().Add(view);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        /*
        static void app_get_resource(const char* edj_file_in, char* edj_path_out, int edj_path_max)
        {
            char* res_path = app_get_resource_path();
            if (res_path) {
                snprintf(edj_path_out, edj_path_max, "%s%s", res_path, edj_file_in);
                free(res_path);
            }
        }
        */

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
