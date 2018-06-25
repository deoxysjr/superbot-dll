using Discord;
using SuperBotDLL1_0.RankingSystem;
using System.Xml;

namespace SuperBotDLL1_0
{
    namespace BattleSystem
    {
        public class BattleSystem
        {
            public static EmbedBuilder Upgrade(string type, LevelUser user)
            {
                EmbedBuilder builder = new EmbedBuilder();
                if(type == "")
                {
                    builder.AddField("These are the things you can upgrade", "**Damage multi:** damage\n" + "**Health multi:** health\n" + "**Credits multi:** credits");
                }
                else if (type.ToLower() == "damage")
                {
                    double upnum = 0;
                    if (user.Damagemultiplier == 1.0)
                        upnum = 0;
                    else
                    {
                        upnum = (user.Damagemultiplier - 1.0) / 0.05;
                    }
                    if (upnum == 20)
                        builder.AddField("Can't upgrade that", "You have the highest upgrade available");
                    else if (user.Credits < 10000.0 * (upnum + 1.0))
                    {
                        builder.AddField("You don't have enough credits", $"You need {10000.0 * (upnum + 1.0)} too upgrade this");
                    }
                    else
                    {
                        user.Credits -= 10000.0 * (upnum + 1.0);
                        user.Damagemultiplier += 0.05;
                        builder.AddField("Upgrade complete", $"You now have a {user.Damagemultiplier}x");
                    }
                }
                else if (type.ToLower() == "health")
                {
                    double upnum = 0;
                    if (user.Damagemultiplier == 1.0)
                        upnum = 0;
                    else
                    {
                        upnum = (user.HealtMultiplier - 1.0) / 0.05;
                    }
                    if (upnum == 20)
                        builder.AddField("Can't upgrade that", "You have the highest upgrade available");
                    else if (user.Credits < 10000.0 * (upnum + 1.0))
                    {
                        builder.AddField("You don't have enough credits", $"You need {10000.0 * (upnum + 1.0)} too upgrade this");
                    }
                    else
                    {
                        user.Credits -= 10000.0 * (upnum + 1.0);
                        user.HealtMultiplier += 0.05;
                        builder.AddField("Upgrade complete", $"You now have a {user.HealtMultiplier}x");
                    }
                }
                else if (type.ToLower() == "credits")
                {
                    double upnum = 0;
                    if (user.Damagemultiplier == 1.0)
                        upnum = 0;
                    else
                    {
                        upnum = (user.CreditMultiplier - 1.0) / 0.05;
                    }
                    if (upnum == 20)
                        builder.AddField("Can't upgrade that", "You have the highest upgrade available");
                    else if (user.Credits < 10000.0 * (upnum + 1.0))
                    {
                        builder.AddField("You don't have enough credits", $"You need {10000.0 * (upnum + 1.0)} too upgrade this");
                    }
                    else
                    {
                        user.Credits -= 10000.0 * (upnum + 1.0);
                        user.CreditMultiplier += 0.05;
                        builder.AddField("Upgrade complete", $"You now have a {user.CreditMultiplier}x");
                    }
                }
                else
                {
                    builder.AddField("I have this problem", $"I can't find {type.ToLower()}");
                }

                return builder;
            }
        }

        public class BattleUser
        {
            public double Healt { get; set; }
            public string[] Damage { get; }
            public double DamageMultiplier { get; }
            public int Wins { get; set; }
            public int Lost { get; set; }
            public string Id { get; }
            public BattleUser(ulong id)
            {
                Id = id.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{id}.xml");
                XmlNode root = doc.SelectSingleNode($"user/ID{id}");
                Healt = double.Parse(root.SelectSingleNode("battle/healt").Attributes[0].InnerText) * double.Parse(root.SelectSingleNode("battle/healtmult").Attributes[0].InnerText);
                Damage = root.SelectSingleNode("battle/damage").Attributes[0].InnerText.Split('-');
                //HealtMultiplier = double.Parse(root.SelectSingleNode($"ID{id}/battle/healtmult").Attributes[0].InnerText);
                DamageMultiplier = double.Parse(root.SelectSingleNode("battle/damagemult").Attributes[0].InnerText);
                //Wins = int.Parse(root["info/battles"].Attributes[0].InnerText);
                //Lost = int.Parse(root["info/battles"].Attributes[1].InnerText);
            }

            public void AddWin()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{Id}.xml");
                XmlNode root = doc.SelectSingleNode($"user/ID{Id}");
                Wins += 1;
                root["info/battles"].Attributes[0].InnerText = Wins.ToString();
                doc.Save($"./file/ranks/users/{Id}.xml");
            }

            public void AddLoss()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($"./file/ranks/users/{Id}.xml");
                XmlNode root = doc.SelectSingleNode($"user/ID{Id}");
                Lost += 1;
                root["info/battles"].Attributes[1].InnerText = Lost.ToString();
                doc.Save($"./file/ranks/users/{Id}.xml");
            }
        }

        public class BattleInfo
        {
            public int Totalturs { get; set; }
            public double TotalDamage { get; set; }
            public BattleInfo()
            {
                Totalturs = 0;
                TotalDamage = 0.0;
            }

            public void Addturn()
            {
                Totalturs++;
            }

            public void AddDamage(double damage)
            {
                TotalDamage += damage;
            }
        }
    }
}
