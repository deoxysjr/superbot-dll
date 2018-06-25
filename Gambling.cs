using Discord;
using SuperBotDLL1_0.RankingSystem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace SuperBotDLL1_0
{
    namespace Gambling
    {
        public class Gamble
        {
            public static EmbedBuilder Roll(IUser id, int max, int guess, double bid, int times)
            {
                EmbedBuilder builder = new EmbedBuilder
                {
                    Color = Color.Teal
                };
                LevelUser user = new LevelUser();
                user.Load(id.Id);
                Random rand = new Random();
                //var list = new List<int>();
                for (int i = 0; i < times; i++)
                {
                    int number = rand.Next(1, max + 1);
                    //list.Add(number);
                    if (number == guess)
                    {
                        double bonus = (1.0 + (double.Parse(max.ToString()) - 1.0) / 10.0);
                        user.Credits += (double.Parse(bid.ToString()) * bonus * user.CreditMultiplier);
                        builder.AddField("You win", $"You were right is was {guess}\n" + $"here you have your �{double.Parse(bid.ToString()) * bonus * user.CreditMultiplier} credits *I added a little bonus for you*");
                    }
                    else
                    {
                        user.Credits -= bid;
                        builder.AddField("You lose", $"The number was {number} not {guess} dummy");
                    }
                }
                user.Save(id.Id);
                return builder;
            }

            public static EmbedBuilder Slot(LevelUser user, double amount)
            {
                EmbedBuilder builder = new EmbedBuilder();
                Random rand = new Random();
                int[] y1 = { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
                int[] y2 = { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
                int[] y3 = { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
                int[][] array = { y1, y2, y3 };

                builder.AddField("Result", "{" + array[0][0] + "} {" + array[0][1] + "} {" + array[0][2] + "}\n" 
                                         + "{" + array[1][0] + "} {" + array[1][1] + "} {" + array[1][2] + "}\n"
                                         + "{" + array[2][0] + "} {" + array[2][1] + "} {" + array[2][2] + "}");
                bool win = false;
                var list = new List<string>();
                double total = 0.0;
                if(array[0][0] == array[0][1] && array[0][0] == array[0][2])
                {
                    win = true;
                    double multi = 1.0 + ((double)array[0][0] / 2.0);
                    total += amount * multi * user.CreditMultiplier;
                    list.Add($"You have gained �{amount * multi * user.CreditMultiplier}");
                }
                if (array[1][0] == array[1][1] && array[1][0] == array[1][2])
                {
                    win = true;
                    double multi = 1.0 + ((double)array[1][0] / 2.0);
                    total += amount * multi * user.CreditMultiplier;
                    list.Add($"You have gained �{amount * multi * user.CreditMultiplier}");
                }
                if (array[2][0] == array[2][1] && array[2][0] == array[2][2])
                {
                    win = true;
                    double multi = 1.0 + ((double)array[2][0] / 2.0);
                    total += amount * multi * user.CreditMultiplier;
                    list.Add($"You have gained �{amount * multi * user.CreditMultiplier}");
                }
                if (array[0][0] == array[1][1] && array[0][0] == array[2][2])
                {
                    win = true;
                    double multi = 1.0 + ((double)array[0][0] / 2.0);
                    total += amount * multi * user.CreditMultiplier;
                    list.Add($"You have gained �{amount * multi * user.CreditMultiplier}");
                }
                if (array[2][0] == array[1][1] && array[2][0] == array[0][2])
                {
                    win = true;
                    double multi = 1.0 + ((double)array[0][0] / 2.0);
                    total += amount * multi * user.CreditMultiplier;
                    list.Add($"You have gained �{amount * multi * user.CreditMultiplier}");
                }
                if (win)
                {
                    builder.AddField("Wins", string.Join("\n", list));
                    builder.AddField("Credits", $"you have gained a total of �{total}");
                    user.Credits += total;
                }
                else
                {
                    user.Credits -= amount;
                    builder.AddField("Lost", $"You now have �{user.Credits}");
                }
                return builder;
            }
        }

        public class Races
        {
            public static async Task<string> CreateRaceAsync(string guildid, string racers)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("./file/Horseraces.xml");
                    try
                    {
                        string Race = doc.SelectSingleNode($"races/race[@guildid='{guildid}']").Name;
                    }
                    catch (Exception)
                    {
                        XmlElement race = doc.CreateElement("race");
                        XmlElement users = doc.CreateElement("users");
                        string id = await GetRaceIdAsync(guildid, doc);
                        race.SetAttribute("Id", id);
                        race.SetAttribute("racers", racers);
                        race.SetAttribute("started", "false");
                        race.SetAttribute("guildid", guildid);
                        race.AppendChild(users);
                        doc["races"].AppendChild(race);
                        doc.Save("./file/Horseraces.xml");
                        return $"Race created with id:``{id}`` you can enter the race by doing %horserace join";
                    }
                    return "There is already a race created";
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return $"```{ex.ToString()}```";
                }
            }

            public static string JoinRace(string guildid, string userid, double bid, int horse)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("./file/Horseraces.xml");
                try
                {
                    XmlNodeList races = doc.SelectNodes("//race[@guildid=\"" + guildid + "\"]");
                    if (races.Count > 0)
                    {
                        if (int.Parse(races[0].Attributes["racers"].InnerText) < horse)
                            return $"There are only {races[0].Attributes["racers"].InnerText} racers";
                        XmlNode users = races[0].SelectSingleNode("users");
                        XmlNodeList getuser = users.SelectNodes($"user[@Id='{userid}']");
                        if (getuser.Count > 0)
                        {
                            return "you are already in this match";
                        }
                        else
                        {
                            XmlElement user = doc.CreateElement("user");
                            user.SetAttribute("Id", userid);
                            user.SetAttribute("bid", bid.ToString());
                            user.SetAttribute("horse", horse.ToString());
                            users.AppendChild(user);
                            doc.Save("./file/Horseraces.xml");
                            return "You have been added to the race";
                        }
                    }
                    else
                    {
                        return "Please create a race first";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return $"```{ex.ToString()}```";
                }
            }

            private static async Task<string> GetRaceIdAsync(string guildid, XmlDocument doc)
            {
                int id;
                bool worked = false;
                try
                {
                    string test = doc.SelectSingleNode($"races/ids/guild[@Id='{guildid}']").Name;
                    await Task.Delay(10);
                    worked = true;
                }
                catch (Exception)
                {
                    XmlElement createid = doc.CreateElement("guild");
                    createid.SetAttribute("Id", guildid);
                    createid.SetAttribute("curid", "1");
                    doc["races"]["ids"].AppendChild(createid);
                }
                if (worked == true)
                {
                    id = int.Parse(doc.SelectSingleNode($"races/ids/guild[@Id='{guildid}']").Attributes["curid"].InnerText);
                    id++;
                    doc.SelectSingleNode($"races/ids/guild[@Id='{guildid}']").Attributes["curid"].InnerText = id.ToString();
                    doc.Save("./file/Horseraces.xml");
                    return id.ToString();
                }
                else
                {
                    return "1";
                }
            }
        }
    }
}
