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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 2, 50)]
        public void BackstagePassesPositiveSellInnMaxQualityTest(string name, int sellInn, int quality)
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", -2, 50)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 0, 50)]
        public void BackstagePassesQualityDropTest(string name, int sellInn, int quality)
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

            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20)]

        public void BackstagePassesQualityIncreaseTest(string name, int sellInn, int quality)
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 20)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 7, 20)]
        public void BackstagePassesDoubleQualityIncreaseTest(string name, int sellInn, int quality)
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 20)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 3, 20)]
        public void BackstagePassesTripleQualityIncreaseTest(string name, int sellInn, int quality)
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

            Assert.AreEqual(quality + 3, Items[0].Quality);
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("+5 Dexterity Vest", 9, 20, 1)]
        [TestCase("Elixir of the Mongoose", 3, 15, 1)]
        [TestCase("Conjured Mana Cake", 9, 21, 2)]
        [TestCase("Conjured Mana Cake", 3, 20, 2)]
        public void ConjuredAndNonSpecifiedQualityDecreaseTest(string name, int sellInn, int quality, int multiplier)
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

            Assert.AreEqual(quality - 1 * multiplier, Items[0].Quality);
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("+5 Dexterity Vest", 0, 20, 1)]
        [TestCase("Elixir of the Mongoose", -2, 15, 1)]
        [TestCase("Conjured Mana Cake", -2, 21, 2)]
        [TestCase("Conjured Mana Cake", 0, 21, 2)]
        public void ConjuredAndNonSpecifiedQualityDoubleDecreaseTest(string name, int sellInn, int quality, int multiplier)
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

            Assert.AreEqual(quality - 2 * multiplier, Items[0].Quality);
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("+5 Dexterity Vest", 0, 1)]
        [TestCase("Elixir of the Mongoose", -2, 1)]
        [TestCase("Conjured Mana Cake", -2, 1)]
        [TestCase("Conjured Mana Cake", 0, 4)]
        public void ConjuredAndNonSpecifiedQualityDecreaseToMinQualityTest(string name, int sellInn, int quality)
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

            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [Test]
        [TestCase("+5 Dexterity Vest", 0, 0)]
        [TestCase("Elixir of the Mongoose", -2, 0)]
        [TestCase("Elixir of the Mongoose", 5, 0)]
        [TestCase("Conjured Mana Cake", 15, 0)]
        public void ConjuredAndNonSpecifiedWorstQualityTest(string name, int sellInn, int quality)
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }

        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80)]        
        public void SulfurasTest(string name, int sellInn, int quality)
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
            Assert.AreEqual(sellInn - 1, Items[0].SellIn);
        }



        [Test]
        public void MultipleElementsUpdateQualityTest()
        {
            IList<Item> Items = new List<Item>{
                new Item
                {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                },              
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },             
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 21
                }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();


            Assert.AreEqual(19, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);

            Assert.AreEqual(1, Items[1].Quality);
            Assert.AreEqual(1, Items[1].SellIn);

            Assert.AreEqual(80, Items[2].Quality);
            Assert.AreEqual(-1, Items[2].SellIn);

            Assert.AreEqual(21, Items[3].Quality);
            Assert.AreEqual(14, Items[3].SellIn);

            Assert.AreEqual(19, Items[4].Quality);
            Assert.AreEqual(2, Items[4].SellIn);

        }



    }
}
