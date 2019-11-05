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
                
                if (Items[i].Name == "Aged Brie")
                {
                    AgedBrieUpdate(i);
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
            }

            Items[i].SellIn--;
        }


    } 
}
