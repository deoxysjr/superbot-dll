using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace SuperBotDLL1_0
{
    namespace RankingSystem
    {
        public class Ranking
        {
            public static void CheckUser(string path, string userid, string[] mineinv, string[] pickinv, string[] craftinv)
            {
                string[] type = { "info", "level", "battle", "mine", "bag", "craft" };
                string[] infolist = { "messages", "commands", "battles", "dailys" };
                string[] levellist = { "currentxp", "needxp", "currentlvl", "nextlvl", "currentminelvl", "nextminelvl", "currentminexp",
                                             "needminexp", "currentpicklvl", "nextpicklvl", "currentpickxp", "needpickxp",
                                             "currentcraftxp", "needcraftxp", "currentcraftlvl", "nextcraftlvl",
                                             "prestige", "credits", "lastdaily" };
                string[] battlelist = { "healt", "damage", "creditmult", "healtmult", "damagemult" };
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode user = doc.SelectSingleNode($"user/ID{userid}");
                bool updated = false;
                for (int i = 0; i < type.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(levellist[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(type[i]);
                        if (i == 0)
                            if (user.HasChildNodes)
                                user.InsertBefore(create, user.FirstChild);
                            else
                                user.AppendChild(create);
                        else
                            user.InsertAfter(create, user.SelectSingleNode(type[i - 1]));
                        doc.Save(path);
                    }
                }
                XmlNode info = user.SelectSingleNode("info");
                XmlNode level = user.SelectSingleNode("level");
                XmlNode battle = user.SelectSingleNode("battle");
                XmlNode mine = user.SelectSingleNode("mine");
                XmlNode bag = user.SelectSingleNode("bag");
                XmlNode craft = user.SelectSingleNode("craft");
                for (int i = 0; i < infolist.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(infolist[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(infolist[i]);
                        if (infolist[i] == "messages")
                            create.SetAttribute("messages", "0");
                        else if (infolist[i] == "commands")
                            create.SetAttribute("commands", "0");
                        else if (infolist[i] == "dailys")
                            create.SetAttribute("dailys", "0");
                        else if (infolist[i] == "battles")
                        {
                            create.SetAttribute("won", "0");
                            create.SetAttribute("lost", "0");
                        }
                        if (i == 0)
                            if (info.HasChildNodes)
                                info.InsertBefore(create, info.FirstChild);
                            else
                                info.AppendChild(create);
                        else
                            info.InsertAfter(create, info[infolist[i - 1]]);
                        doc.Save(path);
                    }
                }
                for (int i = 0; i < levellist.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(levellist[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(levellist[i]);
                        if (levellist[i].Contains("need"))
                            create.SetAttribute("xp", "15");
                        else if (levellist[i].Contains("xp") && !levellist[i].Contains("need"))
                            create.SetAttribute("xp", "0");
                        else if (levellist[i].Contains("next"))
                            create.SetAttribute("lvl", "2");
                        else if (levellist[i].Contains("lvl") && !levellist[i].Contains("next"))
                            create.SetAttribute("lvl", "1");
                        else if (levellist[i].Contains("prestige"))
                            create.SetAttribute(levellist[i], "0");
                        if (i == 0)
                            if (level.HasChildNodes)
                                level.InsertBefore(create, level.FirstChild);
                            else
                                level.AppendChild(create);
                        else
                            level.InsertAfter(create, level.SelectSingleNode(levellist[i - 1]));

                        doc.Save(path);
                    }
                }
                for (int i = 0; i < battlelist.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(battlelist[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(battlelist[i]);
                        if (battlelist[i] == "healt")
                            create.SetAttribute("hp", "100");
                        else if (battlelist[i] == "damage")
                            create.SetAttribute("dg", "4-6");
                        else if (battlelist[i].Contains("mult"))
                            create.SetAttribute("mult", "1");
                        if (i == 0)
                            if (battle.HasChildNodes)
                                battle.InsertBefore(create, battle.FirstChild);
                            else
                                battle.AppendChild(create);
                        else
                            battle.InsertAfter(create, battle.SelectSingleNode(battlelist[i - 1]));
                        doc.Save(path);
                    }
                }
                for (int i = 0; i < mineinv.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(mineinv[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(mineinv[i]);
                        create.SetAttribute("bal", "0");
                        if (i == 0)
                            if (mine.HasChildNodes)
                                mine.InsertBefore(create, mine.FirstChild);
                            else
                                mine.AppendChild(create);
                        else
                            mine.InsertAfter(create, mine.SelectSingleNode(mineinv[i - 1]));
                        doc.Save(path);
                    }
                }
                for (int i = 0; i < pickinv.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(pickinv[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(pickinv[i]);
                        create.SetAttribute("bal", "0");
                        if (i == 0)
                            if (bag.HasChildNodes)
                                bag.InsertBefore(create, bag.FirstChild);
                            else
                                bag.AppendChild(create);
                        else
                            bag.InsertAfter(create, bag.SelectSingleNode(pickinv[i - 1]));
                        doc.Save(path);
                    }
                }
                for (int i = 0; i < craftinv.Length; i++)
                {
                    int a = 0;
                    if (doc.GetElementsByTagName(craftinv[i]).Count > 0) a++;
                    else
                    {
                        updated = true;
                        XmlElement create = doc.CreateElement(craftinv[i]);
                        create.SetAttribute("bal", "0");
                        if (i == 0)
                            if (craft.HasChildNodes)
                                craft.InsertBefore(create, craft.FirstChild);
                            else
                                craft.AppendChild(create);
                        else
                            craft.InsertAfter(create, craft.SelectSingleNode(craftinv[i - 1]));
                        doc.Save(path);
                    }
                }
                if (updated == true)
                    Console.WriteLine($"{DateTime.Now,-19} [{userid}] User is now up to date");
            }

            public static EmbedBuilder Miner(EmbedBuilder embed, string path, string id, int amount, string[] mineinv)
            {
                
                try
                {
                    Dictionary<string, int> curlist = new Dictionary<string, int>();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode node = doc.SelectSingleNode($"user/ID{id}/mine");
                    Random rand = new Random();
                    var list = new List<string>();
                    for (int i = 0; i < amount; i++)
                    {
                        int mine = rand.Next(0, mineinv.Length);
                        string oldmine = node.SelectSingleNode(mineinv[mine]).Attributes[0].InnerText;
                        string newmine = (int.Parse(oldmine) + 1).ToString();
                        node.SelectSingleNode(mineinv[mine]).Attributes[0].InnerText = newmine;
                        doc.Save(path);
                        if (!curlist.ContainsKey(mineinv[mine]))
                            curlist.Add(mineinv[mine], 1);
                        else
                        {
                            int cur = curlist[mineinv[mine]];
                            curlist[mineinv[mine]] += 1;
                        }
                    }
                    foreach (var item in curlist)
                        list.Add($"{item.Key}, {item.Value}");
                    embed.AddField("Mined", string.Join("\n", list));

                    return embed;
                }
                catch (Exception ex)
                {
                    embed.AddField("error", ex.Message.ToString());
                    embed.Color = Color.Red;
                    return embed;
                }

            }

            public static EmbedBuilder Picker(EmbedBuilder embed, string path, string id, int amount, string[] pickinv)
            {
                try
                {
                    Dictionary<string, int> curlist = new Dictionary<string, int>();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode node = doc.SelectSingleNode($"user/ID{id}/bag");
                    Random rand = new Random();
                    var list = new List<string>();
                    for (int i = 0; i < amount; i++)
                    {
                        int picker = rand.Next(0, pickinv.Length);
                        string CurrentApplegr = node.SelectSingleNode(pickinv[picker]).Attributes[0].InnerText;
                        string NewApplegr = (int.Parse(CurrentApplegr) + 1).ToString();
                        node.SelectSingleNode(pickinv[picker]).Attributes[0].InnerText = NewApplegr;
                        doc.Save(path);
                        if (!curlist.ContainsKey(pickinv[picker]))
                            curlist.Add(pickinv[picker], 1);
                        else
                        {
                            int cur = curlist[pickinv[picker]];
                            curlist[pickinv[picker]] += 1;
                        }
                    }
                    foreach (var item in curlist)
                        list.Add($"{item.Key}, {item.Value}");
                    embed.AddField("Pick", string.Join("\n", list));
                    return embed;
                }
                catch (Exception ex)
                {
                    embed.AddField("error", ex.Message.ToString());
                    embed.Color = Color.Red;
                    return embed;
                }
            }

            public static EmbedBuilder Bag(XmlNode node, string type)
            {
                EmbedBuilder builder = new EmbedBuilder
                {
                    Title = "Inventory",
                    Color = Color.Green
                };
                var list = new List<string>();
                if (type.ToLower() == "mine")
                {
                    foreach (XmlNode inv in node.SelectSingleNode("mine"))
                    {
                        if(inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddField("mine", string.Join("\n", list));
                    else
                        builder.AddField("mine", "you don't\nhave item's\nhere");
                }
                else if (type.ToLower() == "pick")
                {

                    foreach (XmlNode inv in node.SelectSingleNode("bag"))
                    {
                        if (inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddField("pick", string.Join("\n", list));
                    else
                        builder.AddField("pick", "you don't\nhave item's\nhere");
                }
                else if (type.ToLower() == "craft")
                {
                    foreach (XmlNode inv in node.SelectSingleNode("craft"))
                    {
                        if (inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddField("craft", string.Join("\n", list));
                    else
                        builder.AddField("craft", "you don't\nhave item's\nhere");
                }
                else if (type.ToLower() == "all")
                {
                    foreach (XmlNode inv in node.SelectSingleNode("mine"))
                    {
                        if (inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddInlineField("mine", string.Join("\n", list));
                    else
                        builder.AddInlineField("mine", "you don't\nhave item's\nhere");
                    list.Clear();
                    foreach (XmlNode inv in node.SelectSingleNode("bag"))
                    {
                        if (inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddInlineField("pick", string.Join("\n", list));
                    else
                        builder.AddInlineField("pick", "you don't\nhave item's\nhere");
                    list.Clear();
                    foreach (XmlNode inv in node.SelectSingleNode("craft"))
                    {
                        if (inv.Attributes[0].InnerText != "0")
                            list.Add($"{inv.Name}: {inv.Attributes[0].InnerText}");
                    }
                    if (list.Count != 0)
                        builder.AddInlineField("craft", string.Join("\n", list));
                    else
                        builder.AddInlineField("craft", "you don't\nhave item's\nhere");
                }
                else if (type.ToLower() == "types")
                {
                    builder.AddField("Types", "mine\npick\ncraft\nall");
                }
                else
                {
                    builder.Color = Color.Red;
                    builder.AddField("error", $"{type} doesn't exist");
                }
                return builder;
            }

            //public async static void GainXpUser(SocketMessage arg, int xp, string path)
            //{
            //    string userpath = path + arg.Author.Id + ".xml";
            //    bool exists = false;
            //    try
            //    {
            //        XmlDocument doc = new XmlDocument();
            //        doc.Load(userpath);
            //        XmlNode node = doc.SelectSingleNode("user/ID" + arg.Author.Id.ToString() + "/level");
            //        int Xpneeded = int.Parse(node.SelectSingleNode("needxp").Attributes[0].InnerText);
            //        exists = true;
            //        int newcurrentxp = int.Parse(node.SelectSingleNode("currentxp").Attributes[0].InnerText) + xp;//rand.Next(1, 5);
            //        if (newcurrentxp >= Xpneeded)
            //        {
            //            var user = arg.Author;
            //            var pixel = color.Sendcolor.GetFirstUserColor(arg.Author);
            //            var usercolor = new Color(pixel.R, pixel.G, pixel.B);
            //            EmbedBuilder builder = new EmbedBuilder
            //            {
            //                Color = Color.Gold
            //            };
            //            LevelUpUser(doc, arg.Author, path + arg.Author.Id + ".xml", Xpneeded, newcurrentxp);
            //            TotalLvlAdd();
            //            builder.AddField("Level Up", arg.Author.Username + $", you reached level: {node.SelectSingleNode("currentlvl").Attributes[0].InnerText}");
            //            await arg.Channel.SendMessageAsync("", false, builder.Build());
            //            var message = await arg.Channel.GetMessagesAsync(1).Flatten();
            //            await Task.Delay(10000);
            //            await arg.Channel.DeleteMessagesAsync(message);
            //        }
            //        else
            //        {
            //            node.SelectSingleNode("currentxp").Attributes[0].InnerText = newcurrentxp.ToString();
            //            doc.Save(path + arg.Author.Id + ".xml");
            //        }
            //        //CheckUser(path, arg.Author.Id.ToString(), levellist, battlelist, mineinv, baginv, craftlist);
            //    }
            //    catch (Exception ex)
            //    {
            //        if (exists == false)
            //        {
            //            Console.WriteLine(AddNewUserRank(userpath, arg.Author.Id.ToString()));
            //            TotalLvlAdd();
            //            File.AppendAllText("./file/ranks/LevelLog.txt", $"{DateTime.Now,-19} [{arg.Channel.Name}] [{arg.Author.Id}] reached Level 1\r\n");
            //        }
            //        else
            //        {
            //            Console.WriteLine(ex.ToString());
            //        }
            //    }
            //}

            public static EmbedBuilder GetRank(ICommandContext context, IUser user)
            {
                EmbedBuilder builder = new EmbedBuilder
                {
                    Color = Color.Blue
                };
                var list = new List<string>();
                string path = "./file/ranks/users/";
                
                if (user == null)
                {
                    IUser u = context.User;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("User", $"Bots don't have ranks");
                        return builder;
                    }
                    else
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(path + $"{u.Id}.xml");
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentxp").Attributes[0].InnerText;
                            string Credits = node.SelectSingleNode("level/credits").Attributes[0].InnerText;
                            list.Add("your Level is " + node.SelectSingleNode("level/currentlvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add($"�{Credits}");
                            builder.AddField($"{u.Username}", string.Join("\n", list));
                            return builder;
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("User", $"sorry but you don't have a rank");
                            return builder;
                        }
                    }
                }
                else
                {
                    if (user.Id == context.Client.CurrentUser.Id)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("./file/ranks/ranking.xml");
                        string BankCredits = doc.SelectSingleNode("root/bank/credits").Attributes[0].InnerText;
                        builder.AddField("Bank", $"The bank has �{BankCredits}");
                        return builder;
                    }
                    IUser u = user;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("User", $"Bots don't have ranks");
                        return builder;
                    }
                    else
                    {
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(path + $"{u.Id}.xml");
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentxp").Attributes[0].InnerText;
                            string Credits = node.SelectSingleNode("level/credits").Attributes[0].InnerText;
                            list.Add("your Level is " + node.SelectSingleNode("level/currentlvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add($"�{Credits}");
                            builder.AddField($"{u.Username}", string.Join("\n", list));
                            return builder;
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("User", $"sorry but you don't have a rank");
                            return builder;
                        }
                    }
                }
            }
            
            public static EmbedBuilder GetMineRank(EmbedBuilder builder, ICommandContext context, IUser user)
            {
                var list = new List<string>();
                string path = "./file/ranks/ranking.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                if (user == null)
                {
                    IUser u = context.User;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a mine level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needminexp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentminexp").Attributes[0].InnerText;
                            list.Add("your mine level is " + node.SelectSingleNode("level/currentminelvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Mine level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", "sorry but you don't have a mine level");
                        }
                    }
                }
                else
                {
                    IUser u = user;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a mine level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needminexp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentminexp").Attributes[0].InnerText;
                            list.Add(u.Username + "'s mine level is " + node.SelectSingleNode("level/currentminelvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Mine level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", $"sorry but {u.Username} doesn't have a mine level");
                        }
                    }
                }
                return builder;
            }
            
            public static EmbedBuilder GetPickRank(EmbedBuilder builder, ICommandContext context, IUser user)
            {
                var list = new List<string>();
                string path = "./file/ranks/ranking.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                if (user == null)
                {
                    IUser u = context.User;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a pick level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needpickxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentpickxp").Attributes[0].InnerText;
                            list.Add("your pick level is " + node.SelectSingleNode("level/currentpicklvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Pick level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", "sorry but you don't have a pick level");
                        }
                    }
                }
                else
                {
                    IUser u = user;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a pick level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needpickxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentpickxp").Attributes[0].InnerText;
                            list.Add(u.Username + "'s pick level is " + node.SelectSingleNode("level/currentpicklvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Pick level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", $"sorry but {u.Username} doesn't have a pick level");
                        }
                    }
                }
                return builder;
            }
            
            public static EmbedBuilder GetCraftRank(EmbedBuilder builder, ICommandContext context, IUser user)
            {
                var list = new List<string>();
                string path = "./file/ranks/ranking.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                if (user == null)
                {
                    IUser u = context.User;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a craft level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needcraftxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentcraftxp").Attributes[0].InnerText;
                            list.Add("your craft level is " + node.SelectSingleNode("level/currentcraftlvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Craft level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", "sorry but you don't have a craft level");
                        }
                    }
                }
                else
                {
                    IUser u = user;
                    if (u.IsBot && u.Id != 372615866652557312)
                    {
                        builder.Color = Color.Red;
                        builder.AddField("Error", $"Bots don't have a craft level");
                    }
                    else
                    {
                        try
                        {
                            XmlNode node = doc.SelectSingleNode("user/ID" + u.Id.ToString());
                            string needed = node.SelectSingleNode("level/needcraftxp").Attributes[0].InnerText;
                            string Current = node.SelectSingleNode("level/currentcraftxp").Attributes[0].InnerText;
                            list.Add(u.Username + "'s craft level is " + node.SelectSingleNode("level/currentcraftlvl").Attributes[0].InnerText);
                            double precent = Math.Round(double.Parse(Current) / double.Parse(needed) * 100, 0);
                            list.Add($"<{Current}/{needed}>XP {precent}%");
                            if (precent == 0)
                                list.Add("0%(----------)100%");
                            if (precent >= 1 && precent <= 9)
                                list.Add("0%(=---------)100%");
                            if (precent >= 10 && precent <= 19)
                                list.Add("0%(==--------)100%");
                            if (precent >= 20 && precent <= 29)
                                list.Add("0%(===-------)100%");
                            if (precent >= 30 && precent <= 39)
                                list.Add("0%(====------)100%");
                            if (precent >= 40 && precent <= 49)
                                list.Add("0%(=====-----)100%");
                            if (precent >= 50 && precent <= 59)
                                list.Add("0%(======----)100%");
                            if (precent >= 60 && precent <= 69)
                                list.Add("0%(=======---)100%");
                            if (precent >= 70 && precent <= 79)
                                list.Add("0%(========--)100%");
                            if (precent >= 80 && precent <= 89)
                                list.Add("0%(=========-)100%");
                            if (precent >= 90 && precent <= 99)
                                list.Add("0%(==========)100%");
                            list.Add(" ");
                            builder.AddField("Craft level", string.Join("\n", list));
                        }
                        catch (Exception)
                        {
                            builder.Color = Color.Red;
                            builder.AddField("Error", $"sorry but {u.Username} doesn't have a craft level");
                        }
                    }
                }
                return builder;
            }

            public override string ToString()
            {
                return base.ToString();
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public class LevelUser
        {
            public ulong UserId { get; set; }
            //level
            public int CurrentXp { get; set; }
            public int NeedXp { get; set; }
            public int Currentlvl { get; set; }
            public int Nextlvl { get; set; }
            public int CurrentMineXp { get; set; }
            public int NeedMineXp { get; set; }
            public int CurrentMinelvl { get; set; }
            public int NextMinelvl { get; set; }
            public int CurrentPickXp { get; set; }
            public int NeedPickXp { get; set; }
            public int CurrentPicklvl { get; set; }
            public int NextPicklvl { get; set; }
            public int CurrentCraftXp { get; set; }
            public int NeedCraftXp { get; set; }
            public int CurrentCraftlvl { get; set; }
            public int NextCraftlvl { get; set; }
            public int Prestige { get; set; }
            public double Credits { get; set; }
            public string LastDaily { get; set; }
            //battle
            public int Healt { get; set; }
            public string Damage { get; set; }
            public double CreditMultiplier { get; set; }
            public double HealtMultiplier { get; set; }
            public double Damagemultiplier { get; set; }

            public void Load(ulong Userid)
            {
                try
                {
                    string path = $"./file/ranks/users/{Userid}.xml";
                    if (File.Exists(path))
                    {
                        UserId = Userid;
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        XmlNode level = doc.SelectSingleNode($"user/ID{Userid}/level");
                        XmlNode battle = doc.SelectSingleNode($"user/ID{Userid}/battle");
                        CurrentXp = int.Parse(level["currentxp"].Attributes[0].InnerText);
                        NeedXp = int.Parse(level["needxp"].Attributes[0].InnerText);
                        Currentlvl = int.Parse(level["currentlvl"].Attributes[0].InnerText);
                        Nextlvl = int.Parse(level["nextlvl"].Attributes[0].InnerText);
                        CurrentMineXp = int.Parse(level["currentminexp"].Attributes[0].InnerText);
                        NeedMineXp = int.Parse(level["needminexp"].Attributes[0].InnerText);
                        CurrentMinelvl = int.Parse(level["currentminelvl"].Attributes[0].InnerText);
                        NextMinelvl = int.Parse(level["nextminelvl"].Attributes[0].InnerText);
                        CurrentPickXp = int.Parse(level["currentpickxp"].Attributes[0].InnerText);
                        NeedPickXp = int.Parse(level["needpickxp"].Attributes[0].InnerText);
                        CurrentPicklvl = int.Parse(level["currentpicklvl"].Attributes[0].InnerText);
                        NextPicklvl = int.Parse(level["nextpicklvl"].Attributes[0].InnerText);
                        CurrentCraftXp = int.Parse(level["currentcraftxp"].Attributes[0].InnerText);
                        NeedCraftXp = int.Parse(level["needcraftxp"].Attributes[0].InnerText);
                        CurrentCraftlvl = int.Parse(level["currentcraftlvl"].Attributes[0].InnerText);
                        NextCraftlvl = int.Parse(level["nextcraftlvl"].Attributes[0].InnerText);
                        Prestige = int.Parse(level["prestige"].Attributes[0].InnerText);
                        Credits = double.Parse(level["credits"].Attributes[0].InnerText);
                        LastDaily = level["lastdaily"].Attributes[0].InnerText;

                        Healt = int.Parse(battle["healt"].Attributes[0].InnerText);
                        Damage = battle["damage"].Attributes[0].InnerText;
                        CreditMultiplier = double.Parse(battle["creditmult"].Attributes[0].InnerText);
                        HealtMultiplier = double.Parse(battle["healtmult"].Attributes[0].InnerText);
                        Damagemultiplier = double.Parse(battle["damagemult"].Attributes[0].InnerText);
                    }
                    else
                    {
                        throw new Exception("Couldn't find the user");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            public void Save(ulong Userid)
            {
                try
                {
                    string path = $"./file/ranks/users/{Userid}.xml";
                    if (File.Exists(path))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        XmlNode level = doc.SelectSingleNode($"user/ID{UserId}/level");
                        XmlNode battle = doc.SelectSingleNode($"user/ID{UserId}/battle");
                        level["currentxp"].Attributes[0].InnerText = CurrentXp.ToString();
                        level["needxp"].Attributes[0].InnerText = NeedXp.ToString();
                        level["currentlvl"].Attributes[0].InnerText = Currentlvl.ToString();
                        level["nextlvl"].Attributes[0].InnerText = Nextlvl.ToString();
                        level["currentminexp"].Attributes[0].InnerText = CurrentMineXp.ToString();
                        level["needminexp"].Attributes[0].InnerText = NeedMineXp.ToString();
                        level["currentminelvl"].Attributes[0].InnerText = CurrentMinelvl.ToString();
                        level["nextminelvl"].Attributes[0].InnerText = NextMinelvl.ToString();
                        level["currentpickxp"].Attributes[0].InnerText = CurrentPickXp.ToString();
                        level["needpickxp"].Attributes[0].InnerText = NeedPickXp.ToString();
                        level["currentpicklvl"].Attributes[0].InnerText = CurrentPicklvl.ToString();
                        level["nextpicklvl"].Attributes[0].InnerText = NextPicklvl.ToString();
                        level["currentcraftxp"].Attributes[0].InnerText = CurrentCraftXp.ToString();
                        level["needcraftxp"].Attributes[0].InnerText = NeedCraftXp.ToString();
                        level["currentcraftlvl"].Attributes[0].InnerText = CurrentCraftlvl.ToString();
                        level["nextcraftlvl"].Attributes[0].InnerText = NextCraftlvl.ToString();
                        level["prestige"].Attributes[0].InnerText = Prestige.ToString();
                        level["credits"].Attributes[0].InnerText = Credits.ToString();
                        level["lastdaily"].Attributes[0].InnerText = LastDaily;

                        battle["healt"].Attributes[0].InnerText = Healt.ToString();
                        battle["damage"].Attributes[0].InnerText = Damage;
                        battle["creditmult"].Attributes[0].InnerText = CreditMultiplier.ToString();
                        battle["healtmult"].Attributes[0].InnerText = HealtMultiplier.ToString();
                        battle["damagemult"].Attributes[0].InnerText = Damagemultiplier.ToString();
                        doc.Save(path);
                    }
                    else
                    {
                        throw new Exception("Couldn't find the user");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public string Daily()
            {
                if (LastDaily == (DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day))
                {
                    string timeleft = $"{23 - DateTime.Now.Hour}:{60 - DateTime.Now.Minute}:{60 - DateTime.Now.Second}";
                    return $"You already used daily today now you need to wait {TimeSpan.Parse(timeleft)} for you next daily";
                }
                else
                {
                    UserInfo user = new UserInfo(UserId);
                    user.AddDaily();
                    Credits += 100.0 * CreditMultiplier;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{DateTime.Now,-19} [{UserId}] new bal is {Credits}");
                    LastDaily = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    return $"You gained {100.0 * CreditMultiplier} now you have �{Credits}";
                }
            }

            public EmbedBuilder Give(LevelUser user1, double amount, List<IUser> UserList)
            {
                EmbedBuilder builder = new EmbedBuilder();
                if (Credits < amount)
                    builder.AddField("Not enough money", $"You don't have {amount}");
                else
                {
                    builder.Description = $"{UserList[0].Username} gave {amount} to {UserList[1].Username}";
                    builder.Color = Color.Purple;
                    builder.AddField($"{UserList[0].Username}", $"Old credits �{Credits}\n" + $"New credits �{Credits - amount}");
                    builder.AddField($"{UserList[1].Username}", $"Old credits �{user1.Credits}\n" + $"New credits �{user1.Credits + amount}");
                    Credits -= amount;
                    user1.Credits += amount;
                }
                return builder;
            }

            public async void GainXpUser(SocketMessage arg, int xp)
            {
                if (Currentlvl == 100)
                    return;
                CurrentXp += xp; //rand.Next(1, 5);
                if (CurrentXp >= NeedXp)
                {
                    //var pixel = color.Sendcolor.GetFirstUserColor(arg.Author);
                    //var usercolor = new Color(pixel.R, pixel.G, pixel.B);
                    EmbedBuilder builder = new EmbedBuilder
                    {
                        Color = Color.Gold
                    };
                    LevelUpUser(arg.Author);
                    Save(arg.Author.Id);
                    TotalLvlAdd();
                    if (Currentlvl == 100)
                        builder.AddField("Level Up", arg.Author.Username + $", you reached level **max level**");
                    else
                        builder.AddField("Level Up", arg.Author.Username + $", you reached level: **{Currentlvl}**");
                    await arg.Channel.SendMessageAsync("", false, builder.Build());
                    var message = await arg.Channel.GetMessagesAsync(1).Flatten();
                    await Task.Delay(10000);
                    await arg.Channel.DeleteMessagesAsync(message);
                }
                Save(arg.Author.Id);
                //CheckUser(path, arg.Author.Id.ToString(), levellist, battlelist, mineinv, baginv, craftlist);
            }

            public EmbedBuilder GainXpMine(EmbedBuilder builder, IUser user)
            {
                Random rand = new Random();
                CurrentMineXp += rand.Next(1, 5);
                if (CurrentMineXp >= NeedMineXp)
                {
                    LevelUpMine(user);
                    builder.AddField("Level Up", user.Username + $", you reached mine level: {CurrentMinelvl}");
                }
                Save(user.Id);
                return builder;
            }

            public EmbedBuilder GainXpPick(EmbedBuilder builder, IUser user)
            {
                Random rand = new Random();
                CurrentPickXp += rand.Next(1, 5);
                if (CurrentPickXp >= NeedPickXp)
                {
                    LevelUpPick(user);
                    builder.AddField("Level Up", user.Username + $", you reached pick level: {CurrentPicklvl}");
                }
                Save(user.Id);
                return builder;
            }

            public EmbedBuilder GainXpCraft(EmbedBuilder builder, IUser user)
            {
                Random rand = new Random();
                if (CurrentCraftXp >= NeedCraftXp)
                {
                    LevelUpCraft(user);
                    builder.AddField("Level Up", user.Username + $", you reached craft level: {CurrentCraftlvl}");
                }
                Save(user.Id);
                return builder;
            }

            public void LevelUpUser(IUser user)
            {
                Credits += 20.0 * CreditMultiplier;
                Currentlvl++;
                Nextlvl++;
                CurrentXp -= NeedXp;
                NeedXp = NewXpNeedUser(Currentlvl);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{DateTime.Now,-19} [{user.Id}] reached Level {Currentlvl}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText("./file/ranks/LevelLog.txt", $"{DateTime.Now,-19} [{user.Username}] reached Level {Currentlvl}\r\n");
            }

            public void LevelUpMine(IUser user)
            {
                CurrentMineXp -= NeedMineXp;
                NeedMineXp = NewXpNeedMine(CurrentMinelvl);
                CurrentMinelvl++;
                NextMinelvl++;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{DateTime.Now,-19} [{user.Id}] reached mine Level {CurrentMinelvl}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText("./file/ranks/LevelLog.txt", $"{DateTime.Now,-19} [{user.Username}] reached mine level {CurrentMinelvl}\r\n");
            }

            public void LevelUpPick(IUser user)
            {
                CurrentPickXp -= NeedPickXp;
                NeedPickXp = NewXpNeedPick(CurrentPicklvl);
                CurrentPicklvl++;
                NextPicklvl++;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{DateTime.Now,-19} [{user.Id}] reached pick Level {CurrentPicklvl}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText("./file/ranks/LevelLog.txt", $"{DateTime.Now,-19} [{user.Username}] reached pick Level {CurrentPicklvl}\r\n");
            }

            public void LevelUpCraft(IUser user)
            {
                CurrentCraftXp -= NeedCraftXp;
                NeedCraftXp = NewXpNeedCraft(CurrentCraftlvl);
                CurrentCraftlvl++;
                NextCraftlvl++;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{DateTime.Now,-19} [{user.Id}] reached craft Level {CurrentCraftlvl}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                File.AppendAllText("./file/ranks/LevelLog.txt", $"{DateTime.Now,-19} [{user.Username}] reached craft Level {CurrentCraftlvl}\r\n");
            }

            private int NewXpNeedUser(int curlvl)
            {
                GetNeedXp xp = new GetNeedXp(curlvl);
                if (xp.Exists)
                    return xp.LvlXp;
                else
                {
                    xp.AddLevel(curlvl);
                    return xp.LvlXp;
                }
            }

            private int NewXpNeedMine(int curlvl)
            {
                GetNeedXp xp = new GetNeedXp(curlvl);
                if (xp.Exists)
                    return xp.LvlMineXp;
                else
                {
                    xp.AddLevel(curlvl);
                    return xp.LvlMineXp;
                }
            }

            private int NewXpNeedPick(int curlvl)
            {
                GetNeedXp xp = new GetNeedXp(curlvl);
                if (xp.Exists)
                    return xp.LvlPickXp;
                else
                {
                    xp.AddLevel(curlvl);
                    return xp.LvlPickXp;
                }
            }

            private int NewXpNeedCraft(int curlvl)
            {
                GetNeedXp xp = new GetNeedXp(curlvl);
                if (xp.Exists)
                    return xp.LvlCraftXp;
                else
                {
                    xp.AddLevel(curlvl);
                    return xp.LvlCraftXp;
                }
            }

            public string AddNewUserRank(string id)
            {
                string path = "./file/ranks/users/" + id + ".xml";
                string[] roottext = { "<user>\n", "</user>" };
                string[] baginv = { "", "" };
                if (!path.Contains(".xml"))
                    return "The path is not correct";
                else
                {
                    try
                    {
                        //string newuser = $"./file/ranks/users/Id{id}.xml";
                        File.WriteAllLines(path, roottext);
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        XmlElement AddUser = doc.CreateElement("ID" + id);
                        //Create level elements
                        XmlElement info = doc.CreateElement("info");
                        XmlElement level = doc.CreateElement("level");
                        XmlElement mine = doc.CreateElement("mine");
                        XmlElement pick = doc.CreateElement("bag");
                        XmlElement battle = doc.CreateElement("battle");
                        XmlElement craft = doc.CreateElement("craft");

                        XmlElement messages = doc.CreateElement("messages");
                        XmlElement commands = doc.CreateElement("commands");
                        XmlElement Battles = doc.CreateElement("battles");
                        XmlElement Dailys = doc.CreateElement("dailys");

                        XmlElement CurrentXp = doc.CreateElement("currentxp");
                        XmlElement Needxp = doc.CreateElement("needxp");
                        XmlElement CurrentLVL = doc.CreateElement("currentlvl");
                        XmlElement Nextlvl = doc.CreateElement("nextlvl");
                        XmlElement CurrentMineXp = doc.CreateElement("currentminexp");
                        XmlElement NeedMineXp = doc.CreateElement("needminexp");
                        XmlElement CurrentMineLVL = doc.CreateElement("currentminelvl");
                        XmlElement NextMineLVL = doc.CreateElement("nextminelvl");
                        XmlElement CurrentPickXp = doc.CreateElement("currentpickxp");
                        XmlElement NeedPickXp = doc.CreateElement("needpickxp");
                        XmlElement CurrentPickLVL = doc.CreateElement("currentpicklvl");
                        XmlElement NextPickLVL = doc.CreateElement("nextpicklvl");
                        XmlElement Prestige = doc.CreateElement("prestige");
                        XmlElement Credits = doc.CreateElement("credits");
                        XmlElement lastdaily = doc.CreateElement("lastdaily");

                        //set attributes info
                        messages.SetAttribute("messages", "0");
                        commands.SetAttribute("commands", "0");
                        Battles.SetAttribute("won", "0");
                        Battles.SetAttribute("lost", "0");
                        Dailys.SetAttribute("dailys", "0");

                        //set attribute userlvl
                        CurrentXp.SetAttribute("xp", "0");
                        Needxp.SetAttribute("xp", "15");
                        CurrentLVL.SetAttribute("lvl", "1");
                        Nextlvl.SetAttribute("lvl", "2");

                        //set attribute minelvl
                        CurrentMineXp.SetAttribute("xp", "0");
                        NeedMineXp.SetAttribute("xp", "15");
                        CurrentMineLVL.SetAttribute("lvl", "1");
                        NextMineLVL.SetAttribute("lvl", "2");

                        //set attribute picklvl
                        CurrentPickXp.SetAttribute("xp", "0");
                        NeedPickXp.SetAttribute("xp", "15");
                        CurrentPickLVL.SetAttribute("lvl", "1");
                        NextPickLVL.SetAttribute("lvl", "2");

                        //set other attributes
                        Prestige.SetAttribute("prestige", "0");
                        Credits.SetAttribute("credits", "0");
                        lastdaily.SetAttribute("date", "");

                        //add info
                        info.AppendChild(messages);
                        info.AppendChild(commands);
                        info.AppendChild(Battles);
                        info.AppendChild(Dailys);

                        //add userlvl
                        level.AppendChild(CurrentXp);
                        level.AppendChild(Needxp);
                        level.AppendChild(CurrentLVL);
                        level.AppendChild(Nextlvl);

                        //add minelvl
                        level.AppendChild(CurrentMineXp);
                        level.AppendChild(NeedMineXp);
                        level.AppendChild(CurrentMineLVL);
                        level.AppendChild(NextMineLVL);

                        //add picklvl
                        level.AppendChild(CurrentPickXp);
                        level.AppendChild(NeedPickXp);
                        level.AppendChild(CurrentPickLVL);
                        level.AppendChild(NextPickLVL);

                        //add other things
                        level.AppendChild(Prestige);
                        level.AppendChild(Credits);
                        level.AppendChild(lastdaily);

                        XmlNode root = doc.SelectSingleNode("user");
                        AddUser.AppendChild(info);
                        AddUser.AppendChild(level);
                        AddUser.AppendChild(battle);
                        AddUser.AppendChild(mine);
                        AddUser.AppendChild(pick);
                        AddUser.AppendChild(craft);
                        root.AppendChild(AddUser);
                        //int total = int.Parse(doc.SelectSingleNode("root/bank/totalUsers").Attributes[0].InnerText);
                        //doc.SelectSingleNode("root/bank/totalUsers").Attributes[0].InnerText = (total + 1).ToString();
                        doc.Save(path);
                        return $"{DateTime.Now,-19} User {id} has been Added to the level database";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message.ToString();
                    }
                }
            }

            private static void TotalLvlAdd()
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("./file/commandsused.xml");
                string number = xDoc.SelectSingleNode("root/totallevels").InnerText;
                xDoc.SelectSingleNode("root/totallevels").InnerText = (int.Parse(number) + 1).ToString();
                xDoc.Save("./file/commandsused.xml");
            }
        }

        public class UserInfo
        {
            private ulong Id { get; set; }
            public long Messages { get; set; }
            public long Commands { get; set; }
            public int Wins { get; }
            public int Lost { get; }
            public int Dailys { get; set; }

            public UserInfo(ulong userid)
            {
                Id = userid;
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{userid}.xml");
                XmlNode info = doc.SelectSingleNode($"user/ID{userid}/info");
                Messages = long.Parse(info["messages"].Attributes[0].InnerText);
                Commands = long.Parse(info["commands"].Attributes[0].InnerText);
                Wins = int.Parse(info["battles"].Attributes[0].InnerText);
                Lost = int.Parse(info["battles"].Attributes[1].InnerText);
                Dailys = int.Parse(info["dailys"].Attributes[0].InnerText);
            }

            public void AddMessage()
            {
                Messages++;
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{Id}.xml");
                XmlNode info = doc.SelectSingleNode($"user/ID{Id}/info");
                info["messages"].Attributes[0].InnerText = Messages.ToString();
                doc.Save($"./file/ranks/users/{Id}.xml");
            }

            public void AddCommand()
            {
                Commands++;
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{Id}.xml");
                XmlNode info = doc.SelectSingleNode($"user/ID{Id}/info");
                info["commands"].Attributes[0].InnerText = Commands.ToString();
                doc.Save($"./file/ranks/users/{Id}.xml");
            }

            public void AddDaily()
            {
                Dailys++;
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{Id}.xml");
                XmlNode info = doc.SelectSingleNode($"user/ID{Id}/info");
                info["dailys"].Attributes[0].InnerText = Dailys.ToString();
                doc.Save($"./file/ranks/users/{Id}.xml");
            }
        }

        internal class GetNeedXp
        {
            public bool Exists { get; }
            public int LvlXp { get; set; }
            public int LvlMineXp { get; set; }
            public int LvlPickXp { get; set; }
            public int LvlCraftXp { get; set; }

            public GetNeedXp(int needlvl)
            {
                try
                {
                    string path = "./file/ranks/levelxp.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    if (doc.GetElementsByTagName($"lvl{needlvl}").Count > 0)
                    {
                        XmlNode lvl = doc.SelectSingleNode($"root/lvl{needlvl}");
                        LvlXp = int.Parse(lvl.InnerText.Split('-')[0]);
                        LvlMineXp = int.Parse(lvl.InnerText.Split('-')[1]);
                        LvlPickXp = int.Parse(lvl.InnerText.Split('-')[2]);
                        LvlCraftXp = int.Parse(lvl.InnerText.Split('-')[3]);
                        Exists = true;
                    }
                    else
                    {
                        Exists = false;
                    }
                }
                catch (Exception ex)
                {
                    //Exists = false;
                    Console.WriteLine(ex.ToString());
                }
            }

            public void AddLevel(int needlvl)
            {
                Random rand = new Random();
                string path = "./file/ranks/levelxp.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlElement lvl = doc.CreateElement($"lvl{needlvl}");
                string[] prev = doc.SelectSingleNode($"root/lvl{needlvl - 1}").InnerText.Split('-');
                string newxp = $"{int.Parse(prev[0]) + rand.Next(10, 24)}-{int.Parse(prev[1]) + rand.Next(10, 24)}-{int.Parse(prev[2]) + rand.Next(10, 24)}-{int.Parse(prev[3]) + rand.Next(10, 24)}";
                lvl.InnerText = newxp;
                doc.SelectSingleNode("root").AppendChild(lvl);
                doc.Save(path);
                LvlXp = int.Parse(newxp.Split('-')[0]);
                LvlMineXp = int.Parse(newxp.Split('-')[1]);
                LvlPickXp = int.Parse(newxp.Split('-')[2]);
                LvlCraftXp = int.Parse(newxp.Split('-')[3]);
            }
        }
    }
}
