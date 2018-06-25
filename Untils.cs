using System;
using System.Collections.Generic;
using System.Xml;
using Discord;
using System.Diagnostics;

namespace SuperBotDLL1_0
{
    namespace Untils
    { 
        public class Weathercmd
        {
            public static string TempAll(double tempK)
            {
                double tempc = tempK - 273.15;
                var list = new List<string>
                {
                    tempK.ToString().Replace(",", "."),
                    Math.Round(tempK - 273.15, 2).ToString().Replace(",", "."),
                    Math.Round(tempc * 1.8 + 32, 2).ToString().Replace(",", ".")
                };
                return string.Join("_", list);
            }

            public static string SunUptime(string sunrise, string sunset)
            {
                string[] sunup = sunrise.Split('T');
                string[] sundown = sunset.Split('T');
                TimeSpan ts1 = TimeSpan.Parse(sunup[1]);
                TimeSpan ts2 = TimeSpan.Parse(sundown[1]);
                return (ts2 - ts1).ToString();
            }

            public static string Precipitationweather(XmlNode node)
            {
                try
                {
                    string rain = node.Attributes[0].InnerText;
                    if (rain != null)
                    {
                        var Rain = new List<string>();
                        for (int i = 0; i <= 2; i++)
                        {
                            Rain.Add(node.Attributes[i].InnerText);
                        }
                        return $"{Rain[1]}, {Rain[0]}mm, {Rain[2]}";
                    }
                    else
                    {
                        return "no";
                    }
                }
                catch (Exception)
                {
                    return "no";
                }
            }

            public static string Precipitationforecast(XmlNode node)
            {
                string rain = node.Attributes[0].InnerText;
                if (rain != "no")
                {
                    var Rain = new List<string>();
                    for (int i = 0; i <= 2; i++)
                    {
                        Rain.Add(node.Attributes[i].InnerText);
                    }
                    return $"{Math.Round(double.Parse(Rain[1]), 3)}mm, {Rain[2]}";
                }
                else
                {
                    return "no";
                }
            }

            public static string Emoji(Dictionary<int, string> emoji, string weatherId, string weathername)
            {
                if (emoji.ContainsKey(int.Parse(weatherId)))
                {
                    return $"Weather: {weathername}, {emoji[int.Parse(weatherId)]}";
                }
                else
                {
                    return $"Weather: {weathername}";
                }
            }
        }

        public class Other
        {
            static List<float> AvailableCPU = new List<float>();
            static List<float> AvailableRAM = new List<float>();
            protected static PerformanceCounter cpuCounter;
            protected static PerformanceCounter ramCounter;
            static List<PerformanceCounter> cpuCounters = new List<PerformanceCounter>();
            static List<PerformanceCounter> core = new List<PerformanceCounter>();

            public static string CalculateTimeWithSeconds(int seconds)
            {
                if (seconds == 0)
                    return "No time.";

                int years, minutes, months, days, hours = 0;

                minutes = seconds / 60;
                seconds %= 60;
                hours = minutes / 60;
                minutes %= 60;
                days = hours / 24;
                hours %= 24;
                months = days / 30;
                days %= 30;
                years = months / 12;
                months %= 12;

                string animeWatched = "";

                if (years > 0)
                {
                    animeWatched += years;
                    if (years == 1)
                        animeWatched += " **year**";
                    else
                        animeWatched += " **years**";
                }

                if (months > 0)
                {
                    if (animeWatched.Length > 0)
                        animeWatched += ", ";
                    animeWatched += months;
                    if (months == 1)
                        animeWatched += " **month**";
                    else
                        animeWatched += " **months**";
                }

                if (days > 0)
                {
                    if (animeWatched.Length > 0)
                        animeWatched += ", ";
                    animeWatched += days;
                    if (days == 1)
                        animeWatched += " **day**";
                    else
                        animeWatched += " **days**";
                }

                if (hours > 0)
                {
                    if (animeWatched.Length > 0)
                        animeWatched += ", ";
                    animeWatched += hours;
                    if (hours == 1)
                        animeWatched += " **hour**";
                    else
                        animeWatched += " **hours**";
                }

                if (minutes > 0)
                {
                    if (animeWatched.Length > 0)
                        animeWatched += ",";
                    animeWatched += minutes;
                    if (minutes == 1)
                        animeWatched += " **minute**";
                    else
                        animeWatched += " **minutes**";
                }

                if (seconds > 0)
                {
                    if (animeWatched.Length > 0)
                        animeWatched += " and ";
                    animeWatched += seconds;
                    if (seconds == 1)
                        animeWatched += " **second**";
                    else
                        animeWatched += " **seconds**";
                }

                return animeWatched;
            }

            public static EmbedBuilder GetCpuPreformance(EmbedBuilder builder)
            {
                var list = new List<string>();
                var core = new List<float>();
                cpuCounter = new PerformanceCounter
                {
                    CategoryName = "Processor",
                    CounterName = "% Processor Time",
                    InstanceName = "_Total"
                };

                ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                int procCount = Environment.ProcessorCount;
                for (int i = 0; i < procCount; i++)
                {
                    PerformanceCounter pc = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                    cpuCounters.Add(pc);
                }

                //float cpu = cpuCounter.NextValue();
                float cpu = procCount;
                float sum = 0;
                foreach (PerformanceCounter a in cpuCounters)
                {
                    sum = sum + a.NextValue();
                    float sum1 = sum / (procCount);
                    core.Add((float)Math.Round(sum1, 2));
                }
                sum = sum / (procCount);
                float ram = 8000 - ramCounter.NextValue();
                list.Add("```ini");
                //list.Add($"??? {string.Join(",", cpuCounters)}");
                list.Add($"Cpu:         {Math.Round(sum, 2)}%");
                list.Add($"core 0:      {core[0]}%");
                list.Add($"core 1:      {core[1]}%");
                list.Add($"core 2:      {core[2]}%");
                list.Add($"core 3:      {core[3]}%");
                list.Add($"Cores:       {cpu}");
                list.Add($"Ram used:    {ram}MB");
                list.Add("```");

                builder.AddField("Using", string.Join("\n", list));
                sum = 0;
                procCount = 0;
                core.Clear();
                return builder;
            }
        }

        public class GuildChannel
        {
            private readonly string path = "./file/serversettings.xml";
            public ulong GuildId  { get; }
            public bool On  { get; set; }
            public List<ulong> Channels { get; }
            public GuildChannel(ulong guildid)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                try
                {
                    
                    GuildId = guildid;
                    On = bool.Parse(doc.SelectSingleNode($"root/guild" + guildid).Attributes["on"].InnerText);
                    var list = new List<ulong>();
                    foreach (XmlNode node in doc.SelectSingleNode($"root/guild" + guildid))
                        list.Add(ulong.Parse(node.Attributes["id"].InnerText));
                    Channels = list;
                }
                catch (Exception)
                {
                    XmlElement guild = doc.CreateElement($"guild{guildid}");
                    guild.SetAttribute("id", guildid.ToString());
                    guild.SetAttribute("on", "false");
                    doc.SelectSingleNode("root").AppendChild(guild);
                    doc.Save(path);
                }
            }

            public void Add(ulong guildid, ulong channelid)
            {
                bool exists = false;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode guild = doc.SelectSingleNode("root/guild" + guildid);
                foreach (XmlNode channel in guild)
                {
                    if (channel.Attributes["id"].InnerText == channelid.ToString())
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    XmlElement newchannel = doc.CreateElement("channel");
                    newchannel.SetAttribute("id", channelid.ToString());
                    guild.AppendChild(newchannel);
                    doc.Save(path);
                    Channels.Add(channelid);
                }
                else
                {
                    throw new Exception("this channel is already added");
                }
            }

            public void Remove(ulong guildid, ulong channelid)
            {
                bool removed = false;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode guild = doc.SelectSingleNode("root/guild" + guildid);
                foreach (XmlNode channel in guild)
                {
                    if (channel.Attributes[0].InnerText == channelid.ToString())
                    {
                        removed = true;
                        guild.RemoveChild(channel);
                        doc.Save(path);
                        Channels.Remove(channelid);
                        break;
                    }
                }
                if (!removed)
                    throw new Exception("this channel was not in the list of channels");
            }

            public void Enable(ulong guildid)
            {
                if (On)
                {
                    throw new Exception("this guild is already enabled");
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode guild = doc.SelectSingleNode("root/guild" + guildid);
                    guild.Attributes["on"].InnerText = "true";
                    doc.Save(path);
                    On = true;
                }
            }

            public void Disable(ulong guildid)
            {
                if (!On)
                {
                    throw new Exception("this guild is already disabled");
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode guild = doc.SelectSingleNode("root/guild" + guildid);
                    guild.Attributes["on"].InnerText = "false";
                    doc.Save(path);
                    On = false;
                }
            }
        }
    }
}
