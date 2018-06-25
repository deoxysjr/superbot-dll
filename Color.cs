using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace SuperBotDLL1_0
{
    namespace color
    {
        public class Sendcolor
        {
            public async static void ColorRed(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 0, 0));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message.ToString());
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorGreen(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 0, 255, 0));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorBlue(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 0, 0, 255));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorBlack(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 0, 0, 0));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorLightGreen(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 255, 255));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorLightRed(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 255, 255));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorLightGray(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 170, 170, 170));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorWhite(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 255, 255));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorGray(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 100, 100, 100));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorYellow(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 255, 0));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorOrange(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 255, 97, 24));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorPurple(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 120, 0, 120));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorLightBlue(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, 0, 216, 255));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorRandom(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                Random rand = new Random();
                int R = rand.Next(0, 255);
                int G = rand.Next(0, 255);
                int B = rand.Next(0, 255);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);

                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, R, G, B));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                await e.Channel.SendMessageAsync($"R: {R}, G: {G}, B: {B}");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorRandomAll(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                Random rand = new Random();
                int R = 0;
                int G = 0;
                int B = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        R = rand.Next(0, 255);
                        G = rand.Next(0, 255);
                        B = rand.Next(0, 255);
                        System.Drawing.Color p = bmp.GetPixel(x, y);
                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, R, G, B));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorRandomVret(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                Random rand = new Random();
                var R = new List<int>();
                var G = new List<int>();
                var B = new List<int>();
                for (int x = 0; x < width; x++)
                {
                    R.Add(rand.Next(0, 255));
                    G.Add(rand.Next(0, 255));
                    B.Add(rand.Next(0, 255));
                }
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);
                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, R[x], G[x], B[x]));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static async void ColorRandomHor(int width, int height, ICommandContext e, Bitmap bmp)
            {
                string id = e.User.Id.ToString();
                Random rand = new Random();
                int R = 0;
                int G = 0;
                int B = 0;
                for (int y = 0; y < height; y++)
                {
                    R = rand.Next(0, 255);
                    G = rand.Next(0, 255);
                    B = rand.Next(0, 255);
                    for (int x = 0; x < width; x++)
                    {
                        System.Drawing.Color p = bmp.GetPixel(x, y);
                        int a = p.A;

                        bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, R, G, B));
                    }
                }
                try
                {
                    bmp.Save($@".\\{id}.png");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex);
                }
                await e.Channel.SendFileAsync($@".\{id}.png");
                if (File.Exists($@"./{id}.png"))
                {
                    File.Delete($@"./{id}.png");
                }
            }

            public static System.Drawing.Color GetFirstUserColor(SocketUser u)
            {
                if (u.GetAvatarUrl() != null)
                {
                    using (var client = new WebClient())
                    {
                        //Console.WriteLine(u.GetAvatarUrl().ToString());
                        client.DownloadFile(u.GetAvatarUrl(ImageFormat.Png), $"./userimg.png");
                        Bitmap bmp = new Bitmap($"./userimg.png");
                        var pixel = bmp.GetPixel(64, 64);
                        return pixel;
                    }
                }
                else
                    return System.Drawing.Color.Gold;
            }

            public static System.Drawing.Color GetFirstUserColor(IUser u)
            {
                if (u.GetAvatarUrl() != null)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(u.GetAvatarUrl(ImageFormat.Png), $"./userimg.png");
                        Bitmap bmp = new Bitmap($"./userimg.png");
                        var pixel = bmp.GetPixel(64, 64);
                        return pixel;
                    }
                }
                else
                    return System.Drawing.Color.Gold;
            }
        }
    }
}
