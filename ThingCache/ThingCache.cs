using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;

namespace MockFramework
{
	public class ThingCache
	{
		private readonly IDictionary<string, Thing> dictionary
			= new Dictionary<string, Thing>();
		private readonly IThingService thingService;

		public ThingCache(IThingService thingService)
		{
			this.thingService = thingService;
		}

		public Thing Get(string thingId)
		{
			Thing thing;
			if (dictionary.TryGetValue(thingId, out thing))
				return thing;
			if (thingService.TryRead(thingId, out thing))
			{
				dictionary[thingId] = thing;
				return thing;
			}
			return null;
		}
	}

	[TestFixture]
	public class ThingCache_Should
	{
		private IThingService thingService;
		private ThingCache thingCache;

		private const string thingId1 = "TheDress";
		private Thing thing1 = new Thing(thingId1);

		private const string thingId2 = "CoolBoots";
		private Thing thing2 = new Thing(thingId2);

		[SetUp]
		public void SetUp()
		{
			thingService = A.Fake<IThingService>();
			thingCache = new ThingCache(thingService);
		}

		[Test]
		public void 

		//TODO: �������� ���������� ����, � ����� ��� ���������
		//Live Template tt ��������!
	}
}