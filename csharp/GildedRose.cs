using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }


        //I divided the method into a several different methods for each individual item
        //So its easier to read and understand the code 
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {              
                //Splitting the string because its not specified that all items will have exact same names
                string[] name = Items[i].Name.Split(' ');
                string firstTwoNameWords = "";
                if (name.Length > 1)
                {
                    firstTwoNameWords = name[0] + " " + name[1];

                }

                if (firstTwoNameWords == "Aged Brie")
                {
                    AgedBrieUpdate(i);
                }
                else if(firstTwoNameWords == "Backstage passes")
                {
                    BackstagePassesUpdate(i);
                }
                else if(name[0] == "Sulfuras,")
                {
                    SulfurasUpdate(i);
                }
                else if (name[0] == "Conjured")
                {
                    ConjuredUpdate(i);
                }
                else
                {
                    NonSpecifiedItemsUpdate(i, 1);
                }

            }
        }


        private void SulfurasUpdate(int i)
        {
            Items[i].SellIn--;
        }


        //Method that updates Aged Brie items
        private void AgedBrieUpdate(int i)
        {
            if(Items[i].Quality < 50)
            {
                switch(Items[i].SellIn > 0)
                {
                    case true:
                        Items[i].Quality++;
                        break;
                    case false:
                        Items[i].Quality = Items[i].Quality + 2;
                        break;
                }

                if(Items[i].Quality > 50)
                {
                    Items[i].Quality = 50;
                }
            }

            Items[i].SellIn--;
        }

        //Method that updates Backstage Passes items
        private void BackstagePassesUpdate(int i)
        {
            if (Items[i].SellIn > 0)
            {
                if (Items[i].Quality < 50)
                {
                    if (Items[i].SellIn <= 10 && Items[i].SellIn > 5)
                    {
                        Items[i].Quality = Items[i].Quality + 2;
                    }
                    else if (Items[i].SellIn <= 5 && Items[i].SellIn >= 0)
                    {
                        Items[i].Quality = Items[i].Quality + 3;
                    }
                    else
                    {
                        Items[i].Quality++;
                    }

                    if (Items[i].Quality > 50)
                    {
                        Items[i].Quality = 50;
                    }
                }
                
            }
            else
            {
                Items[i].Quality = Items[i].Quality - Items[i].Quality;
            }

            Items[i].SellIn--;
        }


        //Because Conjured degrade basically the same as non specified items, just twice as fast,
        //I will pass the multiplier value and use the same method
        private void ConjuredUpdate(int i)
        {           
            int multiplier = 2;
            NonSpecifiedItemsUpdate(i, multiplier);
        }
        
        private void NonSpecifiedItemsUpdate(int i, int multiplier)
        {
            if (Items[i].SellIn > 0)
            {
                if (Items[i].Quality > 0)
                {
                    Items[i].Quality = Items[i].Quality - 1 * multiplier;
                }

                //This check here is required for Conjured Items
                if (Items[i].Quality < 0)
                {
                    Items[i].Quality = 0;
                }
            }
            else
            {
                if (Items[i].Quality > 0)
                {
                    Items[i].Quality = Items[i].Quality - 2 * multiplier;
                }

                if (Items[i].Quality < 0)
                {
                    Items[i].Quality = 0;
                }
            }

            Items[i].SellIn--;
        }






    } 
}
