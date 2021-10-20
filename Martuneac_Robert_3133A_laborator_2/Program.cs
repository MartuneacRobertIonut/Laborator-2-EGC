using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {

        KeyboardState lastKeyPress;
        bool resizeShape = false;
        bool shape = true;

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Black);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();

            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            }
            else if (keyboard[OpenTK.Input.Key.P] && !keyboard.Equals(lastKeyPress))
            {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacțieuman << calculator.
                if (shape == true)
                {
                    shape = false;
                }
                else
                {
                    shape = true;
                }
            }
            else if (keyboard[OpenTK.Input.Key.R] && !keyboard.Equals(lastKeyPress))
            {
                if (shape == true && resizeShape == false)
                {
                    resizeShape = true;
                }
                else
                {
                    resizeShape = false;
                    shape = true;
                }
            }
            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (shape == true)
            {
                drawShape();
            }
            if (resizeShape == true)
            {
                shape = false;
                drawResizeForm();
            }


            this.SwapBuffers();
        }

        private void drawShape()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Orange);
            GL.Vertex2(0.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Red);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Violet);
            GL.Vertex2(1.0f, -1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Gray);
            GL.Vertex2(-1.0f, -1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Violet);
            GL.Vertex2(1.0f, -1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Gray);
            GL.Vertex2(-1.0f, -1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Orange);
            GL.Vertex2(0.0f, 1.0f);

            GL.End();
        }

        private void drawResizeForm()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Orange);
            GL.Vertex2(0.0f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Red);
            GL.Vertex2(0.5f, 0.5f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Violet);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Gray);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Violet);
            GL.Vertex2(0.5f, -0.5f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Gray);
            GL.Vertex2(-0.5f, -0.5f);

            GL.End();

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, 0.0f);
            GL.Color3(Color.Orange);
            GL.Vertex2(0.0f, 0.5f);

            GL.End();
        }

        [STAThread]
        static void Main(string[] args)
        {

            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
