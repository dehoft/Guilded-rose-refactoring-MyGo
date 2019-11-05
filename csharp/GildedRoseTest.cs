using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        [TestCase("Aged Brie", 2, 6)]       
        public void AgedBriePositiveSellInnTest(string name, int sellInn, int quality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellInn,
                    Quality = quality
                }
            };            
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(quality + 1, Items[0].Quality);                    
        }

        [Test]
        [TestCase("Aged Brie", -2, 6)]
        public void AgedBrieNegativeSellInnTest(string name, int sellInn, int quality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellInn,
                    Quality = quality
                }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(quality + 2, Items[0].Quality);
        }

        [Test]
        [TestCase("Aged Brie", 2, 50)]
        public void AgedBriePositiveSellInnMaxQualityTest(string name, int sellInn, int quality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellInn,
                    Quality = quality
                }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(quality, Items[0].Quality);
        }

        [Test]
        [TestCase("Aged Brie", -2, 50)]
        public void AgedBrieNegativeSellInnMaxQualityTest(string name, int sellInn, int quality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellInn,
                    Quality = quality
                }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(quality, Items[0].Quality);
        }

    }
}
