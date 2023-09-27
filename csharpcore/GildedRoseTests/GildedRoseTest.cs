using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

[TestFixture]
public class GildedRoseTest
{
	[Test]
	public void Foo()
	{
		IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
		GildedRose app = new GildedRose(items);
		app.UpdateQuality();
		Assert.AreEqual("foo", items[0].Name);
	}

	[Test]
	public void UpdateQuality_GivenItem_QualityAndSellInDecreaseByOne()
	{
		// Arrange
		IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(0, items[0].SellIn);
		Assert.AreEqual(0, items[0].Quality);

	}

	[Test]
	public void UpdateQuality_WhenSellInIsLessThanOne_QualityDecreasesByTwo()
	{
		// Arrange
		IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 4 } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(2, items[0].Quality);

	}

	[Test]
	public void UpdateQuality_WhenQualityIsZero_QualityIsNeverNegative()
	{
		// Arrange
		IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(0, items[0].Quality);
	}

	[Test]
	public void UpdateQuality_WhenNameIsAgedBrie_QualityIncreasesByOne()
	{
		// Arrange
		var startQuality = 3;
		var resultQuality = 4;
		IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = startQuality } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(resultQuality, items[0].Quality);
	}

	[Test]
	public void UpdateQuality_WhenItemAgedBrieQualityIsFifty_QualityDoesNotIncrease()
	{
		// Arrange
		IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(50, items[0].Quality);
	}

	[Test]
	public void UpdateQuality_WhenNameIsSulfuras_QualityAndSellInDoesNotDecrease()
	{
		// Arrange
		var initialQuality = 10;
		var initialSellIn = 1;
		IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = initialSellIn, Quality = initialQuality } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(initialQuality, items[0].Quality);
		Assert.AreEqual(initialSellIn, items[0].SellIn);
	}

	[Test]
	public void UpdateQuality_WhenBackstagePassesSellInIsMoreThanTen_QualityIncreasesByOne()
	{
		// Arrange
		var initialQuality = 10;
		var initialSellIn = 15;
		var expectedQuality = 11;
		var itemName = "Backstage passes to a TAFKAL80ETC concert";

		IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(expectedQuality, items[0].Quality);
	}

	[Test]
	public void UpdateQuality_WhenBackstagePassesSellInIsTenOrLessAndMoreThanFive_QualityIncreasesByTwo()
	{
		// Arrange
		var initialQuality = 10;
		var initialSellIn = 9;
		var expectedQuality = 12;
		var itemName = "Backstage passes to a TAFKAL80ETC concert";

		IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(expectedQuality, items[0].Quality);
	}

	[Test]
	public void UpdateQuality_WhenBackstagePassesSellInIsFiveOrLessAndMoreThanZero_QualityIncreasesByThree()
	{
		// Arrange
		var initialQuality = 10;
		var initialSellIn = 5;
		var expectedQuality = 13;
		var itemName = "Backstage passes to a TAFKAL80ETC concert";

		IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = initialSellIn, Quality = initialQuality } };
		GildedRose app = new GildedRose(items);

		// Act
		app.UpdateQuality();

		// Assert
		Assert.AreEqual(expectedQuality, items[0].Quality);
	}
}