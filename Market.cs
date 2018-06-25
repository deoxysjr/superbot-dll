using Discord;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SuperBotDLL1_0
{
    namespace MarketPlace
    {
        public class Marketplace
        {
            public static EmbedBuilder Sell(EmbedBuilder builder, string userid, string item, string amount, Dictionary<string, int> mineprice, Dictionary<string, int> pickprice, Dictionary<string, int> craftprice)
            {
                string path = $"./file/ranks/users/{userid}.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode user = doc.SelectSingleNode($"user/ID{userid}/level");
                XmlNode mine = doc.SelectSingleNode($"user/ID{userid}/mine");
                XmlNode pick = doc.SelectSingleNode($"user/ID{userid}/bag");
                XmlNode craft = doc.SelectSingleNode($"user/ID{userid}/craft");
                if (amount != null)
                {
                    if (mineprice.ContainsKey(item))
                    {
                        int itemcount = int.Parse(mine.SelectSingleNode(item).Attributes[0].InnerText);
                        if (itemcount > 0 && int.Parse(amount) <= itemcount)
                        {
                            int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                            int worth = mineprice[item] * int.Parse(amount);
                            mine.SelectSingleNode(item).Attributes[0].InnerText = (itemcount - int.Parse(amount)).ToString();
                            user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                            doc.Save(path);
                            builder.AddField("Sell", $"You sold {item}, {amount} for �{worth}");
                        }
                    }
                    else if (pickprice.ContainsKey(item))
                    {
                        int itemcount = int.Parse(pick.SelectSingleNode(item).Attributes[0].InnerText);
                        if (itemcount > 0 && int.Parse(amount) <= itemcount)
                        {
                            int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                            int worth = mineprice[item] * int.Parse(amount);
                            pick.SelectSingleNode(item).Attributes[0].InnerText = (itemcount - int.Parse(amount)).ToString();
                            user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                            doc.Save(path);
                            builder.AddField("Sell", $"You sold {item}, {amount} for �{worth}");
                        }
                    }
                    else if (craftprice.ContainsKey(item))
                    {
                        int itemcount = int.Parse(craft.SelectSingleNode(item).Attributes[0].InnerText);
                        if (itemcount > 0 && int.Parse(amount) <= itemcount)
                        {
                            int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                            int worth = mineprice[item] * int.Parse(amount);
                            craft.SelectSingleNode(item).Attributes[0].InnerText = (itemcount - int.Parse(amount)).ToString();
                            user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                            doc.Save(path);
                            builder.AddField("Sell", $"You sold {item}, {amount} for �{worth}");
                        }
                    }
                    else
                    {
                        builder.AddField("Item not found", $"superbot does not contain {item}");
                    }
                    //if (item == "stone")
                    //{
                    //    int itemcount = int.Parse(mine.SelectSingleNode(item).Attributes[0].InnerText);
                    //    if (itemcount > 0 && int.Parse(amount) <= itemcount)
                    //    {
                    //        int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                    //        int worth = mineprice[item] * int.Parse(amount);
                    //        mine.SelectSingleNode(item).Attributes[0].InnerText = (itemcount - int.Parse(amount)).ToString();
                    //        user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                    //        doc.Save("./file/ranks/ranking.xml");
                    //    }
                    //}
                    //else if (item == "goldore")
                    //{

                    //}
                    //else if (item == "ironore")
                    //{

                    //}
                    //else if (item == "gem")
                    //{

                    //}
                    //else if (item == "coal")
                    //{

                    //}
                    //else if (item == "oil")
                    //{

                    //}
                    //else if (item == "sand")
                    //{

                    //}
                    //else if (item == "apple")
                    //{

                    //}
                    //else if (item == "avocado")
                    //{

                    //}
                    //else if (item == "banana")
                    //{

                    //}
                    //else if (item == "carrot")
                    //{

                    //}
                    //else if (item == "cherries")
                    //{

                    //}
                    //else if (item == "chillies")
                    //{

                    //}
                    //else if (item == "corn")
                    //{

                    //}
                    //else if (item == "cucumber")
                    //{

                    //}
                    //else if (item == "eggplant")
                    //{

                    //}
                    //else if (item == "egg")
                    //{

                    //}
                    //else if (item == "grain")
                    //{

                    //}
                    //else if (item == "grape")
                    //{

                    //}
                    //else if (item == "kiwi")
                    //{

                    //}
                    //else if (item == "lemon")
                    //{

                    //}
                    //else if (item == "melon")
                    //{

                    //}
                    //else if (item == "milk")
                    //{

                    //}
                    //else if (item == "orange")
                    //{

                    //}
                    //else if (item == "peach")
                    //{

                    //}
                    //else if (item == "peanuts")
                    //{

                    //}
                    //else if (item == "pear")
                    //{

                    //}
                    //else if (item == "pineapple")
                    //{

                    //}
                    //else if (item == "potato")
                    //{

                    //}
                    //else if (item == "strawberry")
                    //{

                    //}
                    //else if (item == "sugarcane")
                    //{

                    //}
                    //else if (item == "tomato")
                    //{

                    //}
                    //else if (item == "gold")
                    //{

                    //}
                    //else if (item == "iron")
                    //{

                    //}
                    //else if (item == "ring")
                    //{

                    //}
                    //else if (item == "crown")
                    //{

                    //}
                    //else if (item == "bakedegg")
                    //{

                    //}
                    //else if (item == "flour")
                    //{

                    //}
                    //else if (item == "sugar")
                    //{

                    //}
                    //else if (item == "glass")
                    //{

                    //}
                    //else if (item == "refinedoil")
                    //{

                    //}
                }
                else
                {
                    if (item == "all")
                    {
                        var minelist = new List<string>();
                        var picklist = new List<string>();
                        var craftlist = new List<string>();
                        int mineamount = 0;
                        int pickamount = 0;
                        int craftamount = 0;
                        ulong totalsold = 0;
                        foreach (XmlNode ite in mine)
                        {
                            int itemcount = int.Parse(mine.SelectSingleNode(ite.Name).Attributes[0].InnerText);
                            if (itemcount > 0)
                            {
                                mineamount += itemcount;
                                int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                                int worth = mineprice[ite.Name] * itemcount;
                                mine.SelectSingleNode(ite.Name).Attributes[0].InnerText = (0).ToString();
                                user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                                doc.Save(path);
                                minelist.Add($"You sold **{ite.Name}**, {itemcount} for �{worth}");
                                totalsold += ulong.Parse(worth.ToString());
                            }
                        }

                        foreach (XmlNode ite in pick)
                        {
                            
                            int itemcount = int.Parse(pick.SelectSingleNode(ite.Name).Attributes[0].InnerText);
                            if (itemcount > 0)
                            {
                                pickamount += itemcount;
                                int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                                int worth = pickprice[ite.Name] * itemcount;
                                pick.SelectSingleNode(ite.Name).Attributes[0].InnerText = (0).ToString();
                                user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                                doc.Save(path);
                                picklist.Add($"You sold **{ite.Name}**, {itemcount} for �{worth}");
                                totalsold += ulong.Parse(worth.ToString());
                            }
                        }

                        foreach (XmlNode ite in craft)
                        {
                            int itemcount = int.Parse(craft.SelectSingleNode(ite.Name).Attributes[0].InnerText);
                            if (itemcount > 0)
                            {
                                craftamount += itemcount;
                                int curcred = int.Parse(user.SelectSingleNode("credits").Attributes[0].InnerText);
                                int worth = craftprice[ite.Name] * itemcount;
                                craft.SelectSingleNode(ite.Name).Attributes[0].InnerText = (0).ToString();
                                user.SelectSingleNode("credits").Attributes[0].InnerText = (curcred + worth).ToString();
                                doc.Save(path);
                                craftlist.Add($"You sold **{ite.Name}**, {itemcount} for �{worth}");
                                totalsold += ulong.Parse(worth.ToString());
                            }
                        }

                        if (minelist.Count > 0)
                            builder.AddInlineField($"Mine {mineamount}", string.Join("\n", minelist));
                        if (picklist.Count > 0)
                            builder.AddInlineField($"Pick {pickamount}", string.Join("\n", picklist));
                        if (craftlist.Count > 0)
                            builder.AddInlineField($"Craft {craftamount}", string.Join("\n", craftlist));
                        if (minelist.Count != 0 || picklist.Count != 0 || craftlist.Count != 0)
                            builder.AddField("Total sold", $"You total worth was �{totalsold}");

                        if (minelist.Count == 0 && picklist.Count == 0 && craftlist.Count == 0)
                            builder.AddField("Item's not found", $"You don't have item's to sell\nmine {minelist.Count}\npick {picklist.Count}\ncraft {craftlist.Count}");
                    }
                }
                return builder;
            }
        }
    }
}
