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

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {


                string[] name = Items[i].Name.Split(' ');
                string firstTwoNameWords = name[0] + " " + name[1];

                if (firstTwoNameWords == "Aged Brie")
                {
                    AgedBrieUpdate(i);
                }
                else if(firstTwoNameWords == "Backstage passes")
                {
                    BackstagePassesUpdate(i);
                }




            }
        }

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


    } 
}
